using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

struct LAB {
    public double l;
    public double a;
    public double b;

    public LAB(double L,double A,double B) {
        l = L;
        a = A;
        b = B;
    }
};

namespace PixelArtist {
    class CIEDE2000 {
        const double M_PI = 3.14159265358979323846264338327950288;

        public static double deg2Rad(double deg) {
            return (deg * (M_PI / 180.0));
        }

        public static double rad2Deg(double rad) {
            return ((180.0 / M_PI) * rad);
        }

        public static unsafe double Delta(Color c1,Color c2) {
            Rgb24 rgb1 = new Rgb24(c1),rgb2 = new Rgb24(c2);
            Lab24 lab1 = new Lab24(),lab2 = new Lab24();
            UnmanagedImageConverter.ToLab24(&rgb1,&lab1);
            UnmanagedImageConverter.ToLab24(&rgb2, &lab2);
            return Delta(new LAB(lab1.L, lab1.A, lab1.B), new LAB(lab2.L, lab2.A, lab2.B));
        }

        public static double Delta(LAB lab1, LAB lab2) {
            const double k_L = 1.0, k_C = 1.0, k_H = 1.0;
            double deg360InRad = deg2Rad(360.0);
            double deg180InRad = deg2Rad(180.0);
            const double pow25To7 = 6103515625.0; /* pow(25, 7) */

            /*
             * Step 1 
             */
            /* Equation 2 */
            double C1 = Math.Sqrt((lab1.a * lab1.a) + (lab1.b * lab1.b));
            double C2 = Math.Sqrt((lab2.a * lab2.a) + (lab2.b * lab2.b));
            /* Equation 3 */
            double barC = (C1 + C2) / 2.0;
            /* Equation 4 */
            double G = 0.5 * (1 - Math.Sqrt(Math.Pow(barC, 7) / (Math.Pow(barC, 7) + pow25To7)));
            /* Equation 5 */
            double a1Prime = (1.0 + G) * lab1.a;
            double a2Prime = (1.0 + G) * lab2.a;
            /* Equation 6 */
            double CPrime1 = Math.Sqrt((a1Prime * a1Prime) + (lab1.b * lab1.b));
            double CPrime2 = Math.Sqrt((a2Prime * a2Prime) + (lab2.b * lab2.b));
            /* Equation 7 */
            double hPrime1;
            if (lab1.b == 0 && a1Prime == 0)
                hPrime1 = 0.0;
            else {
                hPrime1 = Math.Atan2(lab1.b, a1Prime);
                if (hPrime1< 0)
                    hPrime1 += deg360InRad;
            }
            double hPrime2;
            if (lab2.b == 0 && a2Prime == 0)
                hPrime2 = 0.0;
            else {
                hPrime2 = Math.Atan2(lab2.b, a2Prime);
                if (hPrime2< 0)
                    hPrime2 += deg360InRad;
            }
            double deltaLPrime = lab2.l - lab1.l;
            double deltaCPrime = CPrime2 - CPrime1;
            double deltahPrime;
            double CPrimeProduct = CPrime1 * CPrime2;
            if (CPrimeProduct == 0)
                deltahPrime = 0;
            else {
                deltahPrime = hPrime2 - hPrime1;
                if (deltahPrime< -deg180InRad)
                    deltahPrime += deg360InRad;
                else if (deltahPrime > deg180InRad)
                    deltahPrime -= deg360InRad;
            }
            double deltaHPrime = 2.0 * Math.Sqrt(CPrimeProduct) * Math.Sin(deltahPrime / 2.0);

            double barLPrime = (lab1.l + lab2.l) / 2.0;
            double barCPrime = (CPrime1 + CPrime2) / 2.0;
            double barhPrime, hPrimeSum = hPrime1 + hPrime2;
            if (CPrime1* CPrime2 == 0) {
                barhPrime = hPrimeSum;
            } else {
                if (Math.Abs(hPrime1 - hPrime2) <= deg180InRad)
                    barhPrime = hPrimeSum / 2.0;
                else {
                    if (hPrimeSum<deg360InRad)
                        barhPrime = (hPrimeSum + deg360InRad) / 2.0;
                    else
                        barhPrime = (hPrimeSum - deg360InRad) / 2.0;
                }
            }
            /* Equation 15 */
            double T = 1.0 - (0.17 * Math.Cos(barhPrime - deg2Rad(30.0))) +
                (0.24 * Math.Cos(2.0 * barhPrime)) +
                (0.32 * Math.Cos((3.0 * barhPrime) + deg2Rad(6.0))) -
                (0.20 * Math.Cos((4.0 * barhPrime) - deg2Rad(63.0)));
            double deltaTheta = deg2Rad(30.0) *
                Math.Exp(-Math.Pow((barhPrime - deg2Rad(275.0)) / deg2Rad(25.0), 2.0));
            double R_C = 2.0 * Math.Sqrt(Math.Pow(barCPrime, 7.0) /
                (Math.Pow(barCPrime, 7.0) + pow25To7));
            double S_L = 1 + ((0.015 * Math.Pow(barLPrime - 50.0, 2.0)) /
                Math.Sqrt(20 + Math.Pow(barLPrime - 50.0, 2.0)));
            double S_C = 1 + (0.045 * barCPrime);
            double S_H = 1 + (0.015 * barCPrime * T);
            double R_T = (-Math.Sin(2.0 * deltaTheta)) * R_C;
            double deltaE = Math.Pow(deltaLPrime / (k_L * S_L), 2.0) + Math.Pow(deltaCPrime / (k_C * S_C), 2.0) + Math.Pow(deltaHPrime / (k_H * S_H), 2.0) + (R_T * (deltaCPrime / (k_C * S_C)) * (deltaHPrime / (k_H * S_H)));

            return (deltaE);
        }
    }
}
