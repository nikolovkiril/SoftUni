using System;
using System.Collections.Generic;
using System.Linq;


namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> vat = n => n * 1.2;

            Console.ReadLine()
                .Split(new[] { ", " },StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(vat)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x:f2}"));
        }
    }
}
