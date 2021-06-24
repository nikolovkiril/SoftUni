using System;
using System.Collections.Generic;
using System.Linq;


namespace _01._Unique_Usernames
   
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputLenght = int.Parse(Console.ReadLine());
            var uniqueUsernames = new HashSet<string>();

            for (int i = 0; i < inputLenght; i++)
            {
                string usernames = Console.ReadLine();
                uniqueUsernames.Add(usernames);
            }
            foreach (var user in uniqueUsernames)
            {
                Console.WriteLine(user);
            }
        }
    }
}
