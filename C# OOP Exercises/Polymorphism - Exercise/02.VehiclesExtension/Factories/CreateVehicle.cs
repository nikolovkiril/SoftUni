using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Vehicles.Common;
using Vehicles.Models;
using VehiclesExtension.Models;

namespace Vehicles.Factories
{
    public class CreateVehicle
    {
        public Vehicle CreateVehicles(string type , double fuelQuantity , double fuelConsumption , double tankCapacity)
        {
            Vehicle vehicle = null;
            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption,tankCapacity);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
            if (vehicle == null)
            {
                throw new ArgumentException(ExceptionMsg.InvalidVehicleTypeMsg);
            }
            return vehicle;
        }
    }
}
