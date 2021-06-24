﻿using System;
using CommandPattern.Core;
using CommandPattern.Core.Contracts;
using CommandPattern.Models.Commands;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
            
        }
    }
}