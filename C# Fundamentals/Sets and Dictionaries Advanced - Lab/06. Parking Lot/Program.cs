using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            var parkinLot = new HashSet<string>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commSplit = input.Split(", ");
                string command = commSplit[0].ToUpper();
                string carRegNumber = commSplit[1].ToUpper();
                if (command == "IN")
                {
                    parkinLot.Add(carRegNumber);
                }
                else if (command == "OUT")
                {
                    if (parkinLot.Contains(carRegNumber))
                    {
                        parkinLot.Remove(carRegNumber);
                    }
                }
            }
            if (parkinLot.Count > 0)
            {
                foreach (var car in parkinLot)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
