
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomStack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> data;

        public CustomStack(params T[] data)
        {
            this.data = data.ToList();
        }
        public void Push(params T[] numToAdd)
        {
            this.data.AddRange(numToAdd);
        }
        public T Pop()
        {
            if (this.data.Count == 0)
            {
                throw new ArgumentException ("No elements");
            }
            T ele = this.data[this.data.Count - 1];
            this.data.Remove(ele);
            return ele;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.data.Count - 1; i >= 0; i--)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
