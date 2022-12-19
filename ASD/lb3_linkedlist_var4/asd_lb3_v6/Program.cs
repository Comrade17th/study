using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace asd_lb3_v6
{
    class Program
    {
        public class Node<T>
        {
            public Node(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public Node<T> Next { get; set; }
            public Node<T> Previous { get; set; }
        }

        public class LinkedList<T> : IEnumerable<T>  // односвязный список
        {
            Node<T> head; // головной/первый элемент
            Node<T> tail; // последний/хвостовой элемент
            int count;  // количество элементов в списке

            // добавление элемента
            public void Add(T data)
            {
                Node<T> node = new Node<T>(data);

                if (head == null)
                {
                    head = node;
                    head.Previous = null;
                    head.Next = null;
                }
                else
                {
                    node.Previous = tail;
                    tail.Next = node;
                }
                tail = node;

                count++;
            }

            public void Print()
            {
                Node<T> current = head;
                while (current != null)
                {
                    Console.WriteLine($"{current.Data}");
                    current = current.Next;
                }
            }
            public void PrintLine()
            {
                Node<T> current = head;
                while (current != null)
                {
                    Console.Write($"{current.Data} ");
                    current = current.Next;
                }
                Console.WriteLine();
            }

            //

            public void RemoveLast()
            {
                tail = tail.Previous;
                tail.Next = null;
            }

            // удаление элемента
            public bool Remove(T data)
            {
                Node<T> current = head;
                Node<T> previous = null;

                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        // Если узел в середине или в конце
                        if (previous != null)
                        {
                            // убираем узел current, теперь previous ссылается не на current, а на current.Next
                            previous.Next = current.Next;
                            current.Previous = previous;
                            // Если current.Next не установлен, значит узел последний,
                            // изменяем переменную tail
                            if (current.Next == null)
                                tail = previous;
                        }
                        else
                        {
                            // если удаляется первый элемент
                            // переустанавливаем значение head
                            head = head.Next;
                            head.Previous = null;
                            // если после удаления список пуст, сбрасываем tail
                            if (head == null)
                                tail = null;
                        }
                        count--;
                        return true;
                    }

                    previous = current;
                    current = current.Next;
                }
                return false;
            }

            public int Count { get { return count; } }
            public bool IsEmpty { get { return count == 0; } }
            // очистка списка
            public void Clear()
            {
                head = null;
                tail = null;
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
                    current = current.Next;
                }
                return false;
            }
            // добвление в начало
            public void AppendFirst(T data)
            {
                Node<T> node = new Node<T>(data);
                node.Next = head;
                head.Previous = node;
                head = node;
                if (count == 0)
                    tail = head;
                count++;
            }

            private int max(int a, int b)
            {
                if (a > b) return a;
                else return b;
            }

            public int Calc(LinkedList<int> input)
            {
                Node<int> currentLeft = input.head;
                Node<int> currentRight = input.tail;
                int maxProd = currentLeft.Data * currentRight.Data;
                int max1 = currentLeft.Data;
                int max2 = currentRight.Data;
                int i = count / 2;
                while (i != 0 )
                {
                    i--;
                    int prod = currentLeft.Data * currentRight.Data;
                    if( prod > maxProd )
                    {
                        maxProd = prod;
                        max1 = currentLeft.Data;
                        max2 = currentRight.Data;
                    }
                        
                    //summ += max(Convert.ToInt32(currentRight.Data), Convert.ToInt32(currentLeft.Data));
                    //Console.WriteLine($"{currentLeft.Data} {}");
                    currentLeft = currentLeft.Next;
                    currentRight = currentRight.Previous;
                }
                Console.WriteLine($"{max1} * {max2} = {maxProd}");
                return maxProd;
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
                    current = current.Next;
                }
            }
        }

        public static void Menu()
        {
            Console.WriteLine("" +
                    "1.\tДобавление элемента в конец списка.\n" +
                    "2.\tДобавление элемента в начало списка.\n" +
                    "3.\tУдаление элемента по его значению.\n" +
                    "4.\tОчистка списка.\n" +
                    "5.\tПоиска номера элемента в списке.\n" +
                    "6.\tПросмотр списка.\n" +
                    "7.\tПосчитать максимальное произведение по заданию.\n" +
                    "8.\tРабота с вводом\n" +
                    "0.\tВыход из программы.\n");
        }

        public static bool isTwice(int num)
        {
            bool result = false;
            int tmp = 11;
            for ( int i = 0; i < 10; i++)
            {
                if(tmp == num)
                    result = true;
                tmp += 11;
            }
            return result;
        }

        public static void Dop()
        {
            LinkedList<int> nums = new LinkedList<int>();
            bool loop = true;
            while (loop)
            {
                string tmp = Console.ReadLine();
                if (tmp == ".")
                {
                    loop = false;
                }
                else
                {
                    int input = int.Parse(tmp);
                    if (isTwice(input))
                    {
                        nums.RemoveLast();
                    }
                    nums.Add(input);
                    nums.PrintLine();
                }
                
            }
        }

        static void Main(string[] args)
        {
            
            LinkedList<int> words = new LinkedList<int>();
            int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //int[] input = words.Split();
            foreach (int s in nums)
                words.Add(s);
            bool flag = true;
            Menu();
            int choose = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            while (flag)
            {

                switch (choose)
                {
                    case 0:
                        flag = false;
                        break;
                    case 1:
                        Console.WriteLine("Введите строку для добавления в конец списка");
                        words.Add(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 2:
                        Console.WriteLine("Введите строку для добавления в начало списка");
                        words.AppendFirst(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 3:
                        Console.WriteLine("Введите строку для удаления из списка");
                        words.Remove(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 4:
                        Console.WriteLine("Введите 777 чтобы очистить список");
                        if (Console.ReadLine() == "777")
                            words.Clear();
                        break;
                    case 5:
                        Console.WriteLine("Введите слово индекс которого найти");
                        Console.WriteLine($"{words.Contains(Convert.ToInt32(Console.ReadLine()))}");
                        break;
                    case 6:
                        words.Print();
                        break;
                    case 7:
                        Console.WriteLine(words.Calc(words));
                        break;
                    case 8:
                        Dop();
                        break;
                    default:
                        Console.WriteLine("Нет такого пункта меню");
                        break;
                }

                Menu();
                
                choose = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            }

            

            //Для решения задачи сформируйте двунаправленный список с символьным
            //информационным полем применяя Класс LinkedList<T>.
            //Программа в цикле запрашивает ввести
            //с клавиатуры буквы латинского алфавита.
            //Ввод символов заканчивается,
            //в случае если пользователь вводит «.».
            //Среди вводимых символов могут встречаться не буквы,
            //появление которого означает отмену предыдущего символа.
            //Учитывая вхождение этого символа, сформируйте последовательность 



            /*
            for (int i = 32; i < 127; i++)
            {
                Console.Write($"|{(char)i}-{i}| ");
                if (i != 32 && i % 8 == 0)
                    Console.WriteLine();
            }
            */
            // 65 - 90 A-Z
            // 97 - 122 a-z
            
            Console.ReadKey();
        }// предложения

    }
}
