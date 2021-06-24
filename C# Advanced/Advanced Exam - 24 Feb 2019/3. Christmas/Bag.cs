using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private string color;
        private int capacity;
        private List<Present> presents;

        public int Count => this.presents.Count;

        public Bag(string color, int capacity)
        {
            this.color = color;
            this.capacity = capacity;
            this.presents = new List<Present>();
        }

        public string Color { get => this.color; set => this.color = value; }
        public int Capacity { get => this.capacity; set => this.capacity = value; }
        public List<Present> Presents { get => this.presents; set => this.presents = value; }
        public void Add(Present present)
        {
            if (capacity > presents.Count)
            {
                this.presents.Add(present);
            }
        }
        public bool Remove(string name)
        {
            if (presents.Any(x => x.Name == name))
            {
                var currPresent = this.presents.FirstOrDefault(x => x.Name == name);
                presents.Remove(currPresent);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Present GetHeaviestPresent()
        {
            var heaviestPresent = this.presents.OrderByDescending(x => x.Weight).First();
            return heaviestPresent;
        }
        public Present GetPresent(string name)
        {
            var presentName = this.presents.FirstOrDefault(x => x.Name == name);
            return presentName;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{color} bag contains:");
            foreach (Present item in presents)
            {
                sb.AppendLine($"Present {item.Name} for a {item.Gender}");
            }
            return sb.ToString();  
        }
    }
}
