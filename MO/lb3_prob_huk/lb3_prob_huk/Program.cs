using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace lb3_prob_huk
{
    class Program
    {
        public static double f(double x1, double x2)
        {
            double N = 13.0;
            double res;
            return res = N * Pow(x1, 2) + N * Pow(x2,2) - N*x1*x2 +x2;
        }
        static void Main(string[] args)
        {
            double x1 = -1, x2 = -1;
            double h = 0.3;
            double eps = 0.01;
            double f_prev = f(x1, x2);
            int n_now = 1, n_prev = 0;
            int queue = 1; // очередь x1 = 1 or x2 = -1 
            bool scs_now = true, scs_prev = true;

            Console.WriteLine("x1\t    x2\t    h\t    f(x)\tf(xn-1)\t\n");
            int i = 10;
            do
            {
                if (queue == 1) // проверяем очередь какого Икса
                {
                    if (f(x1 - h, x2) < f_prev)
                    {
                        f_prev = f(x1 - h, x2);
                        x1 -= h;
                    }
                    else if (f(x1 + h, x2) < f_prev)
                    {
                        f_prev = f(x1 + h, x2);
                        x1 += h;
                    }
                    else
                    {
                        h /= 2.0;
                    }
                    /*
                    if (scs_prev) 
                    {
                        x1 += h;
                    }
                    else
                    {
                        x1 -= h;
                    }

                    //x1 += h;
                    */
                }
                else
                {
                    if (f(x1, x2 - h) < f_prev)
                    {
                        f_prev = f(x1, x2 - h);
                        x2 -= h;
                    }
                    else if (f(x1, x2 + h) < f_prev)
                    {
                        f_prev = f(x1, x2 + h);
                        x2 += h;
                    }
                    else
                    {
                        h /= 2.0;
                    }
                    /*
                    if (scs_prev)
                    {
                        x2 += h;
                    }
                    else
                    {
                        x2 -= h;
                    }
                    */
                }
                string output = string.Format("{0:f4} | {1:f4} | {2:f4} | {3:f4} | {4:f4}", x1, x2, h, f(x1, x2), f_prev);
                Console.WriteLine(output);
                //Console.WriteLine($"{x1}\t{x2}\t{h}\t{f(x1,x2)}\t{f_prev}\tn");
                f_prev = f(x1, x2);
                i--;
                queue *= -1;
            }
            while (h > eps);
            Console.ReadKey();
        }
    }
}
