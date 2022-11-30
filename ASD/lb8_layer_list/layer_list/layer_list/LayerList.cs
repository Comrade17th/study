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

        public void AddSort(string name, string phone)
        {
            Node node = new Node(name, phone);
            Node current = head;
            //Node previous = null;
            if(head == null)
            {
                head = node;
                tail = head;
                count++;
            }
            else
            {
                bool loop = true;
                while (current != null && loop)
                {
                    int[] result = new int[2];
                    //int result = String.Compare(node.Name, current.Name);
                    //  0  строки, равны
                    //  1  node стоит после
                    // -1  node стоит до
                    if (current == head) // проверяем окрестность головы
                    {
                        if(String.Compare(node.Name, current.Name) == -1) // можно ли вставить до
                        {
                            node.Next = head;
                            node.Next2 = head.Next;
                            //head.Next2 = node.Next;
                            head = node;
                            
                            loop = false;
                        }
                        else // после головы
                        {
                            if(current.Next!= null)
                            {
                                int res = String.Compare(node.Name, current.Next.Name);
                                if(res == -1)
                                {
                                    node.Next = current.Next;
                                    node.Next2 = current.Next2;
                                    current.Next = node;
                                    current.Next2 = node.Next;
                                    loop = false;
                                }
                                else if (current.Next2!= null)
                                {
                                    if (String.Compare(node.Name, current.Next2.Name) == -1)
                                    {
                                        node.Next = current.Next2;
                                        node.Next2 = current.Next2.Next;
                                        current.Next.Next = node;
                                        current.Next.Next2 = node.Next;
                                        current.Next2 = node;
                                        loop=false;
                                    }
                                }   
                            }
                        }
                        
                    }
                    else // не голова
                    {
                        if (current.Next != null)
                        {
                            if(current.Next2 != null)
                            {
                                if (String.Compare(node.Name, current.Next2.Name) == -1)
                                {
                                    node.Next = current.Next2;
                                    node.Next2 = current.Next2.Next;
                                    current.Next.Next = node;
                                    current.Next.Next2 = node.Next;
                                    current.Next2 = node;
                                    loop = false;
                                }
                            }
                            else
                            {
                                current.Next.Next = node;
                                current.Next2 = node;
                                tail = node;
                                loop = false;
                            }
                        }
                        
                    }
                    current = current.Next;
                }


            }

                
        }
       



        public void Print()
        {

            Node current = head;
            Console.WriteLine("|||ППППППППППППП|||");
            while (current != null)
            {
                Console.WriteLine($"{current.GetInfo()}");
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
                
                if (current.Next != null)
                    if (current.Next.Name == name || current.Next.Phone == phone)
                    return currIndex;
                currIndex++;
                if(current.Next2 != null)
                    if (current.Next2.Name == name || current.Next2.Phone == phone)
                        return currIndex;
                currIndex++;
                current = current.Next2;
                
                current = current.Next;
            }
            return index;
        }
        // добвление в начало
    }
}
