using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyList();

            list.Add(10);
            list.Add(29);
            list.Add(21);

            list[0] = 100;
            var num = list[1];
            Console.WriteLine(list[10]);


            var count = list.Count;
            Console.WriteLine(count);

            list.Clear();
            Console.WriteLine($"List after Clear operator = {list.Count}");

            list[2] = 21;
        }
    }
}
