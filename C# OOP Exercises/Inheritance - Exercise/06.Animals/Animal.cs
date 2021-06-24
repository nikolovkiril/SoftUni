using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;
        public Animal(string name, int age, string gender) 
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }


        public string Name 
        { 
            get => this.name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.name = value;
            }
        }

        public int Age 
        {
            get => this.age;
            private set
            {
                if (value < 0 )
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;
            }
        }

        public string Gender 
        {
            get => this.gender;
            private set
            {
                if ( value != "Male" && value != "Female" )
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{this.GetType().Name}")
                .AppendLine($"{this.Name} {this.Age} {this.Gender}")
                .AppendLine($"{this.ProduceSound()}");
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
