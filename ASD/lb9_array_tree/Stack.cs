using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb9_array_tree
{
    internal class Stack<T> : IEnumerable<T>  // односвязный список
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

        public T Peek()
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
}
