using System;

namespace asd11
{
    class Program
    {
        static int FindPivot(int[] numbers, int min, int max)
        {
            int pivot = min - 1;
            int temp = 0;
            for (int i = min; i < max; i++)
            {
                if (numbers[i] < numbers[max])
                {
                    pivot++;
                    temp = numbers[pivot];
                    numbers[pivot] = numbers[i];
                    numbers[i] = temp;
                }
            }
            pivot++;
            temp = numbers[pivot];
            numbers[pivot] = numbers[max];
            numbers[max] = temp;

            return pivot;
        }
        static int[] QuickSort(int[] numbers, int min, int max)
        {
            if (min >= max)
            {
                return numbers;
            }
            int pivot = FindPivot(numbers, min, max);
            QuickSort(numbers, min, pivot - 1);
            QuickSort(numbers, pivot + 1, max);

            return numbers;
        }
        static int[] ExtractSort(int[] numbers)
        {
            for(int i = numbers.Length-1; i>0; i--)
            {
                int maxind = 0;
                for(int j =1; j <= i; j++)
                {
                    if (numbers[j] > numbers[maxind])
                        maxind = j;
                }
                int temp = numbers[i];
                numbers[i] = numbers[maxind];
                numbers[maxind] = temp;
            }
            return numbers;
        }
        static void Main(string[] args)
        {
            int[] numbers = { 4, -12, 3, 31, 0, 7, 4, 14, 90, 5 };
            Console.WriteLine("Массив до сортировки");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i]+" ");
            }
            numbers = QuickSort(numbers, 0, numbers.Length - 1);

            Console.WriteLine("\nМассив после быстрой сортировки");
            for (int i =0; i<numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }



            Console.WriteLine("");
            int[] numbers2 = { 4, -12, 3, 31, 0, 7, 4, 14, 90, 5 };
            Console.WriteLine("\nМассив до сортировки");
            for (int i = 0; i < numbers2.Length; i++)
            {
                Console.Write(numbers2[i] + " ");
            }
            numbers2 = ExtractSort(numbers2);
            Console.WriteLine("\nМассив после  сортировки");
            for (int i = 0; i < numbers2.Length; i++)
            {
                Console.Write(numbers2[i] + " ");
            }

            Console.ReadKey();
        }
    }
}
