using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace layer_list
{
    internal class LayerList// : IEnumerable  // односвязный список
    {
        Node head; // головной/первый элемент
        Node tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке

        // добавление элемента
        public void AddEnd(string name, string phone)
        {
            Node node = new Node(name, phone);

            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
                tail.Next2 = node.Next;
            }
            tail = node;

            count++;
        }

        public void prn(string str)
        {
            Console.WriteLine(str);
        }

        public bool AddSort(string name, string phone)
        {
            Node node = new Node(name, phone);
            Node current = head;
            Node previous = null;
            if(head == null)
                head = node;
            else
                while (current != null)
                {
                    // добавить проверку на null
                    int result = String.Compare(node.Name, current.Name);//  0  строки, равны // 1  node стоит после // -1 node стоит до
                    node.Next = current.Next;
                    node.Next2 = current.Next2;
                    if (result == 0)
                    {
                        prn($"sr{0} " + node.GetInfo() + " " + current.GetInfo());
                        if(current.Next == null)
                        {
                            current.Next = node;
                            if (previous.Next2 != null)
                                previous.Next2 = node;
                            return true;
                        }
                        else
                        if (String.Compare(node.Name, current.Next.Name) == -1)
                        {
                            current.Next = node;
                            if (previous.Next2 != null)
                                previous.Next2 = node;
                            return true;
                        }
                    }
                    else
                    if ( result == 1)
                    {
                        prn($"sr{1} " + node.GetInfo() + " " + current.GetInfo());
                        if (current.Next == null)
                        {
                            current.Next = node;
                            if (previous.Next2 != null)
                                previous.Next2 = node;
                            return true;
                        }
                        else
                        if (String.Compare(node.Name, current.Next.Name) == -1)
                        {
                            current.Next = node;
                            if(previous != null)
                                previous.Next2 = node;
                            return true;
                        }
                    }
                    else
                    if(result == -1)
                    {
                        prn($"sr{-1} " + node.GetInfo() + " " + current.GetInfo());
                        if (previous == null)
                        {
                            node.Next = head;
                            node.Next2 = head.Next;
                            head = node;
                            return true;
                        }
                    }
                        previous = current;
                        current = current.Next;
                    }
            
            count++;
            return true;
        }
       



        public void Print()
        {

            Node current = head;
            Console.WriteLine("|||ППППППППППППП|||");
            while (current != null)
            {
                Console.WriteLine($"{current.GetInfo(true)}");
                current = current.Next;
            }
            Console.WriteLine("|||_____________|||");
        }

        // удаление элемента
        public bool Remove(string name, string phone)
        {
            Node current = head;
            Node previous = null;

            while (current != null)
            {
                if (current.Name == name || current.Phone == phone)
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;
                        previous.Next2 = current.Next2;
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
        public int Contains(string name, string phone) // хоть что-то совпадает
        {
            Node current = head;
            int index = -1, currIndex = 0;
            while (current != null)
            {
                if (current.Name == name || current.Phone == phone)
                    return currIndex;
                currIndex++;
                /*
                if (current.Next != null)
                    if (current.Next.Name == name || current.Next.Phone == phone)
                    return currIndex;
                currIndex++;
                if(current.Next2 != null)
                    if (current.Next2.Name == name || current.Next2.Phone == phone)
                        return currIndex;
                currIndex++;
                current = current.Next2;
                */
                current = current.Next;
            }
            return index;
        }
        // добвление в начало
    }
}
