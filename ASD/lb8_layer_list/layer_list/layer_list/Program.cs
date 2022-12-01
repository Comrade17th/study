using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Описать класс, реализующий слоенный (разделенный) список, 
предназначенный для хранения фамилий и телефонных номеров. Добавить в 
класс следующие методы:

1.	Добавление элемента в список. 1
2.	Удаление элемента по его значению. 0
3.	Очистка списка.
4.	Поиск номера элемента в списке.

Первоначальное заполнение списка происходит из текстового файла, 
содержащего фамилию и номер телефона. При заполнении списка следует 
группировать его элементы по первоначальной букве фамилии, сортировка 
внутри группы должна быть в алфавитном порядке.

 */



namespace layer_list
{
    class Program
    {
        static void Main(string[] args)
        {
            string names_text = "Мария Даниэль Артем Борис Виктор Стефания Игорь Диана Артём Дмитрий Глеб Пётр";
            
            string[] names = names_text.Split();
            int names_count = names.Length;
            Node[] peoples = new Node[names_count];
            LayerList list = new LayerList();

            for(int i = 0; i < names_count; i++)
            {
                list.AddSort(names[i], $"{i + 8000000}");
                //Console.WriteLine(names[i]);
                //list.Print();
            }
            Console.WriteLine("Созданный список");
            list.Print();

            Console.WriteLine("Поиск");
            for (int i = 0; i < names_count; i++)
            {
                Console.WriteLine($"{names[i]} Индеск: " + list.Contains(names[i], ""));
            }

            Console.WriteLine("Удаление элемента");
            list.Remove("Глеб", "");
            Console.WriteLine("Список после изменения");
            list.Print();

            

            Console.WriteLine("Удаление списка");
            list.Clear();
            Console.WriteLine("Список после изменения");
            list.Print();
            
            Console.ReadKey();

        }
    }
}


