using System;
using System.Linq;
using System.Security;

namespace Tuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var personNameAndAddress = Console.ReadLine().Split();
            string personName = $"{personNameAndAddress[0]} {personNameAndAddress[1]}";
            string address = personNameAndAddress[2];

            var nameAmountBeer = Console.ReadLine().Split();
            string name = nameAmountBeer[0];
            int amountBeer = int.Parse(nameAmountBeer[1]);

            var numbers = Console.ReadLine().Split();
            int integer =int.Parse(numbers[0]);
            double doubles =double.Parse(numbers[1]);

            Tuple<string, string> first = new Tuple<string, string>(personName, address);
            Tuple<string, int> sec = new Tuple<string, int>(name, amountBeer);
            Tuple<int   , double> third = new Tuple<int, double>(integer, doubles);

            Console.WriteLine(first);
            Console.WriteLine(sec);
            Console.WriteLine(third);
        }
    }
}
