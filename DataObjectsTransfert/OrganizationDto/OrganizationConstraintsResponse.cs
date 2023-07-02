using System;
using System.Xml.Serialization;

namespace DataObjectsTransfert.OrganizationDto
{
    [Serializable]
    [XmlRoot(ElementName ="constraints")]
    public class OrganizationConstraintsResponse
    {
        [XmlAttribute("prefix")]
        public string Prefix { get; set; }

        [XmlElement("constraint")]
        public Constraint[] ConstraintList { get; set; }
    }

    [XmlRoot(ElementName = "constaint")]
    public class Constraint
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("minValue")]
        public int MinValue { get; set; }

        [XmlAttribute("maxValue")]
        public int MaxValue { get; set; }

        [XmlAttribute("description")]
        public string Description { get; set; }

        [XmlAttribute("defaultValue")]
        public string DefaultValue { get; set; }

        [XmlAttribute("allowedValues")]
        public string AllowedValues { get; set; }
    }
}
