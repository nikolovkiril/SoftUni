namespace _01.DataTypes
{
    using System;

    public class Program
    {
        public static void Main()
        {
            PrintResult();
        }
        static void PrintResult()
        {
            string firstInput = Console.ReadLine();

            if (firstInput == "int")
            {
                int two = int.Parse(Console.ReadLine());
                Console.WriteLine($"{two * 2}");
            }
            if (firstInput == "real")
            {
                double one = double.Parse(Console.ReadLine());
                Console.WriteLine($"{one * 1.5:f2}");
            }
            if (firstInput == "string")
            {
                string input = Console.ReadLine();
                Console.WriteLine($"${input}$");
            }
        }
    }
}