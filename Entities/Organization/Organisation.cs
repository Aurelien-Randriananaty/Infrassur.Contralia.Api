using System.Collections.Generic;
using System.Xml.Serialization;

namespace Entities.Organization
{
    [XmlRoot("organization", Namespace = "http://www.contralia.fr/organization")]
    public class Organization
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("code")]
        public string Code { get; set; }

        [XmlAttribute("safe")]
        public string Safe { get; set; }

        [XmlAttribute("companyRegistrationNumber")]
        public string CompanyRegistrationNumber { get; set; }

        [XmlAttribute("companyRegistrationNumber2")]
        public string CompanyRegistrationNumber2 { get; set; }

        [XmlElement("address")]
        public Address Address { get; set; }

        [XmlElement("signatorySignatureImage")]
        public string SignatorySignatureImage { get; set; }

        [XmlElement("organizationSignatureImage")]
        public string OrganizationSignatureImage { get; set; }

        [XmlElement("signatorySignatureProfiles")]
        public SignatorySignatureProfiles SignatorySignatureProfiles { get; set; }
        [XmlElement("organizationSignatureProfiles")]
        public OrganizationSignatureProfiles OrganizationSignatureProfiles { get; set; }
        [XmlElement("trustedCAs")]
        public TrustedCAs TrustedCAs { get; set; }
        [XmlElement("users")]
        public Users Users { get; set; }
        [XmlElement("offers")]
        public Offers Offers { get; set; }
        [XmlElement(ElementName = "organizationalUnits")]
        public OrganizationalUnits OrganizationalUnits { get; set; }
    }

    [XmlRoot("adresse")]
    public class Address
    {
        [XmlElement("street")]
        public string Street { get; set; }
        [XmlElement("postalCode")]
        public string PostalCode { get; set; }
        [XmlElement("city")]
        public string City { get; set; }
        [XmlElement("country")]
        public string Country { get; set; }
    }

    [XmlRoot("signatorySignatureProfiles")]
    public class SignatorySignatureProfiles
    {
        [XmlElement("signatureProfile")]
        public SignatureProfile SignatureProfile { get; set; }
    }

    [XmlRoot("organizationSignatureProfiles")]
    public class OrganizationSignatureProfiles
    {
        [XmlElement("signatureProfile")]
        public SignatureProfile SignatureProfile { get; set; }
    }

    [XmlRoot("signatureProfile")]
    public class SignatureProfile
    {
        [XmlAttribute("number")]
        public int Number { get; set; }
        [XmlAttribute("enabled")]
        public bool Enabled { get; set; }
        [XmlAttribute("certificateProfile")]
        public string CertificateProfile { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("signatureText")]
        public string SignatureText { get; set; }
        [XmlElement("reasonText")]
        public string ReasonText { get; set; }
        [XmlElement("locationText")]
        public string LocationText { get; set; }
    }

    [XmlRoot("trustedCAs")]
    public class TrustedCAs
    {
        [XmlAttribute("trustAllCAs")]
        public bool TrustAllCAs { get; set; }
        [XmlElement("trustedCA")]
        public TrustedCA TrustedCA { get; set; }
    }

    [XmlRoot("trustedCA")]
    public class TrustedCA
    {
        [XmlAttribute("enabled")]
        public bool Enabled { get; set; }
        [XmlElement("certificate")]
        public string Certificate { get; set; }
    }

    [XmlRoot("users")]
    public class Users
    {
        [XmlElement("user")]
        public User User { get; set; }
    }

    [XmlRoot("user")]
    public class User
    {
        [XmlAttribute("enabled")]
        public bool Enabled { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("username")]
        public string Username { get; set; }
        [XmlAttribute("password")]
        public string Password { get; set; }
        [XmlAttribute("email")]
        public string Email { get; set; }
        [XmlAttribute("role")]
        public string Role { get; set; }
        [XmlAttribute("description")]
        public string Description { get; set; }
    }

    [XmlRoot("offers")]
    public class Offers
    {
        [XmlElement("offer")]
        public Offer Offer { get; set; }
    }

    [XmlRoot("offer")]
    public class Offer
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("code")]
        public string Code { get; set; }
        [XmlElement("parameter")]
        public List<Parameters> Parameters { get; set; }
    }

    [XmlRoot("parameter")]
    public class Parameters
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("value")]
        public int Value { get; set; }
    }

    [XmlRoot("organizationalUnits")]
    public class OrganizationalUnits
    {
        [XmlElement(ElementName = "organizationalUnit")]
        public List<OrganizationalUnit> OrganizationalUnit { get; set; }
    }

    [XmlRoot("organizationalUnit")]
    public class OrganizationalUnit
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }

        [XmlAttribute(AttributeName = "companyRegistrationNumber")]
        public string CompanyRegistrationNumber { get; set; }

        [XmlElement(ElementName = "address")]
        public Address Address { get; set; }
    }
}