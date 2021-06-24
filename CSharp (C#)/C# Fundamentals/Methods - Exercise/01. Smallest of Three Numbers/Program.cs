using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int one = int.Parse(Console.ReadLine());
            int two = int.Parse(Console.ReadLine());
            int three = int.Parse(Console.ReadLine());

            int smallest = SmallestNum(one, two, three);
            Console.WriteLine(smallest);

        }

        static int SmallestNum(int a, int b, int c)
        {
            int smallest = 0;
            if (a < b && a < c)
            {
                smallest = a;
            }
            else if (b < a && b < c)
            {
                smallest = b;
            }
            else
            {
                smallest = c;
            }
            return smallest;
        }
    }  
}
