namespace SoftJail.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportDepartmentDto
    {
        [Required]
        [MinLength(GlobalConstants.DepartmentNameMinLength)]
        [MaxLength(GlobalConstants.DepartmentNameMaxLength)]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Cells")]
        public ImportDepartmentCellDto[] Cells { get; set; }
    }
}
