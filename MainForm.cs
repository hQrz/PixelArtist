using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace PixelArtist {
    public partial class MainForm : Form {
        private Bitmap source;
        private Dictionary<Button, Color> ColorBoard = new Dictionary<Button, Color>();//当前画板中的颜色集合
        private Dictionary<Button, Color> CollectColor = new Dictionary<Button, Color>();//收藏的颜色
        private bool isGetColorMode = false;
        private int optimization_index = 5;
        public MainForm() {
            InitializeComponent();
            load_color_board();
        }
        //获取所有颜色
        private List<Color> GetAllColor() {
            List<Color> all_color = ColorBoard.Values.ToList<Color>();
            return all_color.Concat<Color>(CollectColor.Values.ToList<Color>()).ToList<Color>();
        }
        //颜色取差集
        private void GetNormalColor(ref List<Color> all) {
            List<Color> part = CollectColor.Values.ToList<Color>();
            all = all.Except<Color>(part).ToList<Color>();
        }
        //刷新调色板颜色数量
        public void update_color_board_tooltips() {
            tt_color_count.SetToolTip(pl_color_board, "颜色数量" + pl_color_board.Controls.Count.ToString());
        }
        //载入目录下的所有画板
        private void load_color_board() {
            cb_color_board.Items.Clear();
            var files = Directory.GetFiles(Directory.GetCurrentDirectory(),"*.colorboard");
            foreach (var file in files) {
                string file_name = Path.GetFileName(file);
                cb_color_board.Items.Add(file_name);
            }  
        }
        //下拉框选择画板事件
        private void cb_color_board_SelectedIndexChanged(object sender, EventArgs e) {
            if (cb_color_board.Text.Length > 0) {
                delete_all_color();
                StreamReader sr = new StreamReader(cb_color_board.Text.ToString());
                String line;
                while ((line = sr.ReadLine()) != null) {
                    Byte r = Convert.ToByte(line);
                    line = sr.ReadLine();
                    Byte g = Convert.ToByte(line);
                    line = sr.ReadLine();
                    Byte b = Convert.ToByte(line);
                    line = sr.ReadLine();
                    Byte a = Convert.ToByte(line);
                    add_a_color_button(Color.FromArgb(a, r, g, b));
                }
                sr.Close();
            }
        }
        //画板中增加一个颜色按钮
        private void add_a_color_button(Color c,bool isCollect = false) {
            Button bt_color = new Button();
            bt_color.Width = 40;
            bt_color.Height = 40;
            if(isCollect == true) {
                bt_color.FlatAppearance.BorderColor = Color.Gold;
                bt_color.FlatAppearance.BorderSize = 2;
                bt_color.FlatStyle = FlatStyle.Flat;
            }
            bt_color.MouseClick += Bt_color_MouseClick;
            bt_color.MouseHover += Bt_color_MouseHover;
            bt_color.BackColor = c;
            bt_color.ContextMenuStrip = cm_delete;
            pl_color_board.Controls.Add(bt_color);
            bt_color.Show();
            ColorBoard.Add(bt_color, bt_color.BackColor);
            update_color_board_tooltips();
        }
        //修改颜色
        private void Bt_color_MouseClick(object sender, MouseEventArgs e) {
            using (System.Windows.Forms.ColorDialog dlg = new ColorDialog()) {
                if (dlg.ShowDialog() == DialogResult.OK) {
                    Button btn = (Button)sender;
                    btn.BackColor = dlg.Color;
                    ColorBoard[btn] = btn.BackColor;
                }
            }
        }
        private void Bt_color_MouseHover(object sender, EventArgs e) {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 10000;//提示信息的可见时间
            toolTip1.InitialDelay = 500;//事件触发多久后出现提示
            toolTip1.ReshowDelay = 500;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
            toolTip1.ShowAlways = true;
            Button bt = (Button)sender;
            toolTip1.SetToolTip(bt, bt.BackColor.ToString());
        }
        //----------------------颜色按钮 右键 -------------------------
        //删除事件
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem ts = (ToolStripMenuItem)sender;
            ContextMenuStrip cm = (ContextMenuStrip)ts.Owner;
            Button bt = (Button)cm.SourceControl;
            if(CollectColor.ContainsKey(bt) == false) {
                ColorBoard.Remove(bt);
                pl_color_board.Controls.Remove(bt);
                bt.Dispose();
                update_color_board_tooltips();
            }
        }
        //收藏事件
        private void 收藏ToolStripMenuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem ts = (ToolStripMenuItem)sender;
            ContextMenuStrip cm = (ContextMenuStrip)ts.Owner;
            Button bt = (Button)cm.SourceControl;
            if (CollectColor.ContainsKey(bt) == false) {
                bt.FlatAppearance.BorderColor = Color.Gold;
                bt.FlatAppearance.BorderSize = 2;
                bt.FlatStyle = FlatStyle.Flat;
                CollectColor.Add(bt, bt.BackColor);
                ColorBoard.Remove(bt);
            }
        }
        //取消收藏
        private void 取消收藏ToolStripMenuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem ts = (ToolStripMenuItem)sender;
            ContextMenuStrip cm = (ContextMenuStrip)ts.Owner;
            Button bt = (Button)cm.SourceControl;
            if (CollectColor.ContainsKey(bt)) {
                bt.FlatStyle = FlatStyle.Standard;
                CollectColor.Remove(bt);
                ColorBoard.Add(bt, bt.BackColor);
            }
        }
        //---------------------------------------------------------------
        //添加颜色 按钮事件
        private void bt_add_color_Click(object sender, EventArgs e) {
            using (System.Windows.Forms.ColorDialog dlg = new ColorDialog()) {
                if (dlg.ShowDialog() == DialogResult.OK) {
                    add_a_color_button(dlg.Color);
                }
            }
        }
        //打开一张待转换的图片
        private void bt_open_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//允许打开多个文件
            dialog.Filter = "图片文件|*.jpg;*.png;*.bmp;*.jpeg|jpg文件|*.jpg|png文件|*.png|bmp文件|*.bmp";//打开多个文件
            if (dialog.ShowDialog() == DialogResult.OK) {
                string source_path = dialog.FileName;
                tb_save_path.Text = dialog.FileName.Substring(0,dialog.FileName.LastIndexOf(".")) + "_pixel";
                tb_open_path.Text = dialog.FileName;
                source = (Bitmap)Image.FromFile(source_path);
                pb_source.Image = source.Clone() as Image;
            }
        }

        // ---------------颜色差公式 ----------------------
        public delegate double DistanceFunc(Color c1, Color c2);
        public static double Distance(DistanceFunc df,Color c1,Color c2) {
            return df(c1, c2);
        }
        public static double euc_distance(Color c1,Color c2) {
            return (c1.R - c2.R) * (c1.R - c2.R) + (c1.G - c2.G) * (c1.G - c2.G) + (c1.B - c2.B) * (c1.B - c2.B) + (c1.A - c2.A) * (c1.A - c2.A);
        }
        public static double CIEDE2000_distance(Color c1,Color c2) {
            return CIEDE2000.Delta(c1, c2);
        }
        public static double LAB_distance(Color c1,Color c2) {
            double rmean = (c1.R + c2.R) / 2;
            double r = c1.R - c2.R;
            double g = c1.G - c2.G;
            double b = c1.B - c2.B;
            return ((2 + rmean / 256) * (r * r) + 4 * g * g + (2 + (255 - rmean) / 256) * (b * b));
        }
        public static double LAB_EUC_distance(Color c1,Color c2) {
            Lab24 lab1 = UnmanagedImageConverter.ToLab24(c1), lab2 = UnmanagedImageConverter.ToLab24(c2);
            return (lab1.L-lab2.L) * (lab1.L - lab2.L) + (lab1.A - lab2.A) * (lab1.A - lab2.A) + (lab1.B - lab2.B) * (lab1.B - lab2.B);
        }
        public DistanceFunc func_ = CIEDE2000_distance;
        // -------------选择颜色相似度算法-------------
        private void rb_LAB_CheckedChanged(object sender, EventArgs e) {
            func_ = LAB_distance;
        }

        private void rb_EUC_CheckedChanged(object sender, EventArgs e) {
            func_ = euc_distance;
        }

        private void rb_CIEDE2000_CheckedChanged(object sender, EventArgs e) {
            func_ = CIEDE2000_distance;
        }
        private void rb_LAB_EUC_CheckedChanged(object sender, EventArgs e) {
            func_ = LAB_EUC_distance;
        }
        // --------------------------------------------------


        //进度条拉到100
        public void show_pixel() {
            pbar.Value = 100;
            bt_to_pixel.Enabled = true;
        }
        //-----------------转换到像素图------------------------
        private Color GetRangePixelColor(ref Bitmap bmp,int from_w,int from_h,int RIDIO) {
            return pcf(ref bmp,from_w,from_h,RIDIO);
        }
        private delegate Color PixelColorFunc(ref Bitmap bmp, int from_w, int from_h, int RIDIO);
        //取范围内平均颜色
        private static Color AvgRangePixelColor(ref Bitmap bmp, int from_w, int from_h, int RIDIO) {
            int avgRed = 0, avgGreen = 0, avgBlue = 0, avgAlpha = 0,count = 0;
            for (int x = from_w; (x < from_w + RIDIO && x < bmp.Width); x++) {
                for (int y = from_h; (y < from_h + RIDIO && y < bmp.Height); y++) {
                    Color c = bmp.GetPixel(x, y);
                    avgAlpha += c.A;
                    avgRed += c.R;
                    avgGreen += c.G;
                    avgBlue += c.B;
                    count++;
                }
            }
            return Color.FromArgb(avgAlpha / count, avgRed / count, avgGreen / count, avgBlue / count);
        }
        //取范围内像素占比最多的颜色
        private static Color MostRangePixelColor(ref Bitmap bmp, int from_w, int from_h, int RIDIO) {
            Dictionary<Color, int> electer = new Dictionary<Color, int>();
            for (int x = from_w; (x < from_w + RIDIO && x < bmp.Width); x++) {
                for (int y = from_h; (y < from_h + RIDIO && y < bmp.Height); y++) {
                    Color pixel = bmp.GetPixel(x, y);
                    if (electer.ContainsKey(pixel)) {
                        electer[pixel]++;
                    } else {
                        electer.Add(pixel, 0);
                    }
                }
            }
            int max_value = electer.Values.Max();
            List<Color> max_color = electer.Where(x => x.Value == max_value).Select(p => p.Key).ToList<Color>();
            int avgRed = 0, avgGreen = 0, avgBlue = 0, avgAlpha = 0;
            foreach (Color c in max_color) {
                avgAlpha += c.A;
                avgRed += c.R;
                avgGreen += c.G;
                avgBlue += c.B;
            }
            return Color.FromArgb(avgAlpha / max_color.Count, avgRed / max_color.Count, avgGreen / max_color.Count, avgBlue / max_color.Count);
        }
        private PixelColorFunc pcf = MostRangePixelColor;
        private void rb_convert_avg_CheckedChanged(object sender, EventArgs e) {
            pcf = AvgRangePixelColor;
        }
        private void rb_convert_most_CheckedChanged(object sender, EventArgs e) {
            pcf = MostRangePixelColor;
        }
        //转换到像素图主过程
        private void source_to_pixel(object parameter) {
            int RIDIO = (int)parameter;
            Bitmap newbitmap = source.Clone() as Bitmap;
            List<Color> color_board = null;
            if (ColorBoard.Count > 0 || CollectColor.Count > 0) {
                color_board = GetAllColor();
            }
            for (int h = 0; h < newbitmap.Height; h += RIDIO) {
                for (int w = 0; w < newbitmap.Width; w += RIDIO) {
                    //设置颜色
                    Color newColor = GetRangePixelColor(ref newbitmap, w, h, RIDIO);
                    double min_distance = Convert.ToDouble(nud_color_threshold.Value);
                    Color min_color = newColor;
                    if (color_board != null) {
                        foreach (Color c in color_board) {
                            double distance = Distance(func_, newColor, c);
                            if (distance < min_distance) {
                                min_distance = distance;
                                min_color = c;
                            }
                        }
                    }
                    for (int x = w; (x < w + RIDIO && x < newbitmap.Width); x++) {
                        for (int y = h; (y < h + RIDIO && y < newbitmap.Height); y++) {
                            newbitmap.SetPixel(x, y, min_color);
                        }
                    }
                }
            }
            MethodInvoker inf = new MethodInvoker(show_pixel);
            BeginInvoke(inf);
            pb_result.Image = newbitmap.Clone() as Image;
        }
        //转换像素图 按钮事件
        private void bt_to_pixel_Click(object sender, EventArgs e) {
            if (source != null) {
                bt_to_pixel.Enabled = false;
                pbar.Value = 0;
                Bitmap newbitmap = source.Clone() as Bitmap;
                int RIDIO = 5;
                RIDIO = Convert.ToInt32(nud_color_size.Value);
                Thread to_pixel = new Thread(new ParameterizedThreadStart(source_to_pixel));
                to_pixel.Start(RIDIO);
                pbar.Value = 67;
            }
        }
        //打开保存路径
        private void bt_open_root_path_Click(object sender, EventArgs e) {
            string v_OpenFolderPath = tb_save_path.Text.ToString().Substring(0,tb_save_path.Text.ToString().LastIndexOf("\\"));
            System.Diagnostics.Process.Start("explorer.exe", v_OpenFolderPath);
        }
        //----------------保存像素图 按钮事件-----------------------
        private static ImageCodecInfo GetEncoderInfo(String mimeType) {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j) {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        private void bt_save_Click(object sender, EventArgs e) {
            if (pb_result.Image != null) {
                //ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/bmp");
                //EncoderParameters myEncoderParameters = new EncoderParameters(1);
                //myEncoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 100000L);
                //pb_result.Image.Save(tb_save_path.Text + ".bmp", myImageCodecInfo, myEncoderParameters);
                pb_result.Image.Save(tb_save_path.Text + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                MessageBox.Show("已保存", "提示", MessageBoxButtons.OK);
            }
        }
        //------------------------------------------------
        //保存画板 按钮事件
        private void bt_save_color_Click(object sender, EventArgs e) {
            if (ColorBoard.Count > 0 || CollectColor.Count > 0) {
                SaveFileDialog sf = new SaveFileDialog();
                sf.RestoreDirectory = false;
                sf.InitialDirectory = Directory.GetCurrentDirectory();
                sf.Filter = "ColorBoard|*.colorboard";
                if (sf.ShowDialog() == DialogResult.OK) {
                    List<Color> all_color = GetAllColor();
                    StreamWriter file = new StreamWriter(sf.FileName);
                    foreach (Color c in all_color) {
                        file.Write(c.R.ToString() + "\n" + c.G.ToString() + "\n" + c.B.ToString() + "\n" + c.A.ToString() + "\n");
                    }
                    file.Close();
                }
                load_color_board();
            }
        }
        //删除画板中所有颜色
        private void delete_all_color() {
            pl_color_board.Controls.Clear();
            ColorBoard.Clear();
            List<Color> collections = CollectColor.Values.ToList<Color>();
            foreach (Color c in collections) {
                add_a_color_button(c,true);
            }            
            update_color_board_tooltips();
        }

        //根据RGB计算色相Hue
        private static double Hue(Color c) {
            double hue = 0;
            Byte max_rgb = Math.Max(Math.Max(c.R, c.G),c.B),
                min_rgb = Math.Min(Math.Min(c.R,c.G),c.B);
            int diff = max_rgb - min_rgb;
            if (diff != 0) {
                if (c.R == max_rgb)
                    hue = (c.G - c.B) / diff;
                if (c.G == max_rgb)
                    hue = 2.0 + (c.B - c.R) / diff;
                if (c.B == max_rgb)
                    hue = 4.0 + (c.R - c.G) / diff;
                hue *= 60;
                if (hue < 0)
                    hue += 360;
            }
            return hue;
        }
        //------------------对画板颜色进行排序--------------------
        //根据HSV模型色相排序
        private void sort_color_board_by_Hue(ref List<Color> color_list) {
            Dictionary<Color, double> RGB_Hue = new Dictionary<Color, double>();
            foreach (Color c in color_list) {
                RGB_Hue.Add(c, Hue(c));
            }
            color_list.Sort((c1, c2) => {
                if (RGB_Hue[c1] > RGB_Hue[c2])
                    return 1;
                else if (RGB_Hue[c1] == RGB_Hue[c2])
                    return 0;
                else
                    return -1;
            });
        }
        //角度
        public double Angle(Byte X1,Byte Y1,Byte X2,Byte Y2) {    
            return Math.Acos((X1*X2 + Y1*Y2)/(Math.Abs(Math.Sqrt(X1*X1 + Y1*Y1) * Math.Abs(Math.Sqrt(X2*X2 + Y2*Y2)))));
        }
        //根据LAB模型排序，先看亮度L，再根据AB向量夹角大小排序，最后看AB向量长度
        private List<ColorLAB> sort_color_board_by_lab(ref List<Color> color_list) {
            List<ColorLAB> order_list = new List<global::ColorLAB> ();
            foreach (Color c in color_list) {
                order_list.Add(new ColorLAB(c));
            }
            order_list.Sort((c1, c2) => {
                if (c1.value.L < c2.value.L)
                    return 1;
                else if (c1.value.L == c2.value.L) {
                    int diff = c1.value.A * c1.value.A + c1.value.B * c1.value.B - c2.value.A * c2.value.A - c2.value.B * c2.value.B;
                    if (diff > 0)
                        return 1;
                    else if (diff < 0)
                        return -1;
                    else {
                        double ag = Angle(c1.value.A, c1.value.B, c2.value.A, c2.value.B);
                        if (ag > 0)
                            return 1;
                        else if (ag < 0)
                            return -1;
                        else
                            return 0;
                    }
                    //double ag = Angle(c1.value.A, c1.value.B, c2.value.A, c2.value.B);
                    //if (ag > 0)
                    //    return 1;
                    //else if (ag < 0)
                    //    return -1;
                    //else {
                    //    int diff = c1.value.A - c2.value.A;//角度相等，坐标越大 => 长度越大
                    //    if (diff < 0)
                    //        return 1;
                    //    else if (diff > 0)
                    //        return -1;
                    //    else
                    //        return 0;
                    //}
                } else {
                    return -1;
                }
            });
            color_list.Clear();
            foreach(ColorLAB clab in order_list) {
                color_list.Add(clab.key);
            }
            return order_list;
        }
        // ------------------------------------------------
        //根据颜色列表重新载入调色板
        private void reload_color_board(ref List<Color> color_list) {
            delete_all_color();
            GetNormalColor(ref color_list);
            foreach (Color c in color_list) {
                add_a_color_button(c);
            }
        }
        //读取像素图中的所有颜色到画板中
        private void 读取颜色ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (pb_result.Image != null) {
                delete_all_color();
                Bitmap result = pb_result.Image as Bitmap;
                List<Color> color_list = new List<Color>();
                for (int x = 0; x < result.Width; x++) {
                    for (int y = 0; y < result.Height; y++) {
                        Color pixel = result.GetPixel(x, y);
                        if (color_list.Exists(c => c.Equals(pixel)) == false) {
                            color_list.Add(pixel);
                        }
                    }
                }
                //List<Color> color_list = pb_result.Image.Palette.Entries.ToList<Color>();
                if (color_list.Count > 2000) {
                    DialogResult dr = MessageBox.Show("颜色数量：" + color_list.Count.ToString() + "  较大，读取很慢，是否继续？", "提示", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No) {
                        return;
                    }
                }
                sort_color_board_by_lab(ref color_list);
                reload_color_board(ref color_list);
            }
        }

        //---------------画板右键----------------
        private void 全部删除ToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogResult dr = MessageBox.Show("是否全部删除？", "提示", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes) {
                delete_all_color();
            }
        }

        private void 颜色排序ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (ColorBoard.Count > 0 || CollectColor.Count > 0) {
                List<Color> color_list = GetAllColor();
                sort_color_board_by_lab(ref color_list);
                reload_color_board(ref color_list);
            }
        }

        private void 优化色彩ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (ColorBoard.Count > 0 || CollectColor.Count > 0) {
                List<Color> color_list = GetAllColor();
                List<ColorLAB> order_list = sort_color_board_by_lab(ref color_list);
                List<Color> new_color_list = new List<Color>();
                //生成<颜色:间隔>表
                List<double> gap_table = new List<double>();
                for(int i = 0;i < order_list.Count; i++) {
                    gap_table.Add(order_list[i].distance_to(order_list[(order_list.Count+i-1)%order_list.Count]));
                }
                //根据优化系数进行稀疏筛选，即根据颜色距离的间隔阈值，筛掉间隔小于阈值的颜色，使得颜色整体间隔距离趋于稀疏
                double gap = 0;
                for(int i = 0; i < order_list.Count; i++) {
                    gap += gap_table[i];
                    if(gap > optimization_index) {
                        new_color_list.Add(order_list[i].key);
                        gap = 0;
                    }
                }
                //更新优化系数
                double count_index = Convert.ToDouble(new_color_list.Count) / Convert.ToDouble(order_list.Count);
                if (count_index > 0.75)
                    optimization_index += 5;
                else
                    optimization_index = 5;
                //重新载入调色板
                reload_color_board(ref new_color_list);
            }
        }

        private void pb_result_MouseMove(object sender, MouseEventArgs e) {
            if (isGetColorMode) {
                
            }
        }

        private void bt_get_color_Click(object sender, EventArgs e) {
            isGetColorMode = true;
        }

        private void pb_result_MouseDown(object sender, MouseEventArgs e) {
            if (isGetColorMode) {

                isGetColorMode = false;
            }
        }


        //--------------------------------------
    }
}
