using System;
using System.Collections.Generic;
using System.Text;


namespace CriptoClass
{
    public class LimitedSizeStack<T>
    {
        readonly int limit;
        readonly LinkedList<T> linkedList;
        LinkedList<T> bufflist;
        public LimitedSizeStack(int limit)
        {
            this.linkedList = new LinkedList<T>();
            bufflist = new LinkedList<T>();
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
                var buf = linkedList.First;
                bufflist.AddFirst(buf);
                linkedList.RemoveFirst();
                return buf.Value;
        }
        
         public void Restore()
        {
            while ((bufflist.Count != 0) && (linkedList.Count!=limit))
            {
                linkedList.AddFirst(bufflist.Last);
                bufflist.RemoveLast();
            }
        }

        public int Count { get => linkedList.Count; }
    }
}
