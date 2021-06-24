
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public class Person
    {
        private const int Min_Age = 12;
        private const int Max_Age = 90;
        public Person(string fullName,int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }
        [MyRequired]
        public string FullName{ get; set; }
        [MyRange(Min_Age,Max_Age)]
        public int  Age { get; set; }
    }
}
