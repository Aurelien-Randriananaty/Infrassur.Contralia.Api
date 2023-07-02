using Entities.Identities;
using System.Xml.Serialization;

namespace Infrassur.Contralia.Api.Models.Identities
{
    [XmlRoot(ElementName = "identity")]
	public class CreateIdentities : Identity
	{
		[XmlAttribute(AttributeName = "temporary")]
		public bool Temporary { get; set; }
	}
}