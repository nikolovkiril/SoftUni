using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {

        private const double FUEL_CONSUMPTION_WITH_AC = 0.9; 
        private const double DEFAULT_TANK_CAPACITY = 0;


        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
       
        public override double FuelConsumption 
        { 
            get => base.FuelConsumption ; 
            protected set => base.FuelConsumption = value + FUEL_CONSUMPTION_WITH_AC; 
        }

        protected override double AdditionalConsumption => FUEL_CONSUMPTION_WITH_AC;
    }
}
