
using System;
using System.Reflection.Emit;

namespace RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tire;
        public Engine Engine
        {
            get => this.engine;
            set => this.engine = value;
        }
        public Cargo Cargo
        {
            get => this.cargo;
            set => this.cargo = value;
        }
        public Tire[] Tire
        {
            get => this.tire;
            set => this.tire = value;
        }
        public string Model
        {
            get => this.model;
            set => this.model = value;
        }
        public Car(string model, Engine engine, Cargo cargo, Tire[] tire)
        {
            this.model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tire = tire;
        }
    }
}
