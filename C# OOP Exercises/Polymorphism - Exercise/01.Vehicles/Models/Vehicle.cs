using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Text;
using Vehicles.Common;
using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption , double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double TankCapacity { get;  }

        public double FuelQuantity { get; private set; }

        public virtual double FuelConsumption { get; protected set; }       

        public string Drive(double km)
        {
            double fuelNeeded = this.FuelConsumption * km;
            if (this.FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException(string.Format(ExceptionMsg
                    .NotEnoughFuelExceptionMsg,
                    this.GetType().Name));
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
            if (this.TankCapacity - this.FuelQuantity < fuelAmount)
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
