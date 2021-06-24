using System;
using System.Collections.Generic;
using System.Text;

namespace TeisterMask.DataProcessor.ExportDto
{
    public class ExportEmployeeModel
    {
        public string Username { get; set; }

        public ICollection<ExportEmploeeTaskModel> Tasks { get; set; }
    }
}
