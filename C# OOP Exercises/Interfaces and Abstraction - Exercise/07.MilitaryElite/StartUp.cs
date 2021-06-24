using MilitaryElite.IO;
using MilitaryElite.IO.Contracts;
using P07.MilitaryElite.Core;
using System;

namespace MilitaryElite
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader,writer);
            engine.Run();
        }
    }
}
