using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse);

            var asd = new List<int>(input);

            var numbers = new Queue<int>();

            foreach (var num in asd)
            {
                var curNum = num;
                if (curNum % 2 == 0)
                {
                    numbers.Enqueue(curNum);
                    if (numbers.Count > 1)
                    {
                        Console.Write(numbers.Dequeue() + ", ");

                    }
                }
            }
            Console.WriteLine(numbers.Dequeue());

        }
    }
}
