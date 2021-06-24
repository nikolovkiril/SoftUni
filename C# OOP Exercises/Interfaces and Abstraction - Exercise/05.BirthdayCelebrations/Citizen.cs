using BirthdayCelebrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : ICheckId, IBirthdates
    {
        private int age;
        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdates = birthday;

        }

        public string Id { get; private set; }

        public string Birthdates { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }
    }

}
