using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Models.Commands
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND = "Command";
        public CommandInterpreter()
        {
                
        }
        public string Read(string args)
        {
            string[] commandTokens = args.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string commandName = commandTokens[0] + COMMAND;
            string[] commandArgs = commandTokens.Skip(1).ToArray();
            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower());
            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType);

            string result = commandInstance.Execute(commandArgs);
            return result;
        }
    }
}
