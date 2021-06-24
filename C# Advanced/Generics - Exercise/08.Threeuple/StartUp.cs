using System;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace Threeuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var personNameAndAddress = Console.ReadLine().Split();
            string town;
            string personName = $"{personNameAndAddress[0]} {personNameAndAddress[1]}";
            string address = personNameAndAddress[2];
            if (personNameAndAddress.Length > 4)
            {
                town = $"{personNameAndAddress[3]} {personNameAndAddress[4]}";

            }
            else
            {
                town = personNameAndAddress[3];
            }

            var nameAmountBeer = Console.ReadLine().Split();
            string name = nameAmountBeer[0];
            int amountBeer = int.Parse(nameAmountBeer[1]);
            var drunkOrNot = nameAmountBeer[2] == "drunk" ? true : false;

            var numbers = Console.ReadLine().Split();
            string name1 = numbers[0];
            double accountBalance = double.Parse(numbers[1]);
            string bankName = numbers[2];

            var first = new Tuple<string, string, string>(personName, address, town);
            var sec = new Tuple<string, int, bool>(name, amountBeer, drunkOrNot);
            var third = new Tuple<string, double, string>(name1, accountBalance, bankName);


            Console.WriteLine(first);
            Console.WriteLine(sec);
            Console.WriteLine(third);
        }
    }
}
