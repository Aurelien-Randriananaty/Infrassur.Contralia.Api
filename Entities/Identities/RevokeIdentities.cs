using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Infrassur.Contralia.Api.Models.Identities
{
	[XmlRoot(ElementName = "revoke")]
	public class RevokeIdentities
	{
		[XmlAttribute(AttributeName = "id")]
		[Required]
		public long Id { get; set; }
		[XmlAttribute(AttributeName = "reason")]
		[Required]
		public Reason Reason { get; set; }
		[XmlAttribute(AttributeName = "reasonDetails")]
		public string ReasonDetails { get; set; }
		[XmlAttribute(AttributeName = "requestReference")]
		public string RequestReference { get; set; }
	}

	public enum Reason
	{
		USELESS,
		NOT_USED_ANYMORE,
		MY_IDENTITY_CHANGED,
		IDENTITY_USURPED,
		OTHER
	}
}