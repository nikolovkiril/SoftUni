using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double FUEL_CONSUMPTION_WITH_AC = 0.9;

        public Car(double fuelQuantity, double litersPerKm, double tankCapacity) 
            : base(fuelQuantity, litersPerKm, tankCapacity)
        {

        }
        public override double LitersPerKm 
        { 
            get => base.LitersPerKm; 
            protected set => base.LitersPerKm = value + FUEL_CONSUMPTION_WITH_AC;
        }        
        
    }
}
