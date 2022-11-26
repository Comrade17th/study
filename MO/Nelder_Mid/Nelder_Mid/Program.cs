using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Math;

namespace Nelder_Mid
{
    
    class Program
    {
        

        static void Main(string[] args)
        {
            Form1 form1 = new Form1();
            Application.EnableVisualStyles();
            Application.Run(form1); // or whatever

            Application.Run(form1);
            Console.ReadKey();
        }
    }
}
