using System;
using System.Collections.Generic;

namespace Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());
            Dictionary<string, int> nameAndHp = new Dictionary<string, int>();
            Dictionary<string, int> nameAndMp = new Dictionary<string, int>();

            for (int i = 0; i < numberOfHeroes; i++)
            {
                string newHero = Console.ReadLine();
                string[] newHerSptil = newHero.Split(" ");
                string name = newHerSptil[0];
                int hp = int.Parse(newHerSptil[1]);
                int mp = int.Parse(newHerSptil[2]);
                if (!nameAndHp.ContainsKey(name) && !nameAndMp.ContainsKey(name))
                {
                    nameAndHp[name] = hp;
                    nameAndMp[name] = mp;
                }
            }
            string inputCommand;
            while ((inputCommand = Console.ReadLine()) != "End")
            {
                string[] commSpit = inputCommand.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                if (commSpit[0] == "CastSpell")
                {
                    int MpNeeded = int.Parse(commSpit[2]);
                    string here = commSpit[1];

                    if (nameAndMp[here] >= MpNeeded)
                    {
                        nameAndMp[here] = nameAndMp[here] - MpNeeded;
                        Console.WriteLine($"{here} has successfully cast {commSpit[3]} and now has {nameAndMp[here]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{here} does not have enough MP to cast {commSpit[3]}!");
                    }
                }
                else if (commSpit[0] == "TakeDamage")
                {
                    string here = commSpit[1];
                    int damage = int.Parse(commSpit[2]);
                    if (nameAndHp[here] > 0)
                    {
                        nameAndHp[here] = nameAndHp[here] - damage;
                        Console.WriteLine($"{here} was hit for {damage} HP by {commSpit[3]} and now has {nameAndHp[here]} HP left!");
                    }
                    else
                    {
                        nameAndHp.Remove(here);
                        nameAndMp.Remove(here);
                        Console.WriteLine($"{here} has been killed by {commSpit[3]}!");
                    }
                }
                else if (commSpit[0] == "Recharge")
                {
                    string here = commSpit[1];
                    int mpRechar = int.Parse(commSpit[2]);

                    if (nameAndMp[here] < 200)
                    {
                        nameAndMp[here] = nameAndMp[here] + mpRechar;
                        Console.WriteLine($"{here} recharged for {mpRechar} MP!");
                    }
                }
                else if (commSpit[0] == "Heal")
                {
                    string here = commSpit[1];
                    int mpRechar = int.Parse(commSpit[2]);

                    if (nameAndMp[here] < 200)
                    {
                        nameAndMp[here] = nameAndMp[here] + mpRechar;
                        Console.WriteLine($"{here} healed for {mpRechar} HP!");
                    }
                }
            }
            foreach (var item in nameAndMp)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var kvp in nameAndHp)
                {
                    Console.WriteLine($"{kvp.Value}");
                }

            }
        }
    }
}
