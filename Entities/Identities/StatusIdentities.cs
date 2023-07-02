using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Infrassur.Contralia.Api.Models.Identities
{
	[XmlRoot(ElementName = "identity")]
	public class StatusIdentities
	{
		//[XmlAttribute(AttributeName = "id")]
		//[Required(ErrorMessage = "id is required")]
		//public long Id { get; set; }
		[XmlAttribute(AttributeName = "requestReference")]
		[MaxLength(32, ErrorMessage = "Maximum length for the requestReference is 32 characters.")]
		public string RequestReference { get; set; }
	}
}