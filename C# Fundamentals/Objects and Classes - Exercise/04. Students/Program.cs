using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            string cmd;
            string[] commandSplit;
            for (int i = 0; i < countOfStudents; i++)
            {
                cmd = Console.ReadLine();
                commandSplit = cmd.Split(' ');
                float num = float.Parse(commandSplit[2]);
                Student firstStudent = new Student(commandSplit[0], commandSplit[1], num);

                students.Add(firstStudent);
                //Console.WriteLine(firstStudent);
            }
            students.OrderByDescending(t => t.Grade).ThenBy(t => t.FirstName).ToList();
            List<Student> sortedStudents = students.OrderByDescending(t => t.Grade).ThenBy(t => t.FirstName).ThenBy(t => t.LastName).ToList();

            foreach (Student t in sortedStudents)
            {
                Console.WriteLine($"{t.FirstName} {t.LastName}: {t.Grade:f2}");
            }
        }
    }
    class Student
    {
        public Student(string firstName, string lastName, float grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Grade { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} {this.Grade:f2}";
        }
    }
}
