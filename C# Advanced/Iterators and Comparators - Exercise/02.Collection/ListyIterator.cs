using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> elements;
        private int index;
        public ListyIterator(List<T> elements)
        {
            this.elements = elements;
            this.index = index;
        }
        public bool Move()
        {
            bool hasNext = this.HasNext();
            if (hasNext)
            {
                this.index++;
            }
            return hasNext;
        }
        public bool HasNext()
        {

            if (this.index < this.elements.Count - 1)
            {
                return true;
            }
            return false;
        }
        public void Print()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(this.elements[this.index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in this.elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
