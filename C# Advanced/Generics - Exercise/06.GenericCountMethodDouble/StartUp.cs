using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var listOfElements = new List<double>();

            for (int i = 0; i < n; i++)
            {
                var input =double.Parse(Console.ReadLine());
                listOfElements.Add(input);
            }
            Box<double> box = new Box<double>(listOfElements);
            var elementToCompare = double.Parse(Console.ReadLine());
            int result = box.CountElements(listOfElements, elementToCompare);
            Console.WriteLine(result);
        }
    }
}
