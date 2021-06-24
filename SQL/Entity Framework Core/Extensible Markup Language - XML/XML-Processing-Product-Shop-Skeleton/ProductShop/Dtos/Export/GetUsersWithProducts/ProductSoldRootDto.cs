
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export.GetUsersWithProducts
{
    [XmlType("SoldProducts")]
    public class ProductSoldRootDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public List<SoldProductsModel> Products { get; set; }
    }
}