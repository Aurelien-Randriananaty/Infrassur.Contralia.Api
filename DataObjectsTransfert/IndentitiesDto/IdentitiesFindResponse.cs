using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataObjectsTransfert.IndentitiesDto
{
	[XmlRoot("identities")]
	public class IdentitiesFindResponse
	{
		[XmlAttribute("count")]
		public int Count { get; set; }

		[XmlAttribute("maxCount")]
		public int MaxCount { get; set; }

		[XmlElement("identity")]
		public List<Identity> IdentityList { get; set; }
	}

	public class Identity
	{
		[XmlAttribute("id")]
		public int Id { get; set; }

		[XmlAttribute("state")]
		public string State { get; set; }

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

	}
}
