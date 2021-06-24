using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int howMany = int.Parse(Console.ReadLine());
            var pplList = new Dictionary<string, int>();
            for (int i = 0; i < howMany; i++)
            {
                var command = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                pplList.Add(command[0], int.Parse(command[1]));
            }
            string command1 = Console.ReadLine();
            int ageToCompare = int.Parse(Console.ReadLine());

            var filter = AgeFilter(command1, ageToCompare);
        }
        static Func<int, bool> AgeFilter(string command1, int ageToCompare)
        {
            if (command1 == "older")
            {
                return x => x >= ageToCompare;
            }
            return x => x < ageToCompare;
        }
        static Action<>
    }
}
