namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using ProductShop.XmlHelper;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            const string root = "Projects";

            var projectWithTheirTasks = context
                .Projects
                .ToList()
                .Where(x => x.Tasks.Any())
                .Select(x => new ExportProjectModel
                {
                    ProjectName = x.Name,
                    TasksCount = x.Tasks.Count,
                    HasEndDate = x.DueDate.HasValue ? "Yes" : "No",
                    Tasks = x.Tasks.Select(t => new ExportProjectTaskModel
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToList()
                })
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.ProjectName)
                .ToList();


            var projects = XmlConverter.Serialize(projectWithTheirTasks, root);

            return projects;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var mostBusiestEmployees = context
                .Employees
                .ToList()
                .Select(x => new ExportEmployeeModel
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks
                    .Where(et => et.Task.OpenDate >= date).ToList()
                    .OrderByDescending(td => td.Task.DueDate)
                    .ThenBy(t => t.Task.Name)
                    .Select(t => new ExportEmploeeTaskModel
                    {
                        TaskName = t.Task.Name,
                        OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = t.Task.LabelType.ToString(),
                        ExecutionType = t.Task.ExecutionType.ToString()
                    })
                    .ToList()
                })
                .OrderByDescending(x => x.Tasks.Count)
                .ThenBy(x => x.Username)
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(mostBusiestEmployees, Formatting.Indented);
        }
    }
}