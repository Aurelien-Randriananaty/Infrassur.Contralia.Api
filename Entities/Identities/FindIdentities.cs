using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Infrassur.Contralia.Api.Models.Identities
{
	[XmlRoot(ElementName = "identity")]
	public class FindIdentities
	{
		[XmlAttribute(AttributeName = "id")]
		public long Id { get; set; }
		[XmlAttribute(AttributeName = "organizationCode")]
		[MaxLength(255, ErrorMessage = "Maximum length for the organizationCode is 255 characters")]
		public string OrganizationCode { get; set; }
		[XmlAttribute(AttributeName = "firstName")]
		//[Required(ErrorMessage = "FirstName is required")]
		[MaxLength(50, ErrorMessage = "Maximum length for the firstName is 50 characters")]
		public string FirstName { get; set; }
		[XmlAttribute(AttributeName = "lastName")]
		//[Required(ErrorMessage = "lastName is required")]
		[MaxLength(50, ErrorMessage = "Maximum length for the lastName is 50 characters")]
		public string LastName { get; set; }
		[XmlAttribute(AttributeName = "email")]
		//[Required(ErrorMessage = "Email is required")]
		[EmailAddress()]
		[MaxLength(200, ErrorMessage = "Maximum length for the email is 50 characters")]
		public string Email { get; set; }
		[XmlAttribute(AttributeName = "phoneNumber")]
		//[Required(ErrorMessage = "PhoneNumber is required")]
		public string PhoneNumber { get; set; }
		[XmlAttribute(AttributeName = "pkiId")]
		//[Required(ErrorMessage = "pkiId is required")]
		public string PkiId	 { get; set; }
		[XmlAttribute(AttributeName = "requestReference")]
		[MaxLength(32, ErrorMessage = "Maximum length for the requestReference is 32 characters")]
		public string RequestReference { get; set; }
	}
}