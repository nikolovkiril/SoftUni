using FoodShortage.Core;
using System;

namespace FoodShortage.Model
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
