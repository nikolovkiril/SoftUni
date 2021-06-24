using System;
using WildFarm.Core.Engine;
using WildFarm.Models.Animal;
using WildFarm.Models.Contracts;

namespace WildFarm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new IEngine();
            engine.Run();
        }
    }
}
