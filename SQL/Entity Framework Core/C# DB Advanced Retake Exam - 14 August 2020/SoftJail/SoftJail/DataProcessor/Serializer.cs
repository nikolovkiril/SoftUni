namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using AutoMapper;
    using SoftJail.DataProcessor.ExportDto;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.Text;
    using System.Collections.Generic;
    using System.IO;
    using SoftJail.Data.Models;
    using AutoMapper.QueryableExtensions;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context
                .Prisoners
                .ToList()
                .Where(p => ids.Any(id => id == p.Id))
                //.ProjectTo<ExportPrisonerDto>(Mapper.Configurationpr)
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                    .ToList().Select(o => new
                    {
                        OfficerName = o.Officer.FullName,
                        Department = o.Officer.Department.Name
                    })
                    .OrderBy(o => o.OfficerName)
                    .ToList(),
                    TotalOfficerSalary = p.PrisonerOfficers.Sum(po => po.Officer.Salary)
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToList();

            var jsonResult = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return jsonResult;

        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var prisoners = context.Prisoners
                .Where(x => prisonersNames.Contains(x.FullName))
                //.ProjectTo<ExportPrisonerDto>()
                .Select(x => new ExportPrisonerDto
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Mails = x.Mails
                        .Select(m => new ExportPrisonerMailDto
                        {
                            ReversedDescription = ReverseString(m.Description)
                        })
                        .ToArray()
                })
                .OrderBy(x => x.FullName)
                .ThenBy(x => x.Id)
                .ToList();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportPrisonerDto>), new XmlRootAttribute("Prisoners"));


            using (StringWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, prisoners, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
        public static string ReverseString(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}