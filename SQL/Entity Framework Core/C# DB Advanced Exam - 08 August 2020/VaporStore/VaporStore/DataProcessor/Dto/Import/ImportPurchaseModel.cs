using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class ImportPurchaseModel
    {
        [Required]
        [XmlElement("Type")]
        public string PurchaseType { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.PurchaseKeyRegex)]
        [XmlElement("Key")]
        public string Key { get; set; }

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.CardNumberRegex)]
        [XmlElement("Card")]
        public string CardNumber { get; set; }

        [Required]
        [XmlAttribute("title")]
        public string GameTitle { get; set; }
    }
}
