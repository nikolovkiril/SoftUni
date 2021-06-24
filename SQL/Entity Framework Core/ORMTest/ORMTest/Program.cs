using ORMTest.Model;
using System;
using System.Linq;

namespace ORMTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new SoftuniContext();
            var employees = dbContext.Employees.ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine((employee.FirstName + ' ' + employee.LastName) +
                    " -- " + (employee.Manager.FirstName) + " -- " + employee.Salary);
            }
        }
    }
}
