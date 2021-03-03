using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularBuffer
{
    public class LimitedSizeStack<T>
    {
        public T[] OwnStack;
        public int Index;
        public int CountOfItems;
        public int Lim;

        public LimitedSizeStack(int limit)
        {
            OwnStack = new T[limit];
            Index = 0;
            CountOfItems = 0;
            Lim = limit;
        }

        public void Push(T item)
        {
            if (Lim > 0)
            {
                if (Index == OwnStack.Length)
                    Index = 0;
                OwnStack[Index] = item;
                Index++;
                if (CountOfItems < OwnStack.Length)
                    CountOfItems++;
            }
        }

        public T Pop()
        {
            if (Lim > 0)
            {
                Index--;
                if (Index < 0)
                    Index = OwnStack.Length - 1;
                CountOfItems--;
                var a = OwnStack[Index];
                OwnStack[Index] = default(T);
                return a;
            }
            else return default(T);
        }

        public int Count
        {
            get
            {
                if (Lim <= 0)
                    return 0;
                if (CountOfItems < 0) return 0;
                return CountOfItems;
            }
        }
    }
}