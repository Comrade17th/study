using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace birthday
{
    internal class Program
    {

        static void Main(string[] args)
        {
            double res = 1.0;
            double n = 0.0;
            for(int i = 0; i< 40; i++)
            {
                n++;
                res *= 1.0 - (double) n / 365.0;
                Console.WriteLine($"{n}\t{Round((1 - res) * 100, 2)}%");
                
            }
            Console.ReadKey();
        }
    }
}
