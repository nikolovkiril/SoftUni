using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var inputN = int.Parse(Console.ReadLine());
            Car[] cars = new Car[inputN];
            for (int i = 0; i < inputN; i++)
            {
                var carsInput = Console.ReadLine();
                var carsSplit = carsInput.Split();
                var carModel = carsSplit[0];
                var carFuelAmount = double.Parse(carsSplit[1]);
                var carFuelConsumptionFor1km = double.Parse(carsSplit[2]);
                cars[i] = new Car(carModel, carFuelAmount, carFuelConsumptionFor1km);
            }
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split();
                string model = tokens[1];
                double distance = double.Parse(tokens[2]);

                cars.Where(c => c.model == model).ToList().ForEach(c => c.Drive(distance));
            }
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.model} {car.fuelAmmount:f2} { car.distanceTravelled}");
            }
        }
    }
}
