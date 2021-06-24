using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Ivan";
            person.Age = 12;
            Person person1 = new Person();
            person1.Name = "Alex";
            person1.Age = 33;
        }
    }
}
