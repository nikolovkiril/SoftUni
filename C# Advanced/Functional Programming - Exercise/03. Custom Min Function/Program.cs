using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(minFunc(numbers));
        }
        static Func<int[], int> minFunc = n =>
        {
            int min = n[0];
            for (int i = 1; i < n.Length; i++)
            {
                if (min > n[i])
                {
                    min = n[i];
                }
            }
            return min;
        };
    }
}
