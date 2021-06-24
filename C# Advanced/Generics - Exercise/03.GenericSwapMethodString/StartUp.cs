using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    class StartUp

    {
        static void Main(string[] args)
        {
            var inputLength = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();

            for (int i = 0; i < inputLength; i++)
            {
                var namesInput = Console.ReadLine();

                names.Add(namesInput);
            }
            Box<string> box = new Box<string>(names);
            var swapPosition = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            box.Swap(names, swapPosition[0], swapPosition[1]);
            Console.WriteLine(box);
        }
    }
}
