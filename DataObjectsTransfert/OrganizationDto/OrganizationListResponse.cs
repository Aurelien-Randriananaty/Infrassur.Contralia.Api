using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DataObjectsTransfert.OrganizationDto
{
    [Serializable]
    [XmlRoot(ElementName ="organizations")]
    public class OrganizationListResponse
    {
        [XmlElement(ElementName = "organization")]
        public List<OrganizationList> OrganizationList { get; set; }
    }

    [XmlRoot(ElementName ="organization")]
    public class OrganizationList
    {
        [XmlAttribute("code")]
        public string  Code { get; set; }
    }
}
