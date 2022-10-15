using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace mo_lb3_huk
{
    class Program
    {
        public static double f(double x1, double x2)
        {
            double N = 13.0;
            double res;
            return res = N * Pow(x1, 2) + N * Pow(x2, 2) - N * x1 * x2 + x2;
        }
        static void Main(string[] args)
        {
            double x1 = -1, x2 = -1;
            double x1_new = x1, x2_new = x2;
            double h = 0.3;
            double eps = 0.01;
            double f_prev = f(x1, x2);
            int queue = 1; // очередь x1 = 1 or x2 = -1 
            Console.WriteLine("x1\t    x2\t    h\t    f(x)\tf(xn-1)\t\n");
            int i = 0;
            do
            {
                //bool x1_ = false, x2_ = false;
                bool x1_, x2_;
                // check x1
                //string output = string.Format("{0:f4} | {1:f4} | {2:f4} | {3:f6} | {4:f6} | {5}", x1, x2, h, f(x1, x2), f_prev, i);
                //Console.WriteLine(output);

                if (f(x1 - h, x2) < f(x1, x2))
                {
                    //f_prev = f(x1 - h, x2);
                    x1_new = x1 - h;
                    x1_ = true;
                }
                else if ((f(x1 + h, x2) < f(x1, x2)))
                {
                    //f_prev = f(x1 + h, x2);
                    x1_new = x1 + h;
                    x1_ = true;
                }
                else
                {
                    x1_ = false;
                }
                Console.Write($"{x1} {x1_new} ");

                // check x2
                if (f(x1_new, x2 - h) < f(x1_new, x2))
                {
                    //f_prev = f(x1_new, x2 - h);
                    x2_new = x2 - h;
                    x2_ = true;
                }
                else if ((f(x1_new, x2 + h) < f(x1_new, x2)))
                {
                    //f_prev = f(x1_new, x2 + h);
                    x2_new = x2 + h;
                    x2_ = true;
                }
                else
                {
                    x2_ = false;
                }
                Console.Write($"{x2} {x2_new} {h} ");
                // check diagonal
                if (x1_ || x2_)
                {
                    double dx1 = x1_new - x1;
                    double dx2 = x2_new - x2;
                    //Console.Write($"Wi x1 = {x1} dx1 = {dx1} x2 = {x2} dx2 = {dx2}\t");
                    x1 += 2*dx1;
                    x2 += 2*dx2;
                    if (f(x1, x2) < f_prev)
                    {
                        f_prev = f(x1, x2);
                        //h /= 2;
                    }   
                }
                if(x1_ == false && x2_ == false)
                {
                    h /= 2;
                }
                Console.Write($"{h}\n");
                //string output = string.Format("{0:f4} | {1:f4} | {2:f4} | {3:f6} | {4:f6} | {5}", x1, x2, h, f(x1, x2), f_prev, i);
                //Console.WriteLine(output);

                i++;
            }
            while (h > eps && i < 20);
            Console.ReadKey();


        }
    }
}
