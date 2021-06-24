using Microsoft.VisualBasic.FileIO;

namespace RawData
{
    public class Engine
    {
        private double engineSpeed;
        private double enginePower;
        public double EngineSpeed { get => this.engineSpeed; set => this.engineSpeed = value; }
        public double EnginePower { get => this.enginePower; set => this.enginePower = value; }
        public Engine(double engineSpeed, double enginePower)
        {
            this.engineSpeed = engineSpeed;
            this.enginePower = enginePower;
        }
    }
}
