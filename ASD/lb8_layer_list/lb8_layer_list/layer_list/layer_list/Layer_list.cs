using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;


namespace layer_list
{
    public class LayerList<T> : IEnumerable<T>  // односвязный список
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
                Console.Write($"{current.Data}");
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

        public int Calc()
        {
            int summ = 0;
            Node<T> currentLeft = head;
            Node<T> currentRight = tail;
            int i = count / 2;
            while (i != 0)
            {
                i--;
                summ += max(Convert.ToInt32(currentRight.Data), Convert.ToInt32(currentLeft.Data));
                //Console.WriteLine($"{currentLeft.Data} {}");
                currentLeft = currentLeft.Next;
                currentRight = currentRight.Previous;
            }
            return summ;
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
}
