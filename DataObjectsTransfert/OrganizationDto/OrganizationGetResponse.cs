using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace DataObjectsTransfert.OrganizationDto
{
    [JsonObject("address")]
    public class Address
    {
        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("Complements")]
        public object Complements { get; set; }

        [JsonProperty("postalCode")]
        public int PostalCode { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }

    [JsonObject("signatureProfile")]
    public class SignatureProfile
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("signatureText")]
        public string SignatureText { get; set; }
        
        [JsonProperty("reasonText")]
        public string ReasonText { get; set; }
        
        [JsonProperty("locationText")]
        public string LocationText { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("certificateProfile")]
        public string CertificateProfile { get; set; }
    }

    [JsonObject("signatorySignatureProfiles")]
    public class SignatorySignatureProfiles
    {
        [JsonProperty("signatureProfile")]
        public List<SignatureProfile> SignatureProfile { get; set; }
    }
    [JsonObject("organizationSignatureProfiles")]
    public class OrganizationSignatureProfiles
    {
        [JsonProperty("signatureProfile")]
        public List<SignatureProfile> SignatureProfile { get; set; }
    }
    [JsonObject("trustedCA")]
    public class TrustedCA
    {
        [JsonProperty("certificate")]
        public string Certificate { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
    [JsonObject("trustedCAs")]
    public class TrustedCAs
    {
        [JsonProperty("trustedCA")]
        public TrustedCA TrustedCA { get; set; }

        [JsonProperty("trustAllCAs")]
        public bool TrustAllCAs { get; set; }
    }
    [JsonObject("user")]
    public class User
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }
    }
    [JsonObject("users")]
    public class Users
    {
        [JsonProperty("user")]
        public List<User> User { get; set; }
    }
    [JsonObject("parameter")]
    public class Parameter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }
    [JsonObject("offer")]
    public class Offer
    {
        [JsonProperty("parameter")]
        public List<Parameter> Parameter { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("product")]
        public string Product { get; set; }
    }
    [JsonObject("offers")]
    public class Offers
    {
        [JsonProperty("offer")]
        public List<Offer> Offer { get; set; }
    }
    [JsonObject("organizationalUnit")]
    public class OrganizationalUnit
    {
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("companyRegistrationNumber")]
        public string CompanyRegistrationNumber { get; set; }
    }
    [JsonObject("organizationalUnits")]
    public class OrganizationalUnits
    {
        [JsonProperty("organizationalUnit")]
        public List<OrganizationalUnit> OrganizationalUnit { get; set; }
    }
    [JsonObject("organization")]
    public class OrganizationGetResponse
    {
        [JsonProperty("adresse")]
        public Address Address { get; set; }

        [JsonProperty("signatorySignatureImage")]
        public string SignatorySignatureImage { get; set; }

        [JsonProperty("organizationSignatureImage")]
        public string OrganizationSignatureImage { get; set; }

        [JsonProperty("signatorySignatureProfiles")]
        public SignatorySignatureProfiles SignatorySignatureProfiles { get; set; }

        [JsonProperty("organizationSignatureProfiles")]
        public OrganizationSignatureProfiles OrganizationSignatureProfiles { get; set; }

        [JsonProperty("trustedCAs")]
        public TrustedCAs TrustedCAs { get; set; }

        [JsonProperty("users")]
        public Users Users { get; set; }

        [JsonProperty("offers")]
        public Offers Offers { get; set; }

        [JsonProperty("organizationalUnits")]
        public OrganizationalUnits OrganizationalUnits { get; set; }

        [JsonProperty("")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("safe")]
        public string Safe { get; set; }
        
        [JsonProperty("companyRegistrationNumber")]
        public string CompanyRegistrationNumber { get; set; }
        
        [JsonProperty("companyRegistrationNumber2")]
        public int CompanyRegistrationNumber2 { get; set; }        
    }
}
