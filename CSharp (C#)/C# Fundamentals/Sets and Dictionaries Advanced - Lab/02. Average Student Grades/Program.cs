using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ivancho 5.20
            //Ivancho -> 5.20 3.20 (avg: 4.20)
            var studentRecords = new Dictionary<string,List<decimal>>();
            int inputLenght = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLenght; i++)
            {
                var inputData = Console.ReadLine().Split();
                string name = inputData[0];
                decimal grade =decimal.Parse(inputData[1]);
                if (!studentRecords.ContainsKey(name))
                {
                    studentRecords[name] = new List<decimal>();
                    studentRecords[name].Add(grade);
                    
                }
                else
                {
                    studentRecords[name].Add(grade);
                }
            }
            foreach (var (nameKey , grade) in studentRecords)
            {
                var allGrade = string.Join(" ", grade.Select(x => x.ToString("f2")));
                Console.Write($"{nameKey} -> ");
                Console.Write($"{allGrade} ");
                Console.WriteLine($"(avg: {grade.Average():f2})");
            }
        }
    }
}
