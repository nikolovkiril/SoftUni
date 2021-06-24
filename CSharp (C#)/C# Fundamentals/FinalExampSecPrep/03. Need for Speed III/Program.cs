using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var carMileage = new Dictionary<string, int>();
            var carFuel = new Dictionary<string, int>();

            for (int i = 0; i < number; i++)
            {
                string cars = Console.ReadLine();
                string[] split = cars.Split("|");
                string carName = split[0];
                int mileage = int.Parse(split[1]);
                int fuel = int.Parse(split[2]);
                if (!carMileage.ContainsKey(carName) && !carFuel.ContainsKey(carName))
                {
                    carMileage[carName] = mileage;
                    carFuel[carName] = fuel;
                }
            }
            string firstComm;
            while ((firstComm = Console.ReadLine()) != "Stop")
            {
                string[] split = firstComm.Split(" : ");
                string command = split[0];
                string car = split[1];
                if (command == "Drive")
                {
                    int distance = int.Parse(split[2]);
                    int fuel = int.Parse(split[3]);
                    if (carFuel[car] < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else if(carFuel[car] >= fuel)
                    {
                        carMileage[car] += distance;
                        carFuel[car] -= fuel;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    if (carMileage[car] >= 100000)
                    {
                        carFuel.Remove(car);
                        carMileage.Remove(car);
                        Console.WriteLine($"Time to sell the {car}!");
                    }
                }
                else if (command == "Refuel")
                {
                    int fuel = int.Parse(split[2]);
                    
                    if (carFuel[car] + fuel > 75)
                    {
                        Console.WriteLine($"{car} refueled with {75 - carFuel[car]} liters");
                        carFuel[car] = 75;
                    }
                    else
                    {
                        carFuel[car] += fuel;
                        Console.WriteLine($"{car} refueled with {fuel} liters");
                    }
                }
                else if (command == "Revert")
                {
                    int kilometers = int.Parse(split[2]);
                    if (carMileage[car] - kilometers < 10000)
                    {
                        carMileage[car] = 10000;
                    }
                    else
                    {
                        carMileage[car] -= kilometers;
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }
                }
            }
            foreach (var kvp in carMileage.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> Mileage: {kvp.Value} kms, Fuel in the tank: {carFuel[kvp.Key]} lt.");
            }
        }
    }
}
