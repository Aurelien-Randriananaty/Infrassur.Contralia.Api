using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DataObjectsTransfert.OrganizationDto
{
    [XmlRoot(ElementName = "address")]
    public class Address
    {

        [XmlElement(ElementName = "street")]
        public string Street { get; set; }

        [XmlElement(ElementName = "complements")]
        public string Complements { get; set; }

        [XmlElement(ElementName = "postalCode")]
        public int PostalCode { get; set; }

        [XmlElement(ElementName = "city")]
        public string City { get; set; }

        [XmlElement(ElementName = "country")]
        public string Country { get; set; }
    }

    [XmlRoot(ElementName = "signatureProfile")]
    public class SignatureProfile
    {

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "signatureText")]
        public string SignatureText { get; set; }

        [XmlElement(ElementName = "reasonText")]
        public string ReasonText { get; set; }

        [XmlElement(ElementName = "locationText")]
        public string LocationText { get; set; }

        [XmlAttribute(AttributeName = "number")]
        public int Number { get; set; }

        [XmlAttribute(AttributeName = "enabled")]
        public bool Enabled { get; set; }

        [XmlAttribute(AttributeName = "certificateProfile")]
        public string CertificateProfile { get; set; }
    }

    [XmlRoot(ElementName = "signatorySignatureProfiles")]
    public class SignatorySignatureProfiles
    {

        [XmlElement(ElementName = "signatureProfile")]
        public List<SignatureProfile> SignatureProfile { get; set; }
    }

    [XmlRoot(ElementName = "organizationSignatureProfiles")]
    public class OrganizationSignatureProfiles
    {

        [XmlElement(ElementName = "signatureProfile")]
        public List<SignatureProfile> SignatureProfile { get; set; }
    }

    [XmlRoot(ElementName = "trustedCA")]
    public class TrustedCA
    {

        [XmlElement(ElementName = "certificate")]
        public string Certificate { get; set; }

        [XmlAttribute(AttributeName = "enabled")]
        public bool Enabled { get; set; }
    }

    [XmlRoot(ElementName = "trustedCAs")]
    public class TrustedCAs
    {

        [XmlElement(ElementName = "trustedCA")]
        public TrustedCA TrustedCA { get; set; }

        [XmlAttribute(AttributeName = "trustAllCAs")]
        public bool TrustAllCAs { get; set; }
    }

    [XmlRoot(ElementName = "user")]
    public class User
    {

        [XmlAttribute(AttributeName = "enabled")]
        public bool Enabled { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "username")]
        public string Username { get; set; }

        [XmlAttribute(AttributeName = "email")]
        public string Email { get; set; }

        [XmlAttribute(AttributeName = "role")]
        public string Role { get; set; }

        [XmlAttribute(AttributeName = "description")]
        public string Description { get; set; }
    }

    [XmlRoot(ElementName = "users")]
    public class Users
    {

        [XmlElement(ElementName = "user")]
        public List<User> User { get; set; }
    }

    [XmlRoot(ElementName = "parameter")]
    public class Parameter
    {

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "offer")]
    public class Offer
    {

        [XmlElement(ElementName = "parameter")]
        public List<Parameter> Parameter { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }

        [XmlAttribute(AttributeName = "product")]
        public string Product { get; set; }
    }

    [XmlRoot(ElementName = "offers")]
    public class Offers
    {

        [XmlElement(ElementName = "offer")]
        public List<Offer> Offer { get; set; }
    }

    [XmlRoot(ElementName = "organizationalUnit")]
    public class OrganizationalUnit
    {

        [XmlElement(ElementName = "address")]
        public Address Address { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }

        [XmlAttribute(AttributeName = "companyRegistrationNumber")]
        public string CompanyRegistrationNumber { get; set; }
    }

    [XmlRoot(ElementName = "organizationalUnits")]
    public class OrganizationalUnits
    {

        [XmlElement(ElementName = "organizationalUnit")]
        public List<OrganizationalUnit> OrganizationalUnit { get; set; }
    }

    [Serializable]
    [XmlRoot(ElementName = "organization", Namespace = "http://www.contralia.fr/organization")]
    public class OrganizationGetResponse
    {

        [XmlElement(ElementName = "address")]
        public Address Address { get; set; }

        [XmlElement(ElementName = "signatorySignatureImage")]
        public string SignatorySignatureImage { get; set; }

        [XmlElement(ElementName = "organizationSignatureImage")]
        public string OrganizationSignatureImage { get; set; }

        [XmlElement(ElementName = "signatorySignatureProfiles")]
        public SignatorySignatureProfiles SignatorySignatureProfiles { get; set; }

        [XmlElement(ElementName = "organizationSignatureProfiles")]
        public OrganizationSignatureProfiles OrganizationSignatureProfiles { get; set; }

        [XmlElement(ElementName = "trustedCAs")]
        public TrustedCAs TrustedCAs { get; set; }

        [XmlElement(ElementName = "users")]
        public Users Users { get; set; }

        [XmlElement(ElementName = "offers")]
        public Offers Offers { get; set; }

        [XmlElement(ElementName = "organizationalUnits")]
        public OrganizationalUnits OrganizationalUnits { get; set; }

        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }

        //[XmlAttribute(AttributeName="xmlns")] 
        //public string Xmlns { get; set; } 

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "safe")]
        public string Safe { get; set; }

        [XmlAttribute(AttributeName = "companyRegistrationNumber")]
        public string CompanyRegistrationNumber { get; set; }

        [XmlAttribute(AttributeName = "companyRegistrationNumber2")]
        public string CompanyRegistrationNumber2 { get; set; }
    }
}