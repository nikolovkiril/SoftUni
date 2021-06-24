using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private const int PERSON_MIN_AGE = 0;

        private string name;
        private int age;
        public Person(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }
        public string Name { get => this.name; private set => this.name = value; }

        public virtual int Age
        {
            get => this.age;

            protected set
            {
                if (value >= PERSON_MIN_AGE)
                {
                    this.age = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));

            return stringBuilder.ToString().Trim();
        }

    }
}
