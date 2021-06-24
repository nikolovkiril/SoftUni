using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int inputLenght = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < inputLenght; i++)
            {
                var splitInp = Console.ReadLine().Split();
                var personName = splitInp[0];
                var peronsAge = int.Parse(splitInp[1]);
                Person person = new Person(personName, peronsAge);
                family.AddMember(person);
            }
            Person oldPerson = family.GetOldestMember();
            Console.WriteLine(oldPerson);
        }
    }
}
