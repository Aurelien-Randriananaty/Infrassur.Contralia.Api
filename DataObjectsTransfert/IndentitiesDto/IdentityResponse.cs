using System;
using System.Xml.Serialization;

namespace Infrassur.Contralia.Api.DataTransfertObjects.IndentitiesDto
{
	[XmlRoot("identity")]
	public class IdentityResponse
	{
		[XmlAttribute("id")]
		public int Id { get; set; }

		[XmlAttribute("temporary")]
		public bool Temporary { get; set; }

		[XmlAttribute("state")]
		public string State { get; set; }

		[XmlAttribute("declaredLevel")]
		public string DeclaredLevel { get; set; }

		[XmlAttribute("declaredLevelDate")]
		public DateTime DeclaredLevelDate { get; set; }

		[XmlAttribute("currentLevel")]
		public string CurrentLevel { get; set; }

		[XmlAttribute("currentLevelDate")]
		public DateTime CurrentLevelDate { get; set; }

		[XmlAttribute("description")]
		public string Description { get; set; }

		[XmlAttribute("organizationCode")]
		public string OrganizationCode { get; set; }

		[XmlAttribute("firstName")]
		public string FirstName { get; set; }

		[XmlAttribute("lastName")]
		public string LastName { get; set; }

		[XmlAttribute("phoneNumber")]
		public string PhoneNumber { get; set; }

		[XmlAttribute("email")]
		public string Email { get; set; }

		[XmlAttribute("pkiId")]
		public string PkiId { get; set; }

		[XmlAttribute("lastUpdated")]
		public string LastUpdated { get; set; }

		[XmlAttribute("passwordTryCount")]
		public int PasswordTryCount { get; set; }

		[XmlAttribute("maxPasswordTryCount")]
		public int MaxPasswordTryCount { get; set; }

		[XmlElement("phoneNumberStatus")]
		public PhoneNumberStatus PhoneNumberStatus { get; set; }

		[XmlElement("emailStatus")]
		public EmailStatus EmailStatus { get; set; }

		[XmlElement("nameStatus")]
		public NameStatus NameStatus { get; set; }
	}

	public class PhoneNumberStatus
	{
		[XmlAttribute("validated")]
		public bool Validated { get; set; }

		[XmlAttribute("validationDate")]
		public DateTime ValidationDate { get; set; }

		[XmlAttribute("codeSendCount")]
		public int CodeSendCount { get; set; }

		[XmlAttribute("codeSendDate")]
		public DateTime CodeSendDate { get; set; }

		[XmlAttribute("codeTryCount")]
		public int CodeTryCount { get; set; }
	}

	public class EmailStatus
	{
		[XmlAttribute("validated")]
		public bool Validated { get; set; }

		[XmlAttribute("validationDate")]
		public DateTime ValidationDate { get; set; }

		[XmlAttribute("codeSendCount")]
		public int CodeSendCount { get; set; }

		[XmlAttribute("codeSendDate")]
		public DateTime CodeSendDate { get; set; }

		[XmlAttribute("codeTryCount")]
		public int CodeTryCount { get; set; }
	}

	public class NameStatus
	{
		[XmlAttribute("validated")]
		public bool Validated { get; set; }

		[XmlAttribute("validationDate")]
		public DateTime ValidationDate { get; set; }

		[XmlAttribute("validationMode")]
		public string ValidationMode { get; set; }
	}
}