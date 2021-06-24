using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Func<string, bool> startsWithCappitalLether = c => char.IsUpper(c[0]);

            Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Where(startsWithCappitalLether)
                .ToList()
                .ForEach(w =>Console.WriteLine(w));
        }
    }
}
