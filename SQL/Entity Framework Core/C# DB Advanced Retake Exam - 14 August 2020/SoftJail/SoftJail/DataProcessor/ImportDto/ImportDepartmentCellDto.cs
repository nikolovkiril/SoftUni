namespace SoftJail.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportDepartmentCellDto
    {
        [Range(GlobalConstants.CellNumberMinValue, GlobalConstants.CellNumberMaxValue)]
        [JsonProperty("CellNumber")]
        public int CellNumber { get; set; }

        [JsonProperty("HasWindow")]
        public bool HasWindow { get; set; }
    }
}
