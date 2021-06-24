using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            this.make = make;
            this.model = model;
            this.horsePower = horsePower;
            this.registrationNumber = registrationNumber;
        }
        public string Make { get => this.make; set => this.make = value; }
        public string Model { get => this.model; set => this.model = value; }
        public int HorsePower { get => this.horsePower; set => this.horsePower = value; }
        public string RegistrationNumber { get => this.registrationNumber; set => this.registrationNumber = value; }
        public override string ToString()
        {
            return $"Make: {make}" + Environment.NewLine +
                $"Model: {model}" + Environment.NewLine +
                $"HorsePower: {horsePower}" + Environment.NewLine +
                $"RegistrationNumber: {registrationNumber}";
        }
    }
}
