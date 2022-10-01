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
            double f_prev = 0;
            int n_now = 1, n_prev = 0;
            int queue = 1; // очередь x1 = 1 or x2 = -1 
            bool scs_now = true, scs_prev = true;

            Console.WriteLine("x1\tx2\th\tf(x)\tf(xn-1)\t\n");
            int i = 10;
            while (h > eps && i > 0)
            {
                if (queue == 1)
                {
                    if (scs_prev)
                    {
                        x1 += h;
                    }
                    else
                    {
                        x1 -= h;
                    }

                    //x1 += h;
                }
                else
                {

                }

                Console.WriteLine($"{x1}\t{x2}\t{h}\t{f(x1,x2)}\t{f_prev}\tn");
                f_prev = f(x1, x2);
                i--;
                queue *= -1;
            }
            Console.ReadKey();
        }
    }
}
