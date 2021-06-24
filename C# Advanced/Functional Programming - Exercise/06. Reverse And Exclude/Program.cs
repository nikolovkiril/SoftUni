using System;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).Reverse().ToList();
            int n = int.Parse(Console.ReadLine());
            numbers = numbers.Where(x => x % n != 0).ToList();
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
