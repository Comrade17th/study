using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace mo_lb3_huk
{
    class Dot
    {
        public double x1;
        public double x2;
        public Dot(double x1, double x2)
        {
            this.x1 = x1; 
            this.x2 = x2;
        }

        public double X1
        {
            get { return this.x1; }
            set { this.x1 = value; }
        }
        public double X2
        {
            get { return this.x2; }
            set { this.x2 = value; }
        }

        public string Output()
        {
            string res;
            res = string.Format("x1 = {0:f4}\tx2 = {1:f4}", this.x1, this.x2);
            return res;
        }

        public Dot x1plush(double h1)
        {
            Dot res = new Dot(this.x1, this.x2);
            res.X1 += h1;
            return res;
        }

        public Dot x2plush(double h2)
        {
            Dot res = new Dot(this.x1, this.x2);
            res.X2 += h2;
            return res;
        }

        public static bool operator ==(Dot dt1, Dot dt2)
        {
            return (dt1.x1 == dt2.x1 && dt1.X2 == dt2.X2);
        }
        public static bool operator !=(Dot dt1, Dot dt2)
        {
            return !(dt1.x1 == dt2.x1 && dt1.X2 == dt2.X2);
        }
    }

    class Program
    {   
        public static Dot findMinDot(Dot dt1, ref double h1, ref double h2, bool changeH) // ищет по обеим координатам меньшую точку
        {
            Dot res = dt1;

            if (f(res.x1plush(h1)) < f(res)) // проверяем координату x1 
                res = res.x1plush(h1); // минимизируем функцию за счет нее
            else if (f(res.x1plush(-h1)) < f(res))
                res = res.x1plush(-h1);
            else if (changeH)
                h1 /= 2;

            if (f(res.x2plush(h2)) < f(res)) // проверяем координату x2 
                res = res.x2plush(h2); // минимизируем функцию за счет нее
            else if (f(res.x2plush(-h2)) < f(res))
                res = res.x2plush(-h2);
            else if (changeH)
                h2 /= 2;

            return res;
        }

        public static Dot getDt3(Dot dt1, Dot dt2)
        {
            Dot dt3 = new Dot(dt1.X1 + 2*(dt2.X1 - dt1.X1), dt1.X2 + 2 * (dt2.X2 - dt1.X2));
            return dt3;
        }

        public static double f(Dot dt)
        {
            double x1 = dt.x1;
            double x2 = dt.x2;
            double N = 13.0;
            double res;
            return res = N * Pow(x1, 2) + N * Pow(x2, 2) - N * x1 * x2 + x2;
        }
        static void Main(string[] args)
        {
            double h1 = 0.3;
            double h2 = 0.3;
            double e = 0.001;
            double x1_start = 1.0, x2_start = 1.0;
            bool T = true, F = false;
            Dot dt1 = new Dot(x1_start, x2_start);
            Dot dt2, dt3;



            //Console.WriteLine(dt2.Output());
            //Dot dt3 = getDt3(dt1, dt2);
            //Console.WriteLine(dt3.Output());
            Console.WriteLine("x1\t   x2\t\th1\th2\tf(x1,x2)");
            do
            {
                dt2 = findMinDot(dt1, ref h1, ref h2, T);
                if (dt2 != dt1) // Если получили новую точку, а не остались на той же самой, иначе по диагонали не построим
                {
                    dt3 = getDt3(dt1, dt2);
                    Dot dt4 = findMinDot(dt3, ref h1, ref h2, F);
                    if (dt3 == dt4)
                    {
                        dt1 = dt2;
                        dt2 = dt4;
                    }
                    else
                    {
                        dt1 = dt2;
                    }
                }
                string output = string.Format("{0:f5} | {1:f5} | {2:f5} | {3:f5} | {4:f5}", dt1.X1, dt1.X2, h1, h2, f(dt1));
                Console.WriteLine(output);
            }
            while (h1 > e && h2 > e);
            Console.WriteLine("Ответ: " + dt1.Output());
            Console.ReadKey();
        }
    }
}
