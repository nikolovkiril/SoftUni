using System;
using System.Linq;
using Telephony.Models;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numers = Console.ReadLine().Split();
            var url = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();
            foreach (var phoneNumber in numers)
            {
                try
                {
                    if (phoneNumber.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.PhoneNumber(phoneNumber));
                    }
                    else 
                    {
                        Console.WriteLine(smartphone.PhoneNumber(phoneNumber));
                    }
                }
                catch (ArgumentException msg)
                {
                    Console.WriteLine(msg.Message);
                }

            }
            foreach (var currUrl in url)
            {
                try
                {
                    Console.WriteLine(smartphone.Url(currUrl));
                }
                catch (ArgumentException msg)
                {
                    Console.WriteLine(msg.Message);
                }
            }

        }
    }
}
