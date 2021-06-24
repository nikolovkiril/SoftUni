using System;
using System.Collections.Generic;
using System.Text;

namespace Christmas
{
    public class Present
    {
        private string name;
        private double weight;
        private string gender;
        public Present(string name, double weight, string gender)
        {
            this.name = name;
            this.weight = weight;
            this.gender = gender;
        }
        public string Name { get => this.name; set => this.name = value; }
        public double Weight { get => this.weight; set => this.weight = value; }
        public string Gender { get => this.gender; set => this.gender = value; }

        public override string ToString()
        {
            return $"Present {name} ({weight}) for a {gender}";
        }
    }
}
