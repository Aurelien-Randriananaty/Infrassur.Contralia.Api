using System.Xml.Serialization;

namespace DataObjectsTransfert.OrganizationDto
{
    [XmlRoot("organization")]
    public class OrganizationSetDto
    {
        [XmlAttribute("code")]
        public string Code { get; set; }
    }
}
