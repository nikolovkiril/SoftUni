using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Vehicles.Core.Contracts;
using Vehicles.Factories;
using Vehicles.Models;

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
                    string commType = commArgs[0];
                    string vehicleType = commArgs[1];
                    double arg = double.Parse(commArgs[2]);
                    switch (vehicleType)
                    {
                        case nameof(Car):
                            CommandProcess(car, commType, arg);
                            break;
                        case nameof(Truck):
                            CommandProcess(truck, commType, arg);
                            break;
                        case nameof(Bus):
                            CommandProcess(bus, commType, arg);
                            break;
                    }
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

        private static void CommandProcess(Vehicle vehicle, string command, double value)
        {
            switch (command)
            {
                case "Drive":
                    Console.WriteLine(vehicle.Drive(value));
                    break;
                case "Refuel":
                    try
                    {
                        vehicle.Refuel(value);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "DriveEmpty":
                    ((Bus)vehicle).SwitchOffAC();
                    Console.WriteLine(vehicle.Drive(value));
                    ((Bus)vehicle).SwitchOnAC();
                    break;
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
