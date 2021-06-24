using System;
using System.Collections.Generic;
using System.Linq;

namespace Battle_Manager
{
    class BattleManager
    {
        static void Main()
        {
            Dictionary<string, int> nameAndHealth = new Dictionary<string, int>();
            Dictionary<string, int> nameAndEnergy = new Dictionary<string, int>();

            string commands;

            while ((commands = Console.ReadLine()) != "Results")
            {
                string[] commandArgs = commands.Split(":");
                string command = commandArgs[0];

                if (command == "Add")
                {
                    string personName = commandArgs[1];
                    int health = int.Parse(commandArgs[2]);
                    int energy = int.Parse(commandArgs[3]);

                    if (!nameAndHealth.ContainsKey(personName) && !nameAndEnergy.ContainsKey(personName))
                    {
                        nameAndHealth[personName] = health;
                        nameAndEnergy[personName] = energy;
                    }
                    else
                    {
                        nameAndHealth[personName] += health;
                    }
                }

                else if (command == "Attack")
                {
                    string attackerName = commandArgs[1];
                    string defenderName = commandArgs[2];
                    int damage = int.Parse(commandArgs[3]);

                    if (nameAndHealth.ContainsKey(attackerName) && nameAndHealth.ContainsKey(defenderName))
                    {
                        nameAndHealth[defenderName] -= damage;

                        if (nameAndHealth[defenderName] <= 0)
                        {
                            nameAndHealth.Remove(defenderName);
                            nameAndEnergy.Remove(defenderName);
                            Console.WriteLine($"{defenderName} was disqualified!");
                        }

                        nameAndEnergy[attackerName]--;

                        if (nameAndEnergy[attackerName] == 0)
                        {
                            nameAndHealth.Remove(attackerName);
                            nameAndEnergy.Remove(attackerName);
                            Console.WriteLine($"{attackerName} was disqualified!");
                        }
                    }
                }

                else if (command == "Delete")
                {
                    string username = commandArgs[1];

                    if (nameAndHealth.ContainsKey(username) && nameAndEnergy.ContainsKey(username))
                    {
                        nameAndHealth.Remove(username);
                    }

                    if (username == "All")
                    {
                        nameAndHealth.Clear();
                        nameAndEnergy.Clear();
                    }
                }
            }

            Console.WriteLine($"People count: {nameAndHealth.Count}");

            foreach (var kvp in nameAndHealth.OrderByDescending(health => health.Value)
                .ThenBy(name => name.Key)
                .ToDictionary(a => a.Key, b => b.Value))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} - {nameAndEnergy[kvp.Key]}");
            }
        }
    }
}
