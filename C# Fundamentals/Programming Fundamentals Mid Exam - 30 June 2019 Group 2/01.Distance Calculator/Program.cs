using System;

namespace _01.Distance_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsMade = int.Parse(Console.ReadLine());
            double stepsLenght = double.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());

            double stepsMinus = stepsMade / 5;
            double stepsReal = stepsMade - stepsMinus;
            
            stepsReal *= stepsLenght;
            double shortSteps = stepsMinus * (stepsLenght * 0.70);
            double total = stepsReal + shortSteps;
            double percentage = (total / distance) ;
            Console.WriteLine($"You travelled {percentage:f2}% of the distance!");
        }
    }
}
