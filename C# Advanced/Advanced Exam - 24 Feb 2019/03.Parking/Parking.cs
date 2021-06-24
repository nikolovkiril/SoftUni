using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        private string type;
        private int capacity;
        public int Count => this.data.Count;

        public Parking(string type, int capacity)
        {
            this.type = type;
            this.capacity = capacity;
            this.data = new List<Car>();
        }
        public string Type { get => this.type; set => this.type = value; }
        public int Capacity { get => this.capacity; set => this.capacity = value; }
        public void Add(Car car)
        {
            if (capacity > data.Count)
            {
                this.data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            int index = data.FindIndex(n => (n.Manufacturer == manufacturer && n.Model == model));
            if (index >= 0)
            {
                data.RemoveAt(index);
                return true;
            }

            return false;
        }
    
        public Car GetLatestCar()
        {
            if (data.Any())
            {
                return data.OrderByDescending(n => n.Year).First();
            }

            return null;
        }
        public Car GetCar(string manufacturer, string model)
        {
            int index = data.FindIndex(n => (n.Manufacturer == manufacturer && n.Model == model));

            if (index >= 0)
            {
                return data[index];
            }

            return null;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {type}:");
            foreach (Car item in this.data)
            {
                sb.AppendLine($"{item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
