using System;

namespace _01._Warrior_s_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            string skill = Console.ReadLine();
            string commands;
            char key = ' ';

            while ((commands = Console.ReadLine()) != "For Azeroth")
            {
                string[] commSplit = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commSplit[0] == "GladiatorStance")
                {
                    skill = ToUpper(skill);
                }
                else if (commSplit[0] == "DefensiveStance")
                {
                    skill = ToLower(skill);
                }
                else if (commSplit[0] == "Dispel")
                {
                    int index = int.Parse(commSplit[1]);
                    char curr = char.Parse(commSplit[2]);
                    if (index < skill.Length && index >= 0)
                    {
                        char[] temp = skill.ToCharArray();
                        key = temp[index];
                        skill = skill.Replace(key, curr);
                        Console.WriteLine("Success!");
                    }

                    else
                    {
                        Console.WriteLine("Dispel too weak.");
                    }
                }
                else if (commSplit[0] == "Target")
                {
                    if (commSplit[1] == "Change")
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

            private static string ToLower(string skill)
            {
                skill = skill.ToLower();
                Console.WriteLine(skill);
                return skill;
            }

            private static string ToUpper(string skill)
            {
                skill = skill.ToUpper();
                Console.WriteLine(skill);
                return skill;
            }
        }
    }
