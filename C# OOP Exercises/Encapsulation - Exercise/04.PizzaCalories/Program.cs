using PizzaCalories.Core;
using PizzaCalories.Models;
using System;
using System.Linq;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
