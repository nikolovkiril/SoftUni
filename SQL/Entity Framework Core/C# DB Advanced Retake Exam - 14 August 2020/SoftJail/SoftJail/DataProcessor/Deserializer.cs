namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using ProductShop.XmlHelper;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportDepartmentDto[] departmentDtos = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            List<Department> departments = new List<Department>();

            foreach (var departmentDto in departmentDtos)
            {
                if (!IsValid(departmentDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                Department department = new Department()
                {
                    Name = departmentDto.Name
                };

                var cells = new List<Cell>();

                foreach (var cellDto in departmentDto.Cells)
                {

                    if (!IsValid(cellDto))
                    {
                        cells = new List<Cell>(); // to trigger the bottom check ?
                        break;
                    }

                    Cell cell = new Cell()
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    };
                    cells.Add(cell);


                }
                if (!cells.Any())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                department.Cells = cells;
                departments.Add(department);
                sb.AppendLine($"Imported {departmentDto.Name} with {cells.Count} cells");
            };
            context.Departments.AddRange(departments);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportPrisonerDto[] importPrisonerDtos = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            List<Prisoner> prisoners = new List<Prisoner>();

            foreach (var prisonerMailDto in importPrisonerDtos)
            {
                if (!IsValid(prisonerMailDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isIncarcerationDateValid = DateTime.TryParseExact(prisonerMailDto.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out var incarcerationDate);

                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime? releaseDate = null;

                if (!String.IsNullOrEmpty(prisonerMailDto.ReleaseDate))
                {
                    var isReleaseDateValid = DateTime.TryParseExact(prisonerMailDto.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out var releaseDateValue);

                    if (!isReleaseDateValid)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    releaseDate = releaseDateValue;
                }

                Prisoner prisoner = new Prisoner()
                {
                    FullName = prisonerMailDto.FullName,
                    Nickname = prisonerMailDto.Nickname,
                    Age = prisonerMailDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerMailDto.Bail,
                    CellId = prisonerMailDto.CellId
                };

                foreach (var mailDto in prisonerMailDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    prisoner.Mails.Add(new Mail
                    {
                        Address = mailDto.Address,
                        Description = mailDto.Description,
                        Sender = mailDto.Sender
                    });
                }
                prisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            const string root = "Officers";
            StringBuilder sb = new StringBuilder();

            var ImportOfficerDtos = XmlConverter.Deserializer<ImportOfficerDto>(xmlString,root);

            List<Officer> officers = new List<Officer>();

            foreach (var ImportOfficerDto in ImportOfficerDtos)
            {
                if (!IsValid(ImportOfficerDto))
                {
                    sb.AppendLine("");
                    continue;
                }
                bool isValidPosition = Enum.TryParse(ImportOfficerDto.Position, out Position position);
                
                if (!isValidPosition)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                bool isValidWeapon = Enum.TryParse(ImportOfficerDto.Weapon, out Weapon weapon);

                if (!isValidWeapon)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Officer officer = new Officer()
                {
                    FullName = ImportOfficerDto.FullName,
                    Salary = ImportOfficerDto.Salary,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = ImportOfficerDto.DepartmentId
                };
                foreach (var prisonerDto in ImportOfficerDto.Prisoners)
                {
                    officer.OfficerPrisoners.Add(new OfficerPrisoner
                    {
                        PrisonerId = prisonerDto.PrisonerId
                    });
                }
                officers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }
            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}