using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Entities.Organization
{
    [XmlRoot("organisation")]
    public class OrganizationGet
    {
        [XmlElement("organizationCode")]
        [Required(ErrorMessage = "organization code is required")]
        [MaxLength(255, ErrorMessage = "Maximum length for the organizationCode is 255 characters.")]
        public string OrganizationCode { get; set; }
        [XmlElement("requestReference")]
        [MaxLength(32, ErrorMessage = "Maximum length for the requestReference is 32 characters.")]
        public string RequestReference { get; set; }
    }
}
