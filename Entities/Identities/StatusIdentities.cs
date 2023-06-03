using System.Xml.Serialization;

namespace Infrassur.Contralia.Api.Models.Identities
{
	[XmlRoot(ElementName = "status")]
	public class StatusIdentities
	{
		[XmlAttribute(AttributeName = "id")]
		public long Id { get; set; }
		[XmlAttribute(AttributeName = "requestReference")]
		public string RequestReference { get; set; }
	}
}