using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class ImportTaskModel
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }
        
        [Required]
        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [Required]
        [XmlElement("ExecutionType")]
        [Range(0, 3)]
        public int ExecutionType { get; set; }

        [Required]
        [XmlElement("LabelType")]
        [Range(0, 4)]
        public int LabelType { get; set; }

    }
}
//• ExecutionType - enumeration of type ExecutionType,
//with possible values (ProductBacklog, SprintBacklog, InProgress, Finished) (required)
//• LabelType - enumeration of type LabelType,
//with possible values (Priority, CSharpAdvanced, JavaAdvanced, EntityFramework, Hibernate) (required)
//• ProjectId - integer, foreign key(required)
//• Project - Project
//• EmployeesTasks - collection of type EmployeeTask