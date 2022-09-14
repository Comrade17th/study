using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.IO;

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

namespace asd_lb4_stack_queue
{
    internal class Program
    {
        public class Node<T>
        {
            public Node(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public Node<T> Down { get; set; }
        }
        public class Stack<T> : IEnumerable<T>  // односвязный список
        {
            Node<T> head; // головной/первый элемент
            int count;  // количество элементов в списке

            // добавление элемента
            public void Push(T data)
            {
                Node<T> node = new Node<T>(data);

                if (head == null)
                {
                    head = node;
                }
                else
                {
                    node.Down = head;
                    head = node;
                }
                count++;
            }
            // удаление элемента
            public T Pop()
            {
                T res = head.Data;
                head = head.Down;
                count--;
                return res;
            }

            public T Peek(T data)
            {
                return head.Data;
            }

            public int Count { get { return count; } }
            public bool IsEmpty { get { return count == 0; } }
            // очистка списка
            public void Clear()
            {
                head = null;
                count = 0;
            }
            // содержит ли список элемент
            public bool Contains(T data)
            {
                Node<T> current = head;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                        return true;
                    current = current.Down;
                }
                return false;
            }

            // реализация интерфейса IEnumerable
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                Node<T> current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Down;
                }
            }
        }

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

        static void Main(string[] args)
        {
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
            Console.ReadKey();
        }
    }
}
