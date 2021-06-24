using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentsGrades = new Dictionary<string, List<double>>();

            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                string name = Console.ReadLine();
                double grades = double.Parse(Console.ReadLine());

                if (!studentsGrades.ContainsKey(name))
                {
                    studentsGrades[name] = new List<double>();
                }
                studentsGrades[name].Add(grades);
            }
            foreach (var item in studentsGrades.OrderByDescending(x => x.Value.Average()))
            {
                if (item.Value.Average() >= 4.5)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
                }
            }
        }
    }
}
