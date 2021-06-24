using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Animals
{
    public class Tomcats : Cat
    {
        private const string Gender = "Male"; 
        public Tomcats(string name, int age) 
            : base(name, age, Gender)
        {
            
        }
        public override string ProduceSound()
        {
            return "MEOW!";
        }
    }
}
