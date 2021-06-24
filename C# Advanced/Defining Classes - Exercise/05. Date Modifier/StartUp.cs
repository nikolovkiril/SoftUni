using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            DateModifier dateModifier = new DateModifier();

            double result = DateModifier.GetDifferenceDaysBetween(Console.ReadLine(), Console.ReadLine());
            Console.WriteLine(result);

        }
    }
}
