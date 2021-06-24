using System;
using System.Linq;
using System.Text;

namespace _01._Warrior_s_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            string skill = Console.ReadLine();

            string command;
             while (!(command = Console.ReadLine()).Contains("For Azeroth"))
            {
                string[] commSplit = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (command == "GladiatorStance")
                {
                    skill = skill.ToUpper();
                    Console.WriteLine(skill);
                }
                else if (command == "DefensiveStance")
                {
                    skill = skill.ToLower();
                    Console.WriteLine(skill);
                }
                else if (commSplit[0] == "Dispel")
                {
                    int index = int.Parse(commSplit[1]);
                    char key = char.Parse(commSplit[2]);

                    if (index < skill.Length && index >= 0)
                    {
                        char[] temp = skill.ToCharArray();
                        temp[index] = key;

                        skill = new string(temp);

                        Console.WriteLine("Success!");
                    }
                    else
                    {
                        Console.WriteLine("Dispel too weak.");
                    }
                }
                else if (commSplit[0] == "Target")
                {
                    if (commSplit[1]== "Change")
                    {
                        string substring = commSplit[2];
                        string secondSubstring = commSplit[3];
                        if (skill.Contains(substring))
                        {
                            skill = skill.Replace(substring, secondSubstring);
                            Console.WriteLine(skill);
                        }
                    }
                    else if (commSplit[1] == "Remove")
                    {
                        string substring = commSplit[2];
                        if (skill.Contains(substring))
                        {
                            var index = skill.IndexOf(substring);
                            skill = skill.Remove(index, substring.Length);
                            Console.WriteLine(skill);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Command doesn't exist!");
                    }
                }
                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }
            }
        }
    }
}
