using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
/*
Составить программу для обхода (просмотра) всех вершин двоичного дерева. 
Двоичное дерево реализовать как статическую структуру в виде 
одномерного массива. Три наиболее часто используемых способа обхода 
(прямой, обратный и симметричный обход) запрограммировать как 
отдельные функции. В качестве входного параметра, функции принимают 
одномерный массив (двоичное дерево). 

Примечание: двоичное дерево может иметь произвольное количество узлов. 
Значения узлов заполнить с клавиатуры.


	Pre-order, NLR, прямой 
	Post-order, LRN, симметричный
	In-order, LNR, обратный


 */

namespace lb9_array_tree
{

    internal class node
    {
        public node(int data)
        {
            i = data;
        }
        public int i { get; set; }
        public int left { get { return 2 * i + 1; } }
        public int right { get { return 2 * i + 2; } }
    }


    internal class Program
    {
        static int Log2(int value)
        {
            int log = 31;
            while (log >= 0)
            {
                int mask = (1 << log);
                if ((mask & value) != 0)
                    return (int)log;
                log--;
            }
            return -1;
        }

        public static int GoLeft(int i)
        {
            return 2*i + 1;
        }

        public static int GoRight(int i)
        {
            return 2*i + 2;
        }
        public static int GoUp(int i)
        {
            if (i % 2 == 0)
                return (int)(i - 2) / 2;
            else
                return (int)(i - 1) / 2;
        }

        public static string PreOrder(string[] tree)
        {
            Stack<int> stack = new Stack<int>();
            
            stack.Push(0);
            string result = "";

            while(!stack.IsEmpty)
            {
                int node = stack.Pop();
                Console.Write(node + " ");
                result += tree[node];
                if(GoRight(node) < tree.Length)
                    if (tree[GoRight(node)] != "+")
                    {
                        stack.Push(GoRight(node));
                    }

                if (GoLeft(node) < tree.Length)
                    if (tree[GoLeft(node)] != "+")
                    {
                        stack.Push(GoLeft(node));
                    }
            }
            return result;
        }

        static string contPreOrder(string[] tree)
        {
            Stack<int> stack = new Stack<int>();
            int size = tree.Length;
            int top = 0;
            string res = "";
            while (top != 0 || !stack.IsEmpty)
            {
                if (!stack.IsEmpty)
                {
                    top = stack.Pop();
                }
                while (top != null)
                {
                    //Console.WriteLine(tree[top]);
                    res += tree[top];
                    if(GoLeft(top) < size)
                        if (tree[GoRight(top)] != "+") 
                            stack.Push(GoRight(top));
                    if(GoLeft(top) < size)
                        top = GoLeft(top);
                }
            }
            return res;
        }

        static string contInOrder(string[] tree)
        {
            Stack< int> stack = new Stack<int>();
            int top = 0;
            int size = tree.Length;
            string res = "";
            while (top != 0 || !stack.IsEmpty)
            {
                if (!stack.IsEmpty)
                {
                    top = stack.Pop();
                    //top.treatment();
                    res += tree[top];
                    if(GoRight(top) < size)
                        if (tree[GoRight(top)] != "=")
                            top = GoRight(top);
                    else top = 0;
                }
                while (top != 0)
                {
                    stack.Push(top);
                    if (GoLeft(top) < size)
                        top = GoLeft(top);
                }
            }
            return res;
        }

        public static string InOrder()
        {
            string result = "";

            return result;
        }

        public static int GetDepth(int S)
        {
            return Log2(S + 1);
        }
        
        // n = log2(S + 1) // зависимост глубину дерева от макс кол-ва узлов
        public static int GetSize(int depth) // получает высоту, возвращает размер массива(макс кол-во узлов)
        {
            int q = 2, n = depth;
            return ((int) Pow(q, n) - 1);
        }

        static void Main(string[] args)
        {
            string input = "A1 B2 E2 C3 D3 F3 G3 +4 +4 +4 +4 +4 +4 H4 I4"; // запись вершины 3 символа 123 , 1-название, 2 уровень, 3 - левое(0) / правое (1)
            //input = "A B E C D F G + + + + + + H I";
            input = "F B G A D + I + + C E + + H +";
            // Прямой обход: F, B, A, D, C, E, G, I, H.
            //Центрированный обход: A, B, C, D, E, F, G, H, I.
            //Обратный порядок: A, C, E, D, B, H, I, G, F.
            string[] tree = input.Split();

            //for(int i = 0; i < tree.Length; i++)
            //{
            //    Console.WriteLine(tree[i] + $"{i}");
            //}

            //Console.WriteLine(PreOrder(tree));

            Console.WriteLine(contPreOrder(tree));
            Console.WriteLine(contInOrder(tree));


            Console.ReadKey();
        }
    }
}
