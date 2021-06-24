using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Vehicles.Core.Contracts;
using Vehicles.Factories;
using Vehicles.Models;
using VehiclesExtension.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private CreateVehicle createVehicle;
        public Engine()
        {
            this.createVehicle = new CreateVehicle();
        }

        public void Run()
        {
            Vehicle car = this.CreateVehicleFactory();
            Vehicle truck = this.CreateVehicleFactory();
            Vehicle bus = this.CreateVehicleFactory();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                try
                {
                    CommandProcess(car, truck,bus, commArgs);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void CommandProcess(Vehicle car, Vehicle truck,Vehicle bus, string[] commArgs)
        {
            string commType = commArgs[0];
            string vehicleType = commArgs[1];
            double arg = double.Parse(commArgs[2]);

            if (commType == "Drive")
            {
                if (vehicleType == "Car")
                {
                    Console.WriteLine(car.Drive(arg));
                }
                else if (vehicleType == "Truck")
                {
                    Console.WriteLine(truck.Drive(arg));
                }
                else if (vehicleType == "Bus")
                {
                    Console.WriteLine(bus.Drive(arg));
                }
            }
            else if (commType == "Refuel")
            {
                if (vehicleType == "Car")
                {
                    car.Refuel(arg);
                }
                else if (vehicleType == "Truck")
                {
                    truck.Refuel(arg);
                }
                else if (vehicleType == "Bus")
                {
                    bus.Refuel(arg);
                }
            }
            else if (commType == "DriveEmpty")
            {
                bus.AcOnOff = true;
                Console.WriteLine(bus.Drive(arg));
            }
        }

        private Vehicle CreateVehicleFactory()
        {
            string[] vehicleArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string type = vehicleArgs[0];
            double fuelQuantity = double.Parse(vehicleArgs[1]);
            double littersNeeded = double.Parse(vehicleArgs[2]);
            double tankCapacity = double.Parse(vehicleArgs[3]);
            Vehicle vehicle = this.createVehicle.CreateVehicles(type, fuelQuantity, littersNeeded, tankCapacity);
            return vehicle;
        }
    }
}
