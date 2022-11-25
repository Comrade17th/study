using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nelder_Mid
{
    internal class Triangle
    {
        Dot[] dots = new Dot[3];
        public Triangle()
        {

        }
        public Triangle(Dot dt0, Dot dt1, Dot dt2)
        {
            dots[0] = dt0; // best
            dots[1] = dt1; // good
            dots[2] = dt2; // worst
        }

        public void Sort()
        {
            Array.Sort(dots);
        }

        public Dot GetDotMiddle() // цетнральная точка на отрезке g b
        {
            Dot dot = new Dot((dots[0].X + dots[1].X) / 2, (dots[0].Y + dots[1].Y) / 2);
            return dot;
        }

        public Dot GetDotReference() // отраженная точка от w к центральной
        {
            Dot mid = GetDotMiddle();
            Dot dot = mid + (mid - dots[2]);
            return dot;
        }
    }
}
