using Entities.Identities;
using System.Xml.Serialization;

namespace Infrassur.Contralia.Api.Models.Identities
{
    [XmlRoot(ElementName = "identity")]
	public class UpdateIdentities : Identity
	{
		//[XmlAttribute(AttributeName = "id")]
		//[Required(ErrorMessage = "is is required")]
		//public long? Id { get; set; }	
		
		[XmlAttribute(AttributeName = "resetCounters")]
		public bool ResetCounters { get; set; }
		
	}
}