
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asd_lb4_stack_queue
{
    internal class Queue<T> : IEnumerable<T>  // очередь
    {
        Node<T> head; // головной/первый элемент
        Node<T> tail; // хвост, последний элемент
        int count;  // количество элементов в очереди

        // добавление элемента
        public void Enqueue(T data) // добваление элемента в конец очереди
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
                head = node;
            else
                tail.Down = node;

            tail = node;
            count++;
        }
        // изъять из очереди
        public T Dequeue()
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
