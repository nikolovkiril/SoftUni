using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DEFAULT_FUEL_CONSUPTION = 1.25;
        private double fuelConsumption;
        private double fuel;
        private int horsePower;
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
        public virtual double FuelConsumption => DEFAULT_FUEL_CONSUPTION;
        public double Fuel { get => this.fuel; set => this.fuel = value; }

        public int HorsePower { get => this.horsePower; set => this.horsePower = value; }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption;
        }


    }
}
