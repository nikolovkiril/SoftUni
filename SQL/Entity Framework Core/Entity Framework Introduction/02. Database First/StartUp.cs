using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new SoftUniContext();
            var print = RemoveTown(db);
            Console.WriteLine(print);


        }
        //03. Employees Full Information

        /* public static string GetEmployeesFullInformation(SoftUniContext context)
         {
             var employees = context.Employees
                 .OrderBy(x => x.EmployeeId)
                 .ToList();

             var sb = new StringBuilder();

             foreach (var employee in employees)
             {
                 sb.AppendLine($"{employee.FirstName} {employee.LastName} " +
                     $"{employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
             }
             var result = sb.ToString().TrimEnd();
             return result ; 
         }*/

        //04. Employees with Salary Over 50 000

        /* public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
         {
             var employeeWithSalaryOver = context.Employees
                 .OrderBy(x => x.FirstName)
                 .Where(x => x.Salary > 50_000)
                 .ToList();

             var sb = new StringBuilder();

             foreach (var employee in employeeWithSalaryOver)
             {
                 sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
             }

             var result = sb.ToString().TrimEnd();

             return result;
         }*/

        //05. Employees from Research and Development

        /*public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employeeWithSalaryOver = context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Salary,
                    Department = x.Department.Name,
                })
                 .ToList();


            var sb = new StringBuilder();

            foreach (var employee in employeeWithSalaryOver)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department} - ${employee.Salary:F2}");
            }

            var result = sb.ToString().Trim();

            return result;
        }*/

        //06. Adding a New Address and Updating Employee

        /*public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAdress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            context.Addresses.Add(newAdress);

            var empoyee = context.Employees.First(x => x.LastName == "Nakov");
            empoyee.Address = newAdress;

            context.SaveChanges();

            var adresses = context.Employees
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .Select(x => x.Address.AddressText)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var adressText in adresses)
            {
                sb.AppendLine(adressText);
            }
            var result = sb.ToString().TrimEnd();
            return result;
        }*/

        //07. Employees and Projects

        /* public static string GetEmployeesInPeriod(SoftUniContext context)
         {
             StringBuilder sb = new StringBuilder();

             var employees = context.Employees
                  .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                  .Take(10)
                  .Select(e => new
                  {
                      e.FirstName,
                      e.LastName,
                      ManagerFirstName = e.Manager.FirstName,
                      ManagerLastName = e.Manager.LastName,
                      Projects = e.EmployeesProjects
                      .Select(ep => new
                      {
                          ProjectName = ep.Project.Name,
                          StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                          EndDate = ep.Project.EndDate.HasValue ?
                          ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished"
                      })
                      .ToList()
                  })
                  .ToList();

             foreach (var employee in employees)
             {
                 sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                 foreach (var project in employee.Projects)
                 {
                     sb.AppendLine($"--{project.ProjectName} - {project.StartDate} - {project.EndDate}");
                 }
             }

             var result = sb.ToString().TrimEnd();
             return result;
         }*/

        //08. Addresses by Town

        /*public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var adresses = context.Addresses
                .OrderByDescending(e => e.Employees.Count())
                .ThenBy(x => x.Town.Name)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .Select(a => new
                {
                    AddresText = a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count()
                })
                .ToList();

           // var employeeCount = context.Employees.Where(x => x.Address.AddressText == adresses).Count();

            foreach (var adress in adresses)
            {
                sb.AppendLine($"{adress.AddresText}, {adress.TownName} - {adress.EmployeeCount} employees");
            }
            var result = sb.ToString().TrimEnd();
            return result;
        }*/

        //  09. Employee 147

        /* public static string GetEmployee147(SoftUniContext context)
         {
             StringBuilder sb = new StringBuilder();

             var employee147 = context.Employees
                 .Select(x => new
                 {
                     EmployeeId = x.EmployeeId,
                     EmployeeFirstName = x.FirstName,
                     EmployeeLastName = x.LastName,
                     JobTitle = x.JobTitle,
                     Projects = x.EmployeesProjects.Select(ep => ep.Project.Name)
                             .OrderBy(ep => ep)
                             .ToList()
                 })
                 .FirstOrDefault(e => e.EmployeeId == 147);

             sb.AppendLine($"{employee147.EmployeeFirstName} " +
                          $"{employee147.EmployeeLastName} - " +
                          $"{employee147.JobTitle}");

             foreach (var project in employee147.Projects)
             {
                 sb.AppendLine($"{project}");
             }

             var result = sb.ToString().TrimEnd();
             return result;
         }*/

        //10. Departments with More Than 5 Employees

        /*public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context.Departments
                .Where(x => x.Employees.Count > 5)
                .OrderBy(ec => ec.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                        .Select(e => new
                        {
                            EmFirstName = e.FirstName,
                            EmLastName = e.LastName,
                            EmJobTitle = e.JobTitle
                        })
                        .OrderBy(e => e.EmFirstName)
                        .ThenBy(e => e.EmLastName)
                        .ToList()
                })
                .ToList();

            foreach (var dep in departments)
            {
                sb.AppendLine($"{dep.DepName} – {dep.ManagerFirstName} {dep.ManagerLastName}");

                foreach (var emp in dep.Employees)
                {
                    sb.AppendLine($"{emp.EmFirstName} {emp.EmLastName}- {emp.EmJobTitle}");
                }
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }*/

        //11. Find Latest 10 Projects

        /*public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    ProjectName = p.Name,
                    ProjectDescription = p.Description,
                    ProjectStartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .OrderBy(p => p.ProjectName)
                .ToList();

            foreach (var proj in projects)
            {
                sb.AppendLine($"{proj.ProjectName}")
                    .AppendLine($"{proj.ProjectDescription}")
                    .AppendLine($"{proj.ProjectStartDate}");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }*/

        //12. Increase Salaries

        /* public static string IncreaseSalaries(SoftUniContext context)
         {
             StringBuilder sb = new StringBuilder();

             context.Employees
                  .Where(e => new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }
                  .Contains(e.Department.Name))
                  .ToList()
                  .ForEach(e => e.Salary *= 1.12M);

             context.SaveChanges();

             var employees = context.Employees
                  .Where(e => new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }
                  .Contains(e.Department.Name))
                  .Select(e => new
                 {
                     EmpFirstName = e.FirstName,
                     EmpLastName = e.LastName,
                     EmpSalary = e.Salary
                 })
                  .OrderBy(e => e.EmpFirstName)
                  .ThenBy(e => e.EmpLastName)
                  .ToList();

             foreach (var emp in employees)
             {
                 sb.AppendLine($"{emp.EmpFirstName} {emp.EmpLastName} (${emp.EmpSalary:f2})");
             }

             var result = sb.ToString().TrimEnd();
             return result;
         }*/

        //13. Find Employees by First Name Starting With Sa

        /* public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
         {
             StringBuilder sb = new StringBuilder();

             context.Employees
                 .Where(e => e.FirstName.StartsWith("Sa"))
                 .Select(e => new
                 {
                     EmpFirstName = e.FirstName,
                     EmpLastName = e.LastName,
                     EmpJob = e.JobTitle,
                     EmpSalary = e.Salary
                 })
                 .OrderBy(e => e.EmpFirstName)
                 .ThenBy(e => e.EmpLastName)
                 .ToList()
                 .ForEach(e => sb.AppendLine($"{e.EmpFirstName} {e.EmpLastName} - {e.EmpJob} - (${e.EmpSalary:f2})"));

             var result = sb.ToString().TrimEnd();
             return result;
         }*/

        //14. Delete Project by Id

        /* public static string DeleteProjectById(SoftUniContext context)
         {
             StringBuilder sb = new StringBuilder();

             var projectsToRemove = context.EmployeesProjects
                  .Where(ep => ep.ProjectId == 2);

             var project = context.Projects
                 .Where(p => p.ProjectId == 2)
                 .First();

             foreach (var ep in projectsToRemove)
             {
                 context.EmployeesProjects.Remove(ep);
             }

             context.Projects.Remove(project);

             context.SaveChanges();

             context.Projects
                 .Take(10)
                 .Select(p => p.Name)
                 .ToList()
                 .ForEach(p => sb.AppendLine($"{p}"));


             var result = sb.ToString().TrimEnd();
             return result;
         }*/

        //15. Remove Town

        public static string RemoveTown(SoftUniContext context)
        {

            var deleteTown = context.Towns
                .First(x => x.Name == "Seattle");

            var deleteAddress = context.Addresses
                .Where(a => a.TownId == deleteTown.TownId);

            int countAddresses = deleteAddress.Count();

            var employees = context.Employees
                .Where(x => deleteAddress.Any(a => a.AddressId == x.AddressId));

            foreach (var emp in employees)
            {
                emp.AddressId = null;
            }

            foreach (var address in deleteAddress)
            {
                context.Addresses.Remove(address);
            }

            context.Towns.Remove(deleteTown);
            context.SaveChanges();



            var result = $"{countAddresses} addresses in {deleteTown.Name} were deleted";
            return result;
        }
    }
}
