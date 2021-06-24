using System.ComponentModel.DataAnnotations;
using System.Windows.Markup;

namespace RawData
{
    public class Cargo
    {
        private double cargoWeight;
        private string cargoType;

        public double CargoWeight { get => this.cargoWeight; set => this.cargoWeight = value; }
        public string CargoType { get => this.cargoType; set => this.cargoType = value; }
        public Cargo(double cargoWeight, string cargoType)
        {
            this.cargoWeight = cargoWeight;
            this.cargoType = cargoType;
        }
    }
}
