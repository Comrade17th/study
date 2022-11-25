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
            dots[0] = dt0;
            dots[1] = dt1;
            dots[2] = dt2;
        }
    }
}
