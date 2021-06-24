using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Common;
using Vehicles.Models.Contracts;

namespace VehiclesExtension.Models
{
    public class Vehicle : IDriveable, IRefuelable
    {
        public Vehicle(double fuelQuantity, double litersPerKm, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            this.LitersPerKm = litersPerKm;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; protected set; }
        public virtual double LitersPerKm { get; protected set; }
        public double TankCapacity { get; }
        public virtual bool AcOnOff { get; set; }

        public virtual string Drive(double km)
        {
            double fuelNeeded = km * this.LitersPerKm;
            if (this.FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException(string.Format
                    (ExceptionMsg.NotEnoughFuelExceptionMsg, this.GetType().Name));
            }
            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {km} km";

        }

        public virtual void Refuel(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                throw new InvalidOperationException(ExceptionMsg.FuelMustBePositiveExceptionMsg);
            }
            if (this.TankCapacity < fuelAmount + this.FuelQuantity)
            {
                throw new InvalidOperationException(string.Format(ExceptionMsg.TankCapacityExceptionMsg, fuelAmount));
            }
            this.FuelQuantity += fuelAmount;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
