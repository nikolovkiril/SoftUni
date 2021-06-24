using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split().Select(x => x).Where(x => x.Length <= n).ToList();
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
