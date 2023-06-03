using System.Xml.Serialization;

namespace Infrassur.Contralia.Api.Models.Identities
{
	[XmlRoot(ElementName = "update")]
	public class UpdateIdentities
	{
		[XmlAttribute(AttributeName = "id")]
		public long Id { get; set; }
		[XmlAttribute(AttributeName = "declaredLevel")]
		public DeclaredLevel DeclaredLevel { get; set; }
		[XmlAttribute(AttributeName = "description")]
		public string Description { get; set; }
		[XmlAttribute(AttributeName = "OrganizationCode")]
		public string organizationCode { get; set; }
		[XmlAttribute(AttributeName = "firstName")]
		public string FirstName { get; set; }
		[XmlAttribute(AttributeName = "lastName")]
		public string LastName { get; set; }
		[XmlAttribute(AttributeName = "email")]
		public string Email { get; set; }
		[XmlAttribute(AttributeName = "phoneNumber")]
		public string PhoneNumber { get; set; }
		[XmlAttribute(AttributeName = "pkiId")]
		public string PkiId { get; set; }
		[XmlAttribute(AttributeName = "resetCounters")]
		public bool ResetCounters { get; set; }
		[XmlAttribute(AttributeName = "requestReference")]
		public string RequestReference { get; set; }
	}
}