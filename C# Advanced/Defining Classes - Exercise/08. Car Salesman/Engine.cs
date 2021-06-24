using System;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace CarSalesman
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public string Model { get => this.model; set => this.model = value; }
        public int Power { get => this.power; set => this.power = value; }
        public int Displacement { get => this.displacement; set => this.displacement = value; }
        public string Efficiency { get => this.efficiency; set => this.efficiency = value; }

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }
        public Engine(string model, int power, int displacement) : this(model, power)
        {
            this.Displacement = displacement;
        }
        public Engine(string model, int power, string efficiency)
             : this(model, power)
        {
            this.Efficiency = efficiency;
        }
        public Engine(string model, int power, int displacement, string efficiency) : this(model, power, displacement)
        {
            this.Efficiency = efficiency;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            var displacementToStr = this.Displacement.Equals(0) ? "n/a" : this.Displacement.ToString();
            var efficiencyToStr = String.IsNullOrEmpty(this.efficiency) ? "n/a" : this.Efficiency;

            sb.AppendLine($"{this.Model}:")
                .AppendLine($"    Power: {this.Power}")
                .AppendLine($"    Displacement: {displacementToStr}")
                .AppendLine($"    Efficiency: {efficiencyToStr}");

            return sb.ToString().TrimEnd();
        }
    }
}
