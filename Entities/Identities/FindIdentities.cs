using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Infrassur.Contralia.Api.Models.Identities
{
	[XmlRoot(ElementName = "find")]
	public class FindIdentities
	{
		[XmlAttribute(AttributeName = "id")]
		public long Id { get; set; }
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName = "organizationCode")]
		public string OrganizationCode { get; set; }
		[XmlAttribute(AttributeName = "firstName")]
		[Required(ErrorMessage = "FirstName is required")]
		public string FirstName { get; set; }
		[XmlAttribute(AttributeName = "lastName")]
		[Required(ErrorMessage = "lastName is required")]
		public string LastName { get; set; }
		[XmlAttribute(AttributeName = "email")]
		[Required(ErrorMessage = "Email is required")]
		public string Email { get; set; }
		[XmlAttribute(AttributeName = "phoneNumber")]
		[Required(ErrorMessage = "PhoneNumber is required")]
		public string PhoneNumber { get; set; }
		[XmlAttribute(AttributeName = "pkiId")]
		public string PkiId { get; set; }
		[XmlAttribute(AttributeName = "requestReference")]
		public string RequestReference { get; set; }
	}
}