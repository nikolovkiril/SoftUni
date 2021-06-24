namespace RawData
{
    public class Tire
    {
        private double tirePressure;
        private double tireAge;
        public double TirePressure { get => this.tirePressure; set => this.tirePressure = value; }
        public double TireAge { get => this.tireAge; set => this.tireAge = value; }
        public Tire(double tirePressure, double tireAge)
        {
            this.tirePressure = tirePressure;
            this.tireAge = tireAge;
        }
    }
}
