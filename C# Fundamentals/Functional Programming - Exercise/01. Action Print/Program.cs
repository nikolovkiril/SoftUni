using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printName = Console.WriteLine;
            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(printName);
        }
    }
}
