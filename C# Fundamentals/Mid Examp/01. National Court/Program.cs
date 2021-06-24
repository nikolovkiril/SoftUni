using System;

namespace _01._National_Court
{
    class Program
    {
        static void Main(string[] args)
        {
            int efficiency = int.Parse(Console.ReadLine());
            int efficiency1 = int.Parse(Console.ReadLine());
            int efficiency2 = int.Parse(Console.ReadLine());
            int peopleCount= int.Parse(Console.ReadLine());
            int num = efficiency + efficiency1 + efficiency2;
            int peoplePerHour = 0;
            int temp = 0;
            int count = 0;
            for (int i = 1; i <= peopleCount; i++)
            {
                count = i;
                if (i % 4 == 0)
                {
                    continue;
                }
                peoplePerHour = num;
                temp += peoplePerHour;
                if (peopleCount <= temp)
                {
                    break;
                }
            }
                    Console.WriteLine($"Time needed: {count}h.");
        }
    }
}
