using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Infrassur.Contralia.Api.Models.Identities
{
	[XmlRoot(ElementName = "revoke")]
	public class RevokeIdentities
	{
		//[XmlAttribute(AttributeName = "id")]
		//[Required(ErrorMessage = "id is required")]
		//public long Id { get; set; }
		[XmlAttribute(AttributeName = "reason")]
		[Required(ErrorMessage = "Reason is required")]
		public Reason Reason { get; set; }
		[XmlAttribute(AttributeName = "reasonDetails")]
		[MaxLength(255, ErrorMessage = "Maximum length for the reasonDetails is 255 characters.")]
		public string ReasonDetails { get; set; }
		[XmlAttribute(AttributeName = "requestReference")]
		[MaxLength(32, ErrorMessage = "Maximum length for the requestReference is 32 characters.")]
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