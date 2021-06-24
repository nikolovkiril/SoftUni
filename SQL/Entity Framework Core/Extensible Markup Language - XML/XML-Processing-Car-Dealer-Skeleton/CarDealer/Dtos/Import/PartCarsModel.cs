using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("partId")]
    public class PartCarsModel
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}