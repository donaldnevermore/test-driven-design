using System;
using System.Collections.Generic;

namespace MinStack
{
    public class MinStack
    {
        private Stack<int> data;
        private Stack<int> mins;

        public MinStack()
        {
            data = new Stack<int>();
            mins = new Stack<int>();
        }

        public void Push(int num)
        {
            data.Push(num);

            if (mins.Count == 0)
            {
                mins.Push(0);
            }
            else
            {
                int min = GetMin();
                if (num < min)
                {
                    mins.Push(data.Count - 1);
                }
            }
        }

        public int Pop()
        {
            if (data.Count == 0)
            {
                throw new Exception("空栈");
            }

            int popIndex = data.Count - 1;
            int minIndex = mins.ToArray()[mins.Count - 1];

            if (popIndex == minIndex)
            {
                mins.Pop();
            }

            return data.Pop();
        }

        public int GetMin()
        {
            if (mins.Count == 0)
            {
                throw new Exception("空栈");
            }

            int minIndex = mins.ToArray()[mins.Count - 1];
            return data.ToArray()[minIndex];
        }
    }
}
