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
            return ($"{x} {y} {fun}");
        }
        public double fun
        {
            get { return N * Pow(x, 2) + N * Pow(y, 2) - N * x * y + y; ; }
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
    }
}
