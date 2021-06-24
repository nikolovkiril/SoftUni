using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstInput = int.Parse(Console.ReadLine());

            var heroNameHp = new Dictionary<string, int>();
            var heroNameMp = new Dictionary<string, int>();
            string thirdInput;

            for (int i = 0; i < firstInput; i++)
            {
                string secInput = Console.ReadLine();
                string[] split = secInput.Split();
                string name = split[0];
                int hp = int.Parse(split[1]);
                int mp = int.Parse(split[2]);
                if (!heroNameHp.ContainsKey(name) && !heroNameMp.ContainsKey(name))
                {
                    heroNameHp[name] = hp;
                    heroNameMp[name] = mp;
                }
            }
            while ((thirdInput = Console.ReadLine()) != "End")
            {
                string[] commSplit = thirdInput.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string comand = commSplit[0];
                string heroName = commSplit[1];

                if (comand == "CastSpell")
                {
                    int mpNeeded = int.Parse(commSplit[2]);
                    string spellName = commSplit[3];
                    if (heroNameMp[heroName] >= mpNeeded)
                    {
                        heroNameMp[heroName] -= mpNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroNameMp[heroName]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (comand == "TakeDamage")
                {
                    int damage = int.Parse(commSplit[2]);
                    string attacker = commSplit[3];
                    heroNameHp[heroName] -= damage;
                    if (heroNameHp[heroName] > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroNameHp[heroName]} HP left!");
                    }
                    else if (heroNameHp[heroName] <= 0)
                    {
                        heroNameHp.Remove(heroName);
                        heroNameMp.Remove(heroName);
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                }
                else if (comand == "Recharge")
                {
                    int amount = int.Parse(commSplit[2]);
                    if (heroNameMp[heroName] + amount > 200)
                    {
                        Console.WriteLine($"{heroName} recharged for {200 - heroNameMp[heroName]} MP!");
                        heroNameMp[heroName] = 200;
                    }
                    else
                    {
                        heroNameMp[heroName] += amount;
                        Console.WriteLine($"{heroName} recharged for {amount} MP!");
                    }
                }
                else if (comand == "Heal")
                {
                    int amount = int.Parse(commSplit[2]);
                    if (heroNameHp[heroName] + amount > 100)
                    {
                        Console.WriteLine($"{heroName} healed for {100 - heroNameHp[heroName]} HP!");
                        heroNameHp[heroName] = 100;
                    }
                    else
                    {
                        heroNameHp[heroName] += amount;
                        Console.WriteLine($"{heroName} healed for {amount} HP!");
                    }
                }
            }
            foreach (var kvp in heroNameHp.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine($"  HP: {kvp.Value}");
                Console.WriteLine($"  MP: {heroNameMp[kvp.Key]}");
            }
        }
    }
}
