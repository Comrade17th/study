using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;



/*
 Описать структуру с именем NOTE, содержащую следующие поля:
□	фамилия, имя,
□	номер телефона;
□	дата рождения (массив из трех чисел).
Написать программу, выполняющую следующие действия:
□	ввод с клавиатуры данных в список, состоящий из элементов типа NOTE; 
записи должны быть размещены по алфавиту;
□	вывод на экран информации о людях, чьи дни рождения приходятся на месяц,
значение которого введено с клавиатуры;
□	если таких нет, выдать на дисплей соответствующее сообщение.


 */
namespace asd_q1_v13
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            List<NOTE> people = new List<NOTE>();
            while (flag)
            {
                Console.WriteLine("1. Добавить");
                Console.WriteLine("2. Вывести список");
                Console.WriteLine("3. Выбрать месяц");
                Console.WriteLine("0. Выход\n");
                int tmp = Convert.ToInt32(Console.ReadLine());
                switch (tmp)
                {
                    case 1:
                        Console.WriteLine("Введите имя");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите фамилию");
                        string forname = Console.ReadLine();
                        Console.WriteLine("Введите номер телефона");
                        string phonenumber = Console.ReadLine();
                        Console.WriteLine("Введите день рождения");
                        int d = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите месяц рождения\n");
                        int m = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите год рождения\n");
                        int y = Convert.ToInt32(Console.ReadLine());
                        NOTE n = new NOTE(name, forname, phonenumber, d, m, y);
                        people.Add(n);
                        break;
                    case 2:
                        if (people.Count == 0)
                        {
                            Console.WriteLine("Список пуст\n");
                        }
                        else
                        {
                            var ordered = from some in people
                                                  orderby some.name descending
                                                  orderby some.forname descending
                                                  select some;
                            foreach (NOTE p in ordered)
                                p.Print();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Введите месяц");
                        int month = Convert.ToInt32(Console.ReadLine());
                        var selected = from some in people
                                      where some.birthday[1] == month
                                      orderby some.name descending
                                      orderby some.forname descending
                                      select some;
                        foreach (NOTE p in selected)
                            p.Print();
                        break;
                    case 0:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Нет такого пункта меню");
                        break;
                }
            }

        }
    }

    struct NOTE
    {
        public string name;
        public string forname;
        public string phonenumber;
        public int[] birthday;
        public void Print()
        {
            Console.WriteLine($"{name} {forname} {phonenumber} {birthday[0]}:{birthday[1]}:{birthday[2]}");
        }

        public NOTE(string name_, string forname_, string phonenumber_, int d, int m, int y) 
        {
            name = name_;
            forname = forname_;
            phonenumber = phonenumber_;
            birthday = new int[] { d, m, y};
        }
    }
}
