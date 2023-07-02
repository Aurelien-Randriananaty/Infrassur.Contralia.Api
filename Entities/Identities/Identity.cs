using Infrassur.Contralia.Api.Models.Identities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Entities.Identities	
{
	public class Identity
	{		
		[XmlAttribute(AttributeName = "declaredLevel")]
		public DeclaredLevel DeclaredLevel { get; set; }
		[XmlAttribute(AttributeName = "description")]
		[MaxLength(2000, ErrorMessage = "Maximum length for the requestReference is 2000 characters.")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName = "organizationCode")]
		[MaxLength(255, ErrorMessage = "Maximum length for the requestReference is 255 characters.")]
		public string OrganizationCode { get; set; }
		[XmlAttribute(AttributeName = "firstName")]
		[Required(ErrorMessage = "FirstName is required")]
		[MaxLength(50, ErrorMessage = "Maximum length for the requestReference is 50 characters.")]
		public string FirstName { get; set; }
		[XmlAttribute(AttributeName = "lastName")]
		[Required(ErrorMessage = "lastName is required")]
		[MaxLength(50, ErrorMessage = "Maximum length for the requestReference is 50 characters.")]
		public string LastName { get; set; }
		[XmlAttribute(AttributeName = "email")]
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress]
		[MaxLength(200, ErrorMessage = "Maximum length for the requestReference is 200 characters.")]
		public string Email { get; set; }
		[XmlAttribute(AttributeName = "phoneNumber")]
		[Required(ErrorMessage = "PhoneNumber is required")]
		public string PhoneNumber { get; set; }
		[XmlAttribute(AttributeName = "pkiId")]
		[MaxLength(200, ErrorMessage = "Maximum length for the requestReference is 200 characters.")]
		public string PkiId { get; set; }
		[XmlAttribute(AttributeName = "requestReference")]
		[MaxLength(32, ErrorMessage = "Maximum length for the requestReference is 32 characters.")]
		public string RequestReference { get; set; }
	}
}
