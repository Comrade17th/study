using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Nelder_Mid
{
    internal class Dot: IComparable<Dot>
    {
        double x;
        double y;
        const double N = 13.0;

        public Dot()
        {
            
        }

        public Dot(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public string GetInfo()
        {
            return ($"{Math.Round(x,3)} {Math.Round(y, 3)} {Math.Round(fun, 3)}");
        }
        public double fun
        {
            get { return N * Pow(x, 2) + N * Pow(y, 2) - N * x * y + y; ; }
        }

        public double eps
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y);
            }
        }

        public Dot deltaFun
        {
            get
            {
                Dot dot = new Dot(x, y);
                dot.X = N * 2 * x - N * y;
                dot.Y = N * 2 * y - N * y + 1;
                return dot;
            }
        }

        public int CompareTo(Dot dot)
        {
            if (dot is null) throw new ArgumentException("Некорректное значение параметра");
            return (int)(fun - dot.fun);
        }

        public static Dot operator +(Dot dot1, Dot dot2)
        {
            return new Dot { x = dot1.x + dot2.x, y = dot1.y + dot2.y };
        }

        public static Dot operator -(Dot dot1, Dot dot2)
        {
            return new Dot { x = dot1.x - dot2.x, y = dot1.y - dot2.y };
        }

        public static Dot operator -(Dot dot1, int num)
        {
            return new Dot { x = dot1.x - num, y = dot1.y - num };
        }

        public static Dot operator -(Dot dot1, double num)
        {
            return new Dot { x = dot1.x - num, y = dot1.y - num };
        }

        public static Dot operator *(Dot dot1, int num)
        {
            return new Dot { x = dot1.x *num, y = dot1.y * num };
        }
        public static Dot operator *(int num, Dot dot1)
        {
            return new Dot { x = dot1.x * num, y = dot1.y * num };
        }

        public static Dot operator *(Dot dot1, double num)
        {
            return new Dot { x = dot1.x * num, y = dot1.y * num };
        }
        public static Dot operator *(double num, Dot dot1)
        {
            return new Dot { x = dot1.x * num, y = dot1.y * num };
        }
    }
}
