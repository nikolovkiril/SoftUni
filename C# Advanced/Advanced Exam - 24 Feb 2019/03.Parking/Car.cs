using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Parking
{
    public class Car
    {
        private string manufacturer;
        private string model;
        private int year;

        public Car(string manufacturer, string model, int year)
        {
            this.manufacturer = manufacturer;
            this.model = model;
            this.year = year;
        }
        public string Manufacturer   { get => this.manufacturer; set => this.manufacturer = value; }
        public string Model { get => this.model; set => this.model = value; }
        public int Year { get => this.year; set => this.year = value; }
        public override string ToString()
        {
            return $"{manufacturer} {model} ({year})".TrimEnd();
        }
    }
}
