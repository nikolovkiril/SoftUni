using System;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public string Model { get => this.model; set => this.model = value; }
        public int Weight { get => this.weight; set => this.weight = value; }
        public string Color { get => this.color; set => this.color = value; }
        public Engine Engine { get => this.engine; set => this.engine = value; }
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }
        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight;
        }
        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Color = color;
        }
        public Car(string model, Engine engine, int weight, string color) : this(model, engine, weight)
        {
            this.color = color;
        }
        public override string ToString()
        {
            var weightToStr = this.Weight.Equals(0) ? "n/a" : this.Weight.ToString();
            var colorToStr = String.IsNullOrEmpty(this.Color) ? "n/a" : this.Color;
            return $"{this.Model}:\n  {this.Engine}\n  Weight: {weightToStr}\n  Color: {colorToStr}".ToString();
        }
    }
}
