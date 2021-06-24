using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int howMany = int.Parse(Console.ReadLine());
            SortedDictionary<string, int> herosHP = new SortedDictionary<string, int>();
            SortedDictionary<string, int> herosMP = new SortedDictionary<string, int>();
            for (int i = 0; i < howMany; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string heroName = input[0];
                int heroHP = int.Parse(input[1]);
                int heroMP = int.Parse(input[2]);
                herosHP[heroName] = heroHP;
                herosMP[heroName] = heroMP;
            }
            while (true)
            {
                string[] command = Console.ReadLine().Split(" - ").ToArray();
                string heroName = string.Empty;
                int amount = 0;
                switch (command[0])
                {
                    case "CastSpell":
                        heroName = command[1];
                        int neededMP = int.Parse(command[2]);
                        string spellName = command[3];
                        if (herosMP[heroName] >= neededMP)
                        {
                            herosMP[heroName] -= neededMP;
                            Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {herosMP[heroName]} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                        }
                        break;
                    case "TakeDamage":
                        heroName = command[1];
                        int damage = int.Parse(command[2]);
                        string attacker = command[3];
                        if (herosHP[heroName] - damage > 0)
                        {
                            herosHP[heroName] -= damage;
                            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {herosHP[heroName]} HP left!");
                        }
                        else
                        {
                            herosHP.Remove(heroName);
                            herosMP.Remove(heroName);
                            Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        }
                        break;
                    case "Recharge":
                        heroName = command[1];
                        amount = int.Parse(command[2]);

                        if (herosMP[heroName] + amount >= 200)
                        {
                            Console.WriteLine($"{heroName} recharged for {200 - herosMP[heroName]} MP!");
                            herosMP[heroName] = 200;

                        }
                        else
                        {
                            herosMP[heroName] += amount;
                            Console.WriteLine($"{heroName} recharged for {amount} MP!");
                        }
                        break;
                    case "Heal":
                        heroName = command[1];
                        amount = int.Parse(command[2]);
                        if (herosHP[heroName] + amount >= 100)
                        {
                            Console.WriteLine($"{heroName} healed for {100 - herosHP[heroName]} HP!");
                            herosHP[heroName] = 100;

                        }
                        else
                        {
                            herosHP[heroName] += amount;
                            Console.WriteLine($"{heroName} healed for {amount} HP!");
                        }
                        break;
                    case "End":
                        foreach (var hero in herosHP.OrderByDescending(i => i.Value))
                        {
                            Console.WriteLine(hero.Key);

                            Console.WriteLine("  HP: " + hero.Value);
                            Console.WriteLine("  MP: " + herosMP[hero.Key]);
                        }
                        return;
                }
            }
        }

    }
}