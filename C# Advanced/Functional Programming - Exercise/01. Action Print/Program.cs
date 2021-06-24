using System;
using System.Linq;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printName = Console.WriteLine;
            Console.ReadLine()
                .Split(new[] {" "},StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(printName);
            
        }
    }
}
