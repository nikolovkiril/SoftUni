using System;

namespace _02._Weaponsmith
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] particles = input.Split("|");

            string cmd;
            string[] commanSplit;

            while (!(cmd = Console.ReadLine()).Contains("Done"))
            {
                commanSplit = cmd.Split(" ");

                if (commanSplit[1] == "Left")
                {
                    int positionMove = int.Parse(commanSplit[2]);

                    if (positionMove > 0 && positionMove < particles.Length)
                    {
                        string temp = particles[positionMove];
                        particles[positionMove] = particles[positionMove - 1];
                        particles[positionMove - 1] = temp;
                    }
                }
                else if (commanSplit[1] == "Right")
                {
                    int positionMove = int.Parse(commanSplit[2]);

                    if (positionMove >= 0 && positionMove < particles.Length - 1)
                    {
                        string temp = particles[positionMove];
                        particles[positionMove] = particles[positionMove + 1];
                        particles[positionMove + 1] = temp;
                    }
                }
                else if ( commanSplit[1] == "Odd")
                {
                    for (int i = 0; i < particles.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            Console.Write(particles[i] + " ");
                        }
                    }
                        Console.WriteLine();

                }
                else if (commanSplit[1] == "Even")
                {
                    for (int i = 0; i < particles.Length; i++)
                    {
                        if (i % 2 == 0)
                        {
                            Console.Write(particles[i] + " ");
                        }
                    }
                    Console.WriteLine();

                }

            }
            Console.WriteLine($"You crafted {string.Join("", particles)}!");

        }
    }
}
