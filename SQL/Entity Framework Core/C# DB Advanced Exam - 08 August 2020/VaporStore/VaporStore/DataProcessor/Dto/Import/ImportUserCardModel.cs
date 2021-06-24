using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUserCardModel
    {
        [Required]
        [RegularExpression(GlobalConstants.CardNumberRegex)]
        public string Number { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.CardCvcRegex)]
        [MaxLength(3)]
        [JsonProperty("CVC")]
        public string Cvc { get; set; }
        
        [Required]
        public string Type { get; set; }
    }
}
