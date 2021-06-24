using System;
using System.Linq;
using System.Net.NetworkInformation;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(numbers,(int x,int y) =>
            {
                return (x % 2 == 0 && y % 2 != 0) ? -1 :
                (x % 2 != 0 && y % 2 == 0) ? 1 :
                x.CompareTo(y);
            });
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
