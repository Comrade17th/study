using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asd_lb5_polis_deck
{
    internal class Deque<T>// : IEnumerable<T>
    {
        Stack<T> leftStack;
        Stack<T> rightStack;
        int count;

        public void Clear()
        {
            leftStack.Clear();
            rightStack.Clear();
            count = 0;
        }

        public void PushBack(T Data)
        {
            leftStack.Push(Data);
            count++;
        }

        public T PeekBack()
        {
            return leftStack.Peek();
        }

        public T PopBack()
        {
            T res;
            if (leftStack.Count() != 0) 
            {
                res = leftStack.Pop();
            }
            else
            {
                int size = rightStack.Count();
                Stack<T> local = null;
                for (int i = 0; i < size / 2; i++)
                    local.Push(rightStack.Pop());
                while (rightStack.Count != 0)
                    leftStack.Push(rightStack.Pop());
                while (local.Count != 0)
                    rightStack.Push(local.Pop());
                res = leftStack.Pop();
            }
            count--;
            return res;    
        }

        public void PushFront(T Data)
        {
            rightStack.Push(Data);
            count++;
        }

        public T PeekFront()
        {
            return rightStack.Peek();
        }

        public T PopFront()
        {
            T res;
            if (rightStack.Count() != 0)
            {
                res = rightStack.Pop();
            }
            else
            {
                int size = leftStack.Count();
                Stack<T> local = null;
                for (int i = 0; i < size / 2; i++)
                    local.Push(leftStack.Pop());
                while (leftStack.Count != 0)
                rightStack.Push(rightStack.Pop());
                while (local.Count != 0)
                    leftStack.Push(local.Pop());
                res = rightStack.Pop();
            }
            count--;
            return res;
        }

    }
}
