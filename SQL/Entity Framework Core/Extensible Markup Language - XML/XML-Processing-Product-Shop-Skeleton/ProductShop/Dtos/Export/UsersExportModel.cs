using ProductShop.Dtos.Export.GetUsersWithProducts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class UsersExportModel
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }
        
        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlArray("soldProducts")]
        public List<SoldProductsModel> SoldProducts { get; set; }
        
    }
}
