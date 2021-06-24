using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodInteger
{
    public class Box<T>
    {
        public Box(List<T> integers)
        {
            this.Integers = integers;
        }
        public List<T> Integers { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.Integers)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
            return sb.ToString().TrimEnd();
        }
        public void Swap(List<T> items, int firstIndex, int secIndex)
        {
            T temp = items[firstIndex];
            items[firstIndex] = items[secIndex];
            items[secIndex] = temp;
        }
    }

}
