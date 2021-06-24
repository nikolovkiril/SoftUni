using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {

            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command;

            Func<int, int> addFunc = x => x + 1;
            Func<int, int> multiplyFunc = x => x * 2;
            Func<int, int> subtractFunc = x => x - 1;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "add")
                {
                    numbers = numbers.Select(addFunc).ToList();
                }
                else if (command == "multiply")
                {
                    numbers = numbers.Select(multiplyFunc).ToList();
                }
                else if (command == "subtract")
                {
                    numbers = numbers.Select(subtractFunc).ToList();
                }
                else if (command == "print")
                {
                    foreach (var num in numbers)
                    {
                        Console.Write(num + " ");
                    }
                    Console.WriteLine();
                }
            }
            
        }
    }
}
