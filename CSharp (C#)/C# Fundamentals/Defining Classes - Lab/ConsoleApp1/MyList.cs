using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MyList
    {
        private int capacity;
        private int[] data;

        public MyList()
            : this(4)
        {
        }

        public MyList(int capacity)
        {
            this.capacity = capacity;
            this.data = new int[capacity];
        }

        public int Count { get; private set; }
        public void Add(int num)
        {
            this.data[this.Count] = num;
            this.Count++;
        }

        public int this[int index]
        {
            get 
            {
                this.ValidateIndex(index);
                return this.data[index]; 
            }
            set
            {
                this.ValidateIndex(index);
                this.data[index] = value; 
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                var massage = this.Count == 0 ? "The list is empty" : $"Valid positions are from {0} to {this.Count - 1}";
                throw new Exception($"INVALID INDEX -> Try again . {massage}");
            }
        }

        public void Clear()
        {
            this.Count = 0;
            this.data = new int[this.capacity];
        }
    }
}
