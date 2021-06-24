using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] commSplit = input.Split(" : ").ToArray();

                string courseName = commSplit[0];
                string studentName = commSplit[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses[courseName] = new List<string>();
                }
                courses[courseName].Add(studentName);
            }

            foreach (var item in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                foreach (var kvp in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {kvp}");
                }
            }
        }
    }
}
