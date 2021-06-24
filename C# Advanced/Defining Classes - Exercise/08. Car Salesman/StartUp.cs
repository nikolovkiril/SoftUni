using CarSalesman;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace CarСalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var engineList = new List<Engine>();
            var carList = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                Engine engine = null;
                var inputEngine = Console.ReadLine().Split().ToArray();
                var model = inputEngine[0];
                var power = int.Parse(inputEngine[1]);
                var displacement = 0;
                var efficiency = "";

                if (inputEngine.Length == 2)
                {
                    engine = new Engine(model, power);
                }
                else if (inputEngine.Length == 3)
                {
                    var displacementEngine = inputEngine[2];
                    var isInt = int.TryParse(inputEngine[2], out displacement);
                    if (!isInt)
                    {
                        efficiency = inputEngine[2];
                        engine = new Engine(model, power, efficiency);
                    }
                    else
                    {
                        displacement = int.Parse(inputEngine[2]);
                        engine = new Engine(model, power, displacement);
                    }
                }
                else if (inputEngine.Length == 4)
                {
                    displacement = int.Parse(inputEngine[2]);
                    efficiency = inputEngine[3];
                    engine = new Engine(model, power, displacement, efficiency);
                }
                engineList.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                Car car = null;
                var inputCar = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = inputCar[0];
                Engine engine = engineList.First(e => e.Model == inputCar[1]);
                var weight = 0;
                var color = "";
                if (inputCar.Length == 2)
                {
                    car = new Car(model, engine);
                }
                else if (inputCar.Length == 3)
                {
                    var isInt = int.TryParse(inputCar[2], out weight);
                    if (isInt)
                    {
                        weight = int.Parse(inputCar[2]);
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        color = inputCar[2];
                        car = new Car(model, engine, color);
                    }
                }
                else if (inputCar.Length == 4)
                {
                    weight = int.Parse(inputCar[2]);
                    color = inputCar[3];
                    car = new Car(model, engine, weight, color);
                }
                carList.Add(car);
            }
            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }
        }
    }
}
