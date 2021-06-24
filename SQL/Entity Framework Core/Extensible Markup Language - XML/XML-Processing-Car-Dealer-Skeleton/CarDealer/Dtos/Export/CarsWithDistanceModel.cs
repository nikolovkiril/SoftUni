using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("car")]
    public class CarsWithDistanceModel
    {
        //[XmlElement("make")]
        //Sales with Applied Discount use XmlAttribute
        [XmlAttribute("make")]
        public string Make { get; set; }
        
        //[XmlElement("model")]
        [XmlAttribute("model")]
        public string Model { get; set; }

        //[XmlElement("travelled-distance")]
        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
