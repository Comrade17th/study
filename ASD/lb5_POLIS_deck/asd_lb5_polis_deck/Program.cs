using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asd_lb5_polis_deck
{
    internal class Program
    {

        static public int calcPolis(string sequence) // в отдельную функцию можно вынести проверку строки на правильнось, но это не надо никому
        {
            int res = 0;
            string[] parts = sequence.Split();
            Stack<int> ints = new Stack<int>();
            for(int i = 0; i < parts.Length; i++)
            {
                int tmp;
                switch(parts[i])
                {
                    case "+":
                        tmp = ints.Pop();
                        ints.Push(ints.Pop() + tmp);
                        break;
                    case "-":
                        tmp = ints.Pop();
                        ints.Push(ints.Pop() - tmp);
                        break;
                    case "/":
                        tmp = ints.Pop();
                        ints.Push(ints.Pop() / tmp);
                        break;
                    case "*":
                        tmp = ints.Pop();
                        ints.Push(ints.Pop() * tmp);
                        break;
                    default:
                        ints.Push(Convert.ToInt32(parts[i]));
                        break;
                }
            }
            res = ints.Pop();
            return res;
        }

        static void Main(string[] args)
        {
            string[] test = {
                "8 9 + 1 7 - *", // - 102
                "3 4 +", // 7
                "7 7 /" // 1
            };
            for (int i = 0; i < test.Length; i++)
                Console.WriteLine($"{test[i]} = {calcPolis(test[i])}");
            Console.ReadKey();

        }
    }
}
