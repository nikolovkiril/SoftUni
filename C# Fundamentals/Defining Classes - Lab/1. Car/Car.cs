using System;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "Vw";
            car.Model = "MK3";
            car.Year = 1992;
            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
        }
    }
}
