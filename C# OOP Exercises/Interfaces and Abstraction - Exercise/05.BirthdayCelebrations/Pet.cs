using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Pet : IBirthdates
    {
        public Pet(string name , string birthday)
        {
            this.Name = name;
            this.Birthdates = birthday;
        }

        public string Birthdates { get; private set; }

        public string Name { get; private set; }
    }
}
