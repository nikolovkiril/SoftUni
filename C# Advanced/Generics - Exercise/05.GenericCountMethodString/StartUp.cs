using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var listOfElements = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                listOfElements.Add(input);
            }
            Box<string> box = new Box<string>(listOfElements);
            var elementToCompare = Console.ReadLine();
            int result = box.CountElements(listOfElements, elementToCompare);
            Console.WriteLine(result);
        }
    }
}
