using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodString
{
    public class Box<T> where T : IComparable
    {
        public Box(List<T> integers)
        {
            this.Integers = integers;
        }
        public List<T> Integers { get; set; }
        

        public int CountElements (List<T> elements , T elementsToCompare)
        {
            var count = 0;
            foreach (var element in elements)
            {
                if (elementsToCompare.CompareTo(element) < 0)
                {
                    count++;
                }
            }
            return count;
        }
    }

}
