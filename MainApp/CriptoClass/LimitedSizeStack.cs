using System;
using System.Collections.Generic;
using System.Text;


namespace CriptoClass
{
    public class LimitedSizeStack<T>
    {
        readonly int limit;
        readonly LinkedList<T> linkedList;
        public LimitedSizeStack(int limit)
        {
            this.linkedList = new LinkedList<T>();
            this.limit = limit;
        }

        public void Push(T item)
        {
            if (limit > linkedList.Count)
                linkedList.AddLast(item);
            else
            {
                linkedList.RemoveFirst();
                linkedList.AddLast(item);
            }
        }

        public T Pop()
        {
            var buf = linkedList.Last;
            linkedList.RemoveLast();
            return buf.Value;
        }

        public int Count
        {
            get
            {
                return linkedList.Count;
            }
        }
    }
}
