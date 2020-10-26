namespace PixelArtist
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pb_result = new System.Windows.Forms.PictureBox();
            this.cm_result = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.读取颜色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_open = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.cb_color_board = new System.Windows.Forms.ComboBox();
            this.pb_source = new System.Windows.Forms.PictureBox();
            this.bt_to_pixel = new System.Windows.Forms.Button();
            this.bt_add_color = new System.Windows.Forms.Button();
            this.bt_save_color = new System.Windows.Forms.Button();
            this.pl_color_board = new System.Windows.Forms.FlowLayoutPanel();
            this.cm_delete_all = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.全部删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.颜色排序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.优化色彩ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cm_delete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.收藏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消收藏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.pbar = new System.Windows.Forms.ProgressBar();
            this.tb_save_path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_color_threshold = new System.Windows.Forms.NumericUpDown();
            this.nud_color_size = new System.Windows.Forms.NumericUpDown();
            this.tb_open_path = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rb_LAB = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rb_EUC = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.rb_CIEDE2000 = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.rb_LAB_EUC = new System.Windows.Forms.RadioButton();
            this.tt_color_count = new System.Windows.Forms.ToolTip(this.components);
            this.bt_open_root_path = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.rb_convert_avg = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.rb_convert_most = new System.Windows.Forms.RadioButton();
            this.bt_get_color = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_result)).BeginInit();
            this.cm_result.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_source)).BeginInit();
            this.cm_delete_all.SuspendLayout();
            this.cm_delete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_color_threshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_color_size)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_result
            // 
            this.pb_result.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pb_result.ContextMenuStrip = this.cm_result;
            this.pb_result.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pb_result.Location = new System.Drawing.Point(12, 12);
            this.pb_result.Name = "pb_result";
            this.pb_result.Size = new System.Drawing.Size(700, 600);
            this.pb_result.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_result.TabIndex = 0;
            this.pb_result.TabStop = false;
            this.pb_result.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_result_MouseDown);
            this.pb_result.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_result_MouseMove);
            // 
            // cm_result
            // 
            this.cm_result.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.读取颜色ToolStripMenuItem});
            this.cm_result.Name = "cm_result";
            this.cm_result.Size = new System.Drawing.Size(125, 26);
            // 
            // 读取颜色ToolStripMenuItem
            // 
            this.读取颜色ToolStripMenuItem.Name = "读取颜色ToolStripMenuItem";
            this.读取颜色ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.读取颜色ToolStripMenuItem.Text = "读取颜色";
            this.读取颜色ToolStripMenuItem.Click += new System.EventHandler(this.读取颜色ToolStripMenuItem_Click);
            // 
            // bt_open
            // 
            this.bt_open.Location = new System.Drawing.Point(920, 618);
            this.bt_open.Name = "bt_open";
            this.bt_open.Size = new System.Drawing.Size(75, 23);
            this.bt_open.TabIndex = 13;
            this.bt_open.Text = "打开";
            this.bt_open.UseVisualStyleBackColor = true;
            this.bt_open.Click += new System.EventHandler(this.bt_open_Click);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(637, 618);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 12;
            this.bt_save.Text = "保存";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // cb_color_board
            // 
            this.cb_color_board.FormattingEnabled = true;
            this.cb_color_board.Location = new System.Drawing.Point(716, 13);
            this.cb_color_board.Name = "cb_color_board";
            this.cb_color_board.Size = new System.Drawing.Size(198, 20);
            this.cb_color_board.TabIndex = 1;
            this.cb_color_board.SelectedIndexChanged += new System.EventHandler(this.cb_color_board_SelectedIndexChanged);
            // 
            // pb_source
            // 
            this.pb_source.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pb_source.Cursor = System.Windows.Forms.Cursors.No;
            this.pb_source.Location = new System.Drawing.Point(920, 12);
            this.pb_source.Name = "pb_source";
            this.pb_source.Size = new System.Drawing.Size(700, 600);
            this.pb_source.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_source.TabIndex = 4;
            this.pb_source.TabStop = false;
            // 
            // bt_to_pixel
            // 
            this.bt_to_pixel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt_to_pixel.Location = new System.Drawing.Point(716, 606);
            this.bt_to_pixel.Name = "bt_to_pixel";
            this.bt_to_pixel.Size = new System.Drawing.Size(201, 23);
            this.bt_to_pixel.TabIndex = 7;
            this.bt_to_pixel.Text = "转化为像素图";
            this.bt_to_pixel.UseVisualStyleBackColor = false;
            this.bt_to_pixel.Click += new System.EventHandler(this.bt_to_pixel_Click);
            // 
            // bt_add_color
            // 
            this.bt_add_color.Location = new System.Drawing.Point(716, 427);
            this.bt_add_color.Name = "bt_add_color";
            this.bt_add_color.Size = new System.Drawing.Size(75, 25);
            this.bt_add_color.TabIndex = 3;
            this.bt_add_color.Text = "增加颜色";
            this.bt_add_color.UseVisualStyleBackColor = true;
            this.bt_add_color.Click += new System.EventHandler(this.bt_add_color_Click);
            // 
            // bt_save_color
            // 
            this.bt_save_color.Location = new System.Drawing.Point(842, 427);
            this.bt_save_color.Name = "bt_save_color";
            this.bt_save_color.Size = new System.Drawing.Size(75, 25);
            this.bt_save_color.TabIndex = 4;
            this.bt_save_color.Tag = "";
            this.bt_save_color.Text = "保存调色板";
            this.bt_save_color.UseVisualStyleBackColor = true;
            this.bt_save_color.Click += new System.EventHandler(this.bt_save_color_Click);
            // 
            // pl_color_board
            // 
            this.pl_color_board.AllowDrop = true;
            this.pl_color_board.AutoScroll = true;
            this.pl_color_board.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pl_color_board.ContextMenuStrip = this.cm_delete_all;
            this.pl_color_board.Location = new System.Drawing.Point(716, 39);
            this.pl_color_board.Name = "pl_color_board";
            this.pl_color_board.Size = new System.Drawing.Size(201, 382);
            this.pl_color_board.TabIndex = 2;
            // 
            // cm_delete_all
            // 
            this.cm_delete_all.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.全部删除ToolStripMenuItem,
            this.颜色排序ToolStripMenuItem,
            this.优化色彩ToolStripMenuItem});
            this.cm_delete_all.Name = "cm_delete_all";
            this.cm_delete_all.Size = new System.Drawing.Size(125, 70);
            // 
            // 全部删除ToolStripMenuItem
            // 
            this.全部删除ToolStripMenuItem.Name = "全部删除ToolStripMenuItem";
            this.全部删除ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.全部删除ToolStripMenuItem.Text = "全部删除";
            this.全部删除ToolStripMenuItem.Click += new System.EventHandler(this.全部删除ToolStripMenuItem_Click);
            // 
            // 颜色排序ToolStripMenuItem
            // 
            this.颜色排序ToolStripMenuItem.Name = "颜色排序ToolStripMenuItem";
            this.颜色排序ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.颜色排序ToolStripMenuItem.Text = "颜色排序";
            this.颜色排序ToolStripMenuItem.Click += new System.EventHandler(this.颜色排序ToolStripMenuItem_Click);
            // 
            // 优化色彩ToolStripMenuItem
            // 
            this.优化色彩ToolStripMenuItem.Name = "优化色彩ToolStripMenuItem";
            this.优化色彩ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.优化色彩ToolStripMenuItem.Text = "优化色彩";
            this.优化色彩ToolStripMenuItem.Click += new System.EventHandler(this.优化色彩ToolStripMenuItem_Click);
            // 
            // cm_delete
            // 
            this.cm_delete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem,
            this.收藏ToolStripMenuItem,
            this.取消收藏ToolStripMenuItem});
            this.cm_delete.Name = "cm_delete";
            this.cm_delete.Size = new System.Drawing.Size(125, 70);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 收藏ToolStripMenuItem
            // 
            this.收藏ToolStripMenuItem.Name = "收藏ToolStripMenuItem";
            this.收藏ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.收藏ToolStripMenuItem.Text = "收藏";
            this.收藏ToolStripMenuItem.Click += new System.EventHandler(this.收藏ToolStripMenuItem_Click);
            // 
            // 取消收藏ToolStripMenuItem
            // 
            this.取消收藏ToolStripMenuItem.Name = "取消收藏ToolStripMenuItem";
            this.取消收藏ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.取消收藏ToolStripMenuItem.Text = "取消收藏";
            this.取消收藏ToolStripMenuItem.Click += new System.EventHandler(this.取消收藏ToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F);
            this.label2.Location = new System.Drawing.Point(714, 483);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "像素宽度";
            // 
            // pbar
            // 
            this.pbar.Location = new System.Drawing.Point(716, 630);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(201, 11);
            this.pbar.TabIndex = 18;
            // 
            // tb_save_path
            // 
            this.tb_save_path.Location = new System.Drawing.Point(108, 619);
            this.tb_save_path.Name = "tb_save_path";
            this.tb_save_path.Size = new System.Drawing.Size(523, 21);
            this.tb_save_path.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(714, 458);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 20;
            this.label1.Text = "调色板阈值";
            // 
            // nud_color_threshold
            // 
            this.nud_color_threshold.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_color_threshold.Location = new System.Drawing.Point(790, 457);
            this.nud_color_threshold.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nud_color_threshold.Name = "nud_color_threshold";
            this.nud_color_threshold.Size = new System.Drawing.Size(125, 21);
            this.nud_color_threshold.TabIndex = 5;
            this.nud_color_threshold.ThousandsSeparator = true;
            this.nud_color_threshold.Value = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            // 
            // nud_color_size
            // 
            this.nud_color_size.Location = new System.Drawing.Point(790, 482);
            this.nud_color_size.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_color_size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_color_size.Name = "nud_color_size";
            this.nud_color_size.Size = new System.Drawing.Size(125, 21);
            this.nud_color_size.TabIndex = 6;
            this.nud_color_size.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // tb_open_path
            // 
            this.tb_open_path.Enabled = false;
            this.tb_open_path.Location = new System.Drawing.Point(1002, 619);
            this.tb_open_path.Name = "tb_open_path";
            this.tb_open_path.Size = new System.Drawing.Size(618, 21);
            this.tb_open_path.TabIndex = 23;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.rb_LAB);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.rb_EUC);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.rb_CIEDE2000);
            this.flowLayoutPanel1.Controls.Add(this.label10);
            this.flowLayoutPanel1.Controls.Add(this.rb_LAB_EUC);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(717, 509);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 56);
            this.flowLayoutPanel1.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "颜色匹配算法                    ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(3, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "LAB";
            // 
            // rb_LAB
            // 
            this.rb_LAB.AutoSize = true;
            this.rb_LAB.Location = new System.Drawing.Point(37, 15);
            this.rb_LAB.Name = "rb_LAB";
            this.rb_LAB.Size = new System.Drawing.Size(14, 13);
            this.rb_LAB.TabIndex = 8;
            this.rb_LAB.UseVisualStyleBackColor = true;
            this.rb_LAB.CheckedChanged += new System.EventHandler(this.rb_LAB_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.Location = new System.Drawing.Point(57, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "EUC ";
            // 
            // rb_EUC
            // 
            this.rb_EUC.AutoSize = true;
            this.rb_EUC.Location = new System.Drawing.Point(98, 15);
            this.rb_EUC.Name = "rb_EUC";
            this.rb_EUC.Size = new System.Drawing.Size(14, 13);
            this.rb_EUC.TabIndex = 9;
            this.rb_EUC.UseVisualStyleBackColor = true;
            this.rb_EUC.CheckedChanged += new System.EventHandler(this.rb_EUC_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F);
            this.label5.Location = new System.Drawing.Point(118, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "CIEDE2000";
            // 
            // rb_CIEDE2000
            // 
            this.rb_CIEDE2000.AutoSize = true;
            this.rb_CIEDE2000.Checked = true;
            this.rb_CIEDE2000.Location = new System.Drawing.Point(183, 15);
            this.rb_CIEDE2000.Name = "rb_CIEDE2000";
            this.rb_CIEDE2000.Size = new System.Drawing.Size(14, 13);
            this.rb_CIEDE2000.TabIndex = 10;
            this.rb_CIEDE2000.TabStop = true;
            this.rb_CIEDE2000.UseVisualStyleBackColor = true;
            this.rb_CIEDE2000.CheckedChanged += new System.EventHandler(this.rb_CIEDE2000_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10F);
            this.label10.Location = new System.Drawing.Point(3, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 14);
            this.label10.TabIndex = 28;
            this.label10.Text = "LAB-EUC ";
            // 
            // rb_LAB_EUC
            // 
            this.rb_LAB_EUC.AutoSize = true;
            this.rb_LAB_EUC.Location = new System.Drawing.Point(72, 34);
            this.rb_LAB_EUC.Name = "rb_LAB_EUC";
            this.rb_LAB_EUC.Size = new System.Drawing.Size(14, 13);
            this.rb_LAB_EUC.TabIndex = 29;
            this.rb_LAB_EUC.TabStop = true;
            this.rb_LAB_EUC.UseVisualStyleBackColor = true;
            this.rb_LAB_EUC.CheckedChanged += new System.EventHandler(this.rb_LAB_EUC_CheckedChanged);
            // 
            // tt_color_count
            // 
            this.tt_color_count.ShowAlways = true;
            // 
            // bt_open_root_path
            // 
            this.bt_open_root_path.Location = new System.Drawing.Point(12, 618);
            this.bt_open_root_path.Name = "bt_open_root_path";
            this.bt_open_root_path.Size = new System.Drawing.Size(90, 23);
            this.bt_open_root_path.TabIndex = 26;
            this.bt_open_root_path.Text = "打开保存路径";
            this.bt_open_root_path.UseVisualStyleBackColor = true;
            this.bt_open_root_path.Click += new System.EventHandler(this.bt_open_root_path_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "转化算法                       ";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.flowLayoutPanel2.Controls.Add(this.label7);
            this.flowLayoutPanel2.Controls.Add(this.label8);
            this.flowLayoutPanel2.Controls.Add(this.rb_convert_avg);
            this.flowLayoutPanel2.Controls.Add(this.label9);
            this.flowLayoutPanel2.Controls.Add(this.rb_convert_most);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(717, 571);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 35);
            this.flowLayoutPanel2.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10F);
            this.label8.Location = new System.Drawing.Point(3, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "AVG";
            // 
            // rb_convert_avg
            // 
            this.rb_convert_avg.AutoSize = true;
            this.rb_convert_avg.Location = new System.Drawing.Point(37, 15);
            this.rb_convert_avg.Name = "rb_convert_avg";
            this.rb_convert_avg.Size = new System.Drawing.Size(14, 13);
            this.rb_convert_avg.TabIndex = 1;
            this.rb_convert_avg.UseVisualStyleBackColor = true;
            this.rb_convert_avg.CheckedChanged += new System.EventHandler(this.rb_convert_avg_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10F);
            this.label9.Location = new System.Drawing.Point(57, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 14);
            this.label9.TabIndex = 2;
            this.label9.Text = "Most";
            // 
            // rb_convert_most
            // 
            this.rb_convert_most.AutoSize = true;
            this.rb_convert_most.Checked = true;
            this.rb_convert_most.Location = new System.Drawing.Point(98, 15);
            this.rb_convert_most.Name = "rb_convert_most";
            this.rb_convert_most.Size = new System.Drawing.Size(14, 13);
            this.rb_convert_most.TabIndex = 3;
            this.rb_convert_most.TabStop = true;
            this.rb_convert_most.UseVisualStyleBackColor = true;
            this.rb_convert_most.CheckedChanged += new System.EventHandler(this.rb_convert_most_CheckedChanged);
            // 
            // bt_get_color
            // 
            this.bt_get_color.Location = new System.Drawing.Point(804, 427);
            this.bt_get_color.Name = "bt_get_color";
            this.bt_get_color.Size = new System.Drawing.Size(25, 25);
            this.bt_get_color.TabIndex = 30;
            this.bt_get_color.Text = "取";
            this.bt_get_color.UseVisualStyleBackColor = true;
            this.bt_get_color.Click += new System.EventHandler(this.bt_get_color_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1634, 651);
            this.Controls.Add(this.bt_get_color);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.bt_open_root_path);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tb_open_path);
            this.Controls.Add(this.nud_color_size);
            this.Controls.Add(this.nud_color_threshold);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_save_path);
            this.Controls.Add(this.pbar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pl_color_board);
            this.Controls.Add(this.bt_save_color);
            this.Controls.Add(this.bt_add_color);
            this.Controls.Add(this.bt_to_pixel);
            this.Controls.Add(this.pb_source);
            this.Controls.Add(this.cb_color_board);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.bt_open);
            this.Controls.Add(this.pb_result);
            this.MaximumSize = new System.Drawing.Size(1650, 690);
            this.MinimumSize = new System.Drawing.Size(1650, 690);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PixelArtist";
            ((System.ComponentModel.ISupportInitialize)(this.pb_result)).EndInit();
            this.cm_result.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_source)).EndInit();
            this.cm_delete_all.ResumeLayout(false);
            this.cm_delete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_color_threshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_color_size)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_result;
        private System.Windows.Forms.Button bt_open;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.ComboBox cb_color_board;
        private System.Windows.Forms.PictureBox pb_source;
        private System.Windows.Forms.Button bt_to_pixel;
        private System.Windows.Forms.Button bt_add_color;
        private System.Windows.Forms.Button bt_save_color;
        private System.Windows.Forms.FlowLayoutPanel pl_color_board;
        private System.Windows.Forms.ContextMenuStrip cm_delete;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pbar;
        private System.Windows.Forms.TextBox tb_save_path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_color_threshold;
        private System.Windows.Forms.NumericUpDown nud_color_size;
        private System.Windows.Forms.TextBox tb_open_path;
        private System.Windows.Forms.ContextMenuStrip cm_delete_all;
        private System.Windows.Forms.ToolStripMenuItem 全部删除ToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rb_LAB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rb_EUC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rb_CIEDE2000;
        private System.Windows.Forms.ContextMenuStrip cm_result;
        private System.Windows.Forms.ToolStripMenuItem 读取颜色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 颜色排序ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 优化色彩ToolStripMenuItem;
        private System.Windows.Forms.ToolTip tt_color_count;
        private System.Windows.Forms.ToolStripMenuItem 收藏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消收藏ToolStripMenuItem;
        private System.Windows.Forms.Button bt_open_root_path;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rb_convert_avg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rb_convert_most;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rb_LAB_EUC;
        private System.Windows.Forms.Button bt_get_color;
    }
}

