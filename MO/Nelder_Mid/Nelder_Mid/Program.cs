using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Math;

namespace Nelder_Mid
{
    
    class Program
    {
        

        static void Main(string[] args)
        {
            Dot dt1 = new Dot(0, 5);
            Dot dt2 = new Dot(2, 4);
            Dot dt3 = new Dot(3, 1);
            Dot[] dots = new Dot[3];
            dots[0] = dt1;
            dots[1] = dt2;
            dots[2] = dt3;
            foreach (Dot dot in dots)
            {
                Console.WriteLine($"{dot.X} {dot.Y} {dot.fun}");
            }
            Array.Sort(dots);
            foreach(Dot dot in dots)
            {
                Console.WriteLine($"{dot.X} {dot.Y} {dot.fun}");
            }
            Console.ReadKey();
        }
    }
}
