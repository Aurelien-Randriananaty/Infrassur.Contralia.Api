using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DataObjectsTransfert.OrganizationDto
{
    [Serializable]
    [XmlRoot(ElementName ="organization")]
    public class OrganizationSetDto
    {
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }
    }
}
