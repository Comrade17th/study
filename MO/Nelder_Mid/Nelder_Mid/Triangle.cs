using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nelder_Mid
{
    internal class Triangle
    {
        double alfa = 1, beta = 0.5, gamma = 2;
        double eps = 0.001;
        public Dot[] dots = new Dot[3];
        public Triangle()
        {

        }
        public Triangle(Dot dt0, Dot dt1, Dot dt2)
        {
            dots[0] = dt0; // b best
            dots[1] = dt1; // g good
            dots[2] = dt2; // w worst
        }

        public double Square
        {
            get { return (0.5*Math.Abs((dots[1].X - dots[0].X)*(dots[2].Y - dots[0].Y) - (dots[2].X - dots[0].X) * (dots[1].Y - dots[0].Y) )); }
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

        public Dot GetDotReflected() // отраженная точка от w к центральной
        {
            Dot mid = GetDotMiddle();
            Dot xr = mid + (mid - dots[2]);
            return xr;
        }

        public Dot GetDotExpended() // растежения точка от центральной к отраженной
        {
            Dot mid = GetDotMiddle();
            Dot xr = GetDotReflected();
            Dot xe = mid + gamma *(xr - mid);
            return xe;
        }

        public Dot GetDotContracted() // точка сжатия
        {
            Dot mid = GetDotMiddle();
            Dot xc = mid + dots[2];
            return xc * beta;
        }

        public void Srink() // сокращение
        {
            dots[1] = (dots[0] + dots[1]) * beta;
            dots[2] = (dots[0] + dots[2]) * beta;
        }

        public bool isEnd()
        {
            if (Square < eps)
                return true;
            else
                return false;
        }

        public bool isEndBest()
        {
            if (dots[0].fun < eps)
                return true;
            else
                return false;
        }

        public string GetFullInfo()
        {
            
            string res = "";
            res += $"Best X: {Math.Round(dots[0].X, 5)} Y: {Math.Round(dots[0].Y,5)} F: {Math.Round(dots[0].fun, 5)}\n";
            res += $"Good X: {Math.Round(dots[1].X, 5)} Y: {Math.Round(dots[1].Y,5)} F: {Math.Round(dots[1].fun,5)}\n";
            res += $"Worst X: {Math.Round(dots[2].X, 5)} Y: {Math.Round(dots[2].Y,5)} F: {Math.Round(dots[2].fun,5)}\n";
            res += $"Square: {Math.Round(Square, 5)} Eps: {Math.Round(eps,5)}\n";
            return res;
        }
    }
}
