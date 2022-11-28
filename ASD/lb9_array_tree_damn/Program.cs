using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb9_array_tree_damn
{
    internal class Program
    {
        public static int GoLeft(int i)
        {
            return 2 * i + 1;
        }

        public static int GoRight(int i)
        {
            return 2 * i + 2;
        }
        public static int GoUp(int i)
        {
            if (i % 2 == 0)
                return (int)(i - 2) / 2;
            else
                return (int)(i - 1) / 2;
        }
        //
        // Вертикальный прямой обход:
        //
        //обрабатываем текущий узел,
        //при наличии правого поддерева добавляем его в стек для
        //последующей обработки.
        //Переходим к узлу левого поддерева.
        //Если левого узла нет, переходим к верхнему узлу из стека.
        static string contPreOrder(string[] tree)
        {
            Stack<int> stack = new Stack<int>();
            int size = tree.Length;
            string res = "";
            int top = 0;
            while (top != -1 || stack.Count != 0)
            {
                if (stack.Count != 0)
                {
                    top = stack.Pop();
                }
                while (top != -1)
                {
                    res += tree[top];
                    if (GoRight(top) < size)
                        if (tree[GoRight(top)] != "+")
                            stack.Push(GoRight(top));
                    if (GoLeft(top) < size)
                        if (tree[GoLeft(top)] != "+")
                            top = GoLeft(top);
                        else
                            top = -1;
                    else
                        top = -1;
                }
            }
            return res;
        }

        //
        //Вертикальный обратный обход: LCR
        //
        //из текущего узла «спускаемся» до самого нижнего левого узла,
        //добавляя в стек все посещенные узлы.
        //Обрабатываем верхний узел из стека.
        //Если в текущем узле имеется правое поддерево,
        //начинаем следующую итерацию с правого узла.
        //Если правого узла нет, пропускаем шаг со спуском
        //и переходим к обработке следующего узла из стека.
        static string contInOrder(string[] tree)
        {
            Stack<int> stack = new Stack<int>();
            int top = 0;
            string res = "";
            int size = tree.Length;
            while (top != -1 || stack.Count != 0)
            {
                if (stack.Count != 0)
                {
                    top = stack.Pop();
                    res += tree[top];
                    if (GoRight(top) < size)
                        if (tree[GoRight(top)] != "+")
                            top = GoRight(top);
                        else
                            top = -1;
                    else 
                        top = -1;
                }
                while (top != -1)
                {
                    stack.Push(top);
                    if (GoLeft(top) < size)
                        if (tree[GoLeft(top)] != "+")
                            top = GoLeft(top);
                        else
                            top = -1;
                    else
                        top = -1;
                }
            }
            return (res);
        }

        //Вертикальный концевой обход:  
        // Другим подходом является «кодирование» непосредственно в очередности стека — при спуске,
        // если у очередного узла позже нужно будет обработать еще правое поддерево, в стек вносится последовательность
        // «родитель, правый узел, родитель».
        // Таким образом, при обработке узлов из стека мы сможем определить,
        // нужно ли нам обрабатывать правое поддерево.
        static string contPostOrder(string[] tree)
        {
            Stack<int> stack = new Stack<int>();
            int size = tree.Length;
            string res = "";
            int top = 0;
            while (top != -1 || stack.Count != 0)
            {
                if (stack.Count != 0)
                {
                    top = stack.Pop();
                    if (stack.Count != 0 && GoRight(top) == stack.Peek())
                    {
                        if(GoRight(top) < size)
                            if (tree[GoRight(top)] != "+")
                                top = stack.Pop();
                    }
                    else
                    {
                        res += tree[top];
                        top = -1;
                    }
                }
                while (top != -1)
                {
                    stack.Push(top);
                    if (GoRight(top) != -1)
                    {
                        if(GoRight(top) < size)
                            if(tree[GoRight(top)] != "+")
                                stack.Push(GoRight(top));
                        stack.Push(top);
                    }
                    if (GoLeft(top) < size)
                        if (tree[GoLeft(top)] != "+")
                            top = GoLeft(top);
                        else
                            top = -1;
                    else
                        top = -1;
                }
            }
            return RemoveDuplicates(res);
        }

        public static string RemoveDuplicates(string input)
        {
            return new string(input.ToCharArray().Distinct().ToArray());
        }

        static void Main(string[] args)
        {
            string input = "A1 B2 E2 C3 D3 F3 G3 +4 +4 +4 +4 +4 +4 H4 I4"; // запись вершины 3 символа 123 , 1-название, 2 уровень, 3 - левое(0) / правое (1)
            input = "A B E C D F G + + + + + + H I";
            input = "F B G A D + I + + C E + + H +";
            // Прямой обход: FBADCEGIH.
            //Центрированный обход: ABCDEFGHI.
            //Обратный порядок: ACEDBHIGF.
            string[] tree = input.Split();
            Console.WriteLine(contPreOrder(tree));
            Console.WriteLine(contInOrder(tree));
            Console.WriteLine(contPostOrder(tree));
            Console.ReadKey();
        }
    }
}
