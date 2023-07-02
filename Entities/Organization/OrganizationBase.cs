using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Entities.Organization
{
    [XmlRoot(ElementName = "organization")]
    public class OrganizationBase
    {
        [XmlAttribute("xml")]
        [Required(ErrorMessage = "Xml Attribut is required")]
        public string Xml { get; set; }
        [XmlAttribute("requestReference")]
        public string RequestReference { get; set; }
    }
}
