using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Vehicles.Common;

namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double FUEL_CONSUMPTION_WITH_AC = 1.4;

        public Bus(double fuelQuantity, double litersPerKm, double tankCapacity)
            : base(fuelQuantity, litersPerKm, tankCapacity)
        {

        }
        public override string Drive(double km)
        {
            double fuelNeeded = km * this.LitersPerKm;

            if (!AcOnOff)
            {
                fuelNeeded = km * (this.LitersPerKm + FUEL_CONSUMPTION_WITH_AC);

                if (this.FuelQuantity < fuelNeeded)
                {
                    throw new InvalidOperationException(string.Format
                        (ExceptionMsg.NotEnoughFuelExceptionMsg, this.GetType().Name));
                }
            }
            if (base.FuelQuantity >= fuelNeeded)
            {
                base.FuelQuantity -= fuelNeeded;
                return $"{this.GetType().Name} travelled {km} km";
            }
            else
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMsg.NotEnoughFuelExceptionMsg, this.GetType().Name));
            }
            return $"{this.GetType().Name} travelled {km} km";
        }

    }
}
