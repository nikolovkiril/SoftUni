using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Common;

namespace VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double FUEL_CONSUMPTION_WITH_AC = 1.6;
        private const double REFUEL_DIFFERENCE = 0.95;

        public Truck(double fuelQuantity, double litersPerKm, double tankCapacity)
            : base(fuelQuantity, litersPerKm, tankCapacity)
        {
        }
        public override double LitersPerKm
        {
            get => base.LitersPerKm;
            protected set => base.LitersPerKm = value + FUEL_CONSUMPTION_WITH_AC;
        }
        public override void Refuel(double fuelAmount)
        {
            if (this.TankCapacity < fuelAmount + this.FuelQuantity)
            {
                throw new InvalidOperationException(string.Format(ExceptionMsg.TankCapacityExceptionMsg, fuelAmount));
            }
            if (fuelAmount <= 0)
            {
                throw new InvalidOperationException(ExceptionMsg.FuelMustBePositiveExceptionMsg);
            }
            base.Refuel(fuelAmount * REFUEL_DIFFERENCE);
        }

    }
}
