using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfa_coords_next
{
    internal class Dot
    {
        double x;
        double y;

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
    }
}
