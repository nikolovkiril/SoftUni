using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int inputLenght = int.Parse(Console.ReadLine());
            var personList = new List<Person>();
            for (int i = 0; i < inputLenght; i++)
            {
                var splitInp = Console.ReadLine().Split();
                var personName = splitInp[0];
                var peronsAge = int.Parse(splitInp[1]);
                Person person = new Person(personName, peronsAge);
                personList.Add(person);
            }
            personList = personList.Where(age => age.Age > 30).OrderBy(p => p.Name).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, personList));
        }
    }
}
