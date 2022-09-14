using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace asd_lb2_v6
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
                    head = node;
                else
                    tail.Next = node;
                tail = node;

                count++;
            }

            public void AddAt(T data, int index)
            {
                Node<T> current = head;
                Node<T> previous = null;
                Node<T> newNode = new Node<T>(data);
                int curr = 0;
                while (curr != count)
                {
                    if (curr == index)
                    {
                        // Если узел в середине или в конце
                        if (previous != null)
                        {
                            newNode.Next = previous.Next;
                            previous.Next = newNode;

                            if (newNode.Next == null)
                                tail = newNode;
                        }
                        else
                        {
                            // если добавляется первый элемент
                            // переустанавливаем значение head
                            newNode.Next = head;
                            head = newNode;
                        }
                        count++;
                        break;
                    }
                    curr++;
                    previous = current;
                    current = current.Next;
                }
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


            public bool RemoveAt(int index)
            {
                Node<T> current = head;
                Node<T> previous = null;
                int curr = 0;
                while (curr != count)
                {
                    if (curr == index) // нашли тот узел
                    {
                        // Если узел в середине или в конце
                        if (previous != null)
                        {
                            // убираем узел current, теперь previous ссылается не на current, а на current.Next
                            previous.Next = current.Next;

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

                            // если после удаления список пуст, сбрасываем tail
                            if (head == null)
                                tail = null;
                        }
                        count--;
                        return true;
                    }
                    curr++;
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
                head = node;
                if (count == 0)
                    tail = head;
                count++;
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
                    "3.\tДобавление элемента в определенную позицию.\n" +
                    "4.\tУдаление элемента по его значению.\n" +
                    "5.\tУдаление элемента по его номеру в односвязном списке.\n" +
                    "6.\tОчистка списка.\n" +
                    "7.\tПоиска номера элемента в списке.\n" +
                    "8.\tПросмотр списка.\n" +
                    "0.\tВыход из программы\n");
        }

        static void Main(string[] args)
        {
            LinkedList<string> words = new LinkedList<string>();
            string stroka = "первое слово и еще какое-то нужно будет добавить";
            string[] input = stroka.Split();
            foreach (string s in input)
                words.Add(s);
            bool flag = true;
            Menu();
            int choose = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            while (flag)
            {
                
                switch(choose)
                {
                    case 0:
                        flag = false;
                        break;
                    case 1:
                        Console.WriteLine("Введите строку для добавления в конец списка");
                        words.Add(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("Введите строку для добавления в начало списка");
                        words.AppendFirst(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("Введите индекс куда вставить элемент");
                        int some = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите строку которую вставить");
                        words.AddAt(Console.ReadLine(), some);
                        break;
                    case 4:
                        Console.WriteLine("Введите строку для удаления из списка");
                        words.Remove(Console.ReadLine());
                        break;
                    case 5:
                        Console.WriteLine("Введите индекс для удаления из списка");
                        words.RemoveAt(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 6:
                        Console.WriteLine("Введите 777 чтобы очистить список");
                        if (Console.ReadLine() == "777")
                            words.Clear();
                        break;
                    case 7:
                        Console.WriteLine("Введите слово индекс которого найти");
                        Console.WriteLine($"{words.Contains(Console.ReadLine())}");
                        break;
                    case 8:
                        words.Print();
                        break;
                    default:
                        Console.WriteLine("Нет такого пункта меню");
                        break;
                }

                Menu();
                choose = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            }
        }
        
    }
}
