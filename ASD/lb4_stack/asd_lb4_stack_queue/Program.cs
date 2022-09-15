using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace asd_lb4_stack_queue
{
    internal class Program
    {
        static public bool isGood(string sequence)
        {
            string alhabetLeft = "({[";
            string alhabetRight = ")}]";
            bool res = true;
            Stack<char> charStack = new Stack<char>();
            foreach(char c in sequence)
            {
                if ((alhabetLeft + alhabetRight).Contains(c)) // если скобку нашли
                {
                    bool isOk = false;
                    if (alhabetLeft.Contains(c)) // если открывающая то закидываем в стек
                        charStack.Push(c);
                    else // Если нашли закрывающую
                    {
                         char tmp = charStack.Pop(); // достаем из стэка скобку
                        // и смотрим подходят ли они друг другу
                        switch(tmp)
                        {
                            case '(':
                                if(c == ')')
                                    isOk = true;
                                break;
                            case '{':
                                if (c == '}')
                                    isOk = true;
                                break;
                            case '[':
                                if (c == ']')
                                    isOk = true;
                                break;
                        }
                        if (!isOk)
                            res = false;

                    }
                }
                    
            }

            return res;
        }

        static public int[] getRndArr(int count)
        {
            int[] data = new int[count];

            for (int i = 0; i < count; i++)
            {
                data[i] = i;
            }
            /*
            Random random = new Random();
            for (int i = data.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                // обменять значения data[j] и data[i]
                var temp = data[j];
                data[j] = data[i];
                data[i] = temp;
            }
            */
            return data;
        }

        static public bool firstPunchSecond(int first, int second)
        {
            bool flag = false;
            if(first == 0 && second == 9)
                flag = true;
            if (first > second)
                flag = true;
            return flag;
        }

        static void Main(string[] args)
        {


/*Вы идёте от начала строки. Каждый раз, 
 * когда встречаете открывающую скобку - кладёте её в стек.
 * Каждый раз, когда встречаете закрывающую - убираете из стека ранее положенную скобку.

Если нужно убрать скобку из стека, а их там больше не осталось - последовательность неправильная.
Если после разбора строки в стеке остались лишние скобки - последовательность неправильная.
Во всех остальных случаях - правильная.

Так же можно проверять последовательность, в которой есть разные скобки - круглые, квадратные, фигурные и т.п. 
Просто к тем проверкам, которые я описал выше, добавляется ещё проверка на то, 
что забираемая из стека открывающая скобка по форме должна совпадать с той закрывающей, 
которая у вас сейчас встретилась в строке.*/
            List<string> rightSequence = new List<string>();
            List<string> wrongSequence = new List<string>();

            string path = "../../test.txt";
            //string path = "test.txt";
            //string path = @"C:\Users\Comrade\Desktop\Учеба\study\ASD\lb4_stack\asd_lb4_stack_queue\test.txt";
            StreamReader f = new StreamReader(path);
            while (!f.EndOfStream)
            {
                string s = f.ReadLine();
                if (isGood(s))
                    rightSequence.Add(s);
                else
                    wrongSequence.Add(s);
            }
            f.Close();
            foreach (string s in rightSequence)
                Console.WriteLine("right" + s);
            foreach (string s in wrongSequence)
                Console.WriteLine("wrong " + s);
            


            Queue<int> first = new Queue<int>();
            Queue<int> second = new Queue<int>();
            int[] data = getRndArr(10);
            for ( int i = 0; i < data.Length; i++) // раздаем колоду по игрокам
            {
                if(i%2 == 0) first.Enqueue(data[i]);
                else second.Enqueue(data[i]);
            }

            bool flag = true;
            int counter = 20;
            Console.WriteLine("first\tsecond");
            while (flag)
            {
                Console.WriteLine($"{first.Count}->{first.Peek()}\t{second.Count}->{second.Peek()}");
                if (firstPunchSecond(first.Peek(), second.Peek()))
                {
                    Console.WriteLine("win\tlose");
                    first.Enqueue(first.Dequeue());
                    first.Enqueue(second.Dequeue());
                }
                else
                {
                    Console.WriteLine("lose\twin");
                    second.Enqueue(first.Dequeue());
                    second.Enqueue(second.Dequeue());
                }
                if (first.Count == 0)
                    flag = false;
                if (second.Count == 0)
                    flag= false;
                counter--;
                if (counter == 0)
                    flag = false;
            }
            if (first.Count == 0)
                Console.WriteLine("First win the game");
            else
                Console.WriteLine("Second win the game");

            Console.WriteLine("\n____\n");
            foreach (int n in first)
                Console.WriteLine(n);
            Console.WriteLine("____\n");
            foreach (int n in second)
                Console.WriteLine(n);
            Console.WriteLine("____\n");
            Console.ReadKey();
        }
    }
}
