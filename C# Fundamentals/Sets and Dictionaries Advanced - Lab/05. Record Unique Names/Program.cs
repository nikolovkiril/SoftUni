using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var namesList = new HashSet<string>();
            int inputLenght = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputLenght; i++)
            {
                string name = Console.ReadLine();
                namesList.Add(name);
            }
            foreach (var name in namesList)
            {
                Console.WriteLine(name);
            }
        }
    }
}
