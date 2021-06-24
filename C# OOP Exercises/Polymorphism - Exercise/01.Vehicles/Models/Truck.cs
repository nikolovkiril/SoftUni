namespace Vehicles.Models
{
    public class Truck : Vehicle
    {

        private const double FUEL_CONSUMPTION_WITH_AC = 1.6;
        private const double REFUEL_DIFFERENCE = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            protected set => base.FuelConsumption = value + FUEL_CONSUMPTION_WITH_AC;
        }

        protected override double AdditionalConsumption => FUEL_CONSUMPTION_WITH_AC;

        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount * REFUEL_DIFFERENCE);
        }
    }
}
