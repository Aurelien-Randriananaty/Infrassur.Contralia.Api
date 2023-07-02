using Entities.Organization;
using Nustache.Core;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Helper
{
    public static class DynamicTemplateXml
    {
        public static string CreateOrganizationTemplateXml(Organization organization)
        {
            string organizationTemplateXml = @"
                <?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>
                      <organization xmlns=""http://www.contralia.fr/organization"" name=""{{MyOrganization}}"" code=""{{infrassur.OFFERFOURNISSEUR}}"" safe=""{{contralia-rct2}}"" companyRegistrationNumber=""{{VAT-123456789}}"" companyRegistrationNumber2=""{{123456789}}"">  
                        
                        <address>
                          <street>{{Rue du Vallon}}</street>
                          <postalCode>{{06000}}</postalCode>
                          <city>{{NICE}}</city>
                          <country>{{FRANCE}}</country>
                        </address>
    
                        <signatorySignatureImage>
                          {{iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAIAAACQkWg2AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAAadEVYdFNvZnR3YXJlAFBhaW50Lk5FVCB2My41LjExR/NCNwAAAG9JREFUOE+VklEWgCAIBL0U9z+aLYFkgBHzUbbsvNLXmB2IqCGg3RZwHXIrsRoLpbMX+JO+BTfVPZwc5LkA4iwm4HVKrhHbwB+rOWkbeEEwLZK/waGzG79poM8LTVeuwh6lSAGwICsZlPz6NR7mvAAU1Yt/M2eEdAAAAABJRU5ErkJggg==}}
                        </signatorySignatureImage>
    
                        <organizationSignatureImage>
                          {{iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAIAAACQkWg2AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAAadEVYdFNvZnR3YXJlAFBhaW50Lk5FVCB2My41LjExR/NCNwAAAG9JREFUOE+VklEWgCAIBL0U9z+aLYFkgBHzUbbsvNLXmB2IqCGg3RZwHXIrsRoLpbMX+JO+BTfVPZwc5LkA4iwm4HVKrhHbwB+rOWkbeEEwLZK/waGzG79poM8LTVeuwh6lSAGwICsZlPz6NR7mvAAU1Yt/M2eEdAAAAABJRU5ErkJggg==}}
                        </organizationSignatureImage>
    
                        <signatorySignatureProfiles>
                          <signatureProfile number=""{{1}}"" enabled=""{{true}}"" certificateProfile=""{{contralia-docapost-bpo-eseal-test}}"">
                            <description>{{MyDesc}}</description>
                            <signatureText>Signé par {{lastname}} {{firstname}}</signatureText>
                            <reasonText>Signé par {{lastname}} {{firstname}} via Contralia</reasonText>
                            <locationText>Signé par {{lastname}} {{firstname}} sur Internet</locationText>
                          </signatureProfile>
                        </signatorySignatureProfiles>
    
                        <organizationSignatureProfiles>
                          <signatureProfile number=""{{1}}"" enabled=""{{true}}"" certificateProfile=""{{test-contralia-fourtest}}"">
                            <description>{{MyDesc}}</description>
                            <signatureText>Signé par {{organization}}</signatureText>
                            <reasonText>Signé par {{organization}} via Contralia</reasonText>
                            <locationText>Signé par {{organization}} sur Internet</locationText>
                          </signatureProfile>
                        </organizationSignatureProfiles>
    
                        <trustedCAs trustAllCAs=""{{false}}"">
                          <trustedCA enabled=""{{true}}"">
      	                    <certificate>
                                {{MIIFXTCCA0WgAwIBAgIIEoWPtzDiI30wDQYJKoZIhvcNAQELBQAwXTELMAkGA1UEBhMCRlIxETAPBgNVBAoMCExBIFBPU1RFMRcwFQYDVQQLDA4wMDAyIDM1NjAwMDAwMDEiMCAGA1UEAwwZQUMgU2VydmV1cnMgTGEgUG9zdGUgQlNDQzAeFw0xNjExMTcxMDI2MDBaFw0xODExMTgxMDI2MDBaMHMxCzAJBgNVBAYTAkZSMREwDwYDVQQKDAhMQSBQT1NURTENMAsGA1UECwwEQlNDQzEPMA0GA1UECwwGU0VSVkVSMTEwLwYDVQQDDCh3cy5iYWJvcmQubmV0My1jb3Vycmllci5leHRyYS5sYXBvc3RlLmZyMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAkD/vIFDfU9w1St6e/TgM9JJsWOGJJvzxA76w2LqELttMu3ckTpe9Dnrxq9bCWOua8WgLmzb60nDKiSf10NBSVZajUGcJneCAIOuQ5YRhTYGmFl+XM24BaFyvEv4fPbrR2q1jSj3OK0s/tzO1qdXL5TPG649682VkP4Zp2/5vilMPZwOeGsqQXUzxHl/AkQ1EVqPqWD3NRpmNjqor4FcCvXOeZ17W111VYnq3QbWhhsTldAKM9dERlMVq//6LK1PE+LmBQ2HdKQfTfKQMgJ4UXgFnHfs4
                                +Nbj0ySdoqn48IaJTw9AszytBkeWbPaukfSUxrhrBCVleQ4W5deO+PR1ZwIDAQABo4IBCTCCAQUwHQYDVR0OBBYEFJylSJLX7xbgQ+94U5rJOxcp6pzIMAwGA1UdEwEB/wQCMAAwHwYDVR0jBBgwFoAUJMiWjFKSUah8J8r4T+R6LHhIKKkwWwYDVR0fBFQwUjBQoE6gTIZKaHR0cDovL2xjci5wa2kubmV0LWNvdXJyaWVyLmV4dHJhLmxhcG9zdGUuZnIvQUMtU2VydmV1cnMtTGEtUG9zdGUtQlNDQy5jcmwwDgYDVR0PAQH/BAQDAgWgMBMGA1UdJQQMMAoGCCsGAQUFBwMBMDMGA1UdEQQsMCqCKHdzLmJhYm9yZC5uZXQzLWNvdXJyaWVyLmV4dHJhLmxhcG9zdGUuZnIwDQYJKoZIhvcNAQELBQADggIBAFw20GxlhaWvjID6Kox3Y424SW8bm0p3sO7+A88hLJDYekTK3yVL7QqFrnIaa2zFUuUgMfuNV5nfhw9jKhKCZju7x2FgtylAh/kGgSyR535C04GPQhCKcPduvw2/mc+i9Ry7s32KqxgU8fBVc68PgyopUdTQxmjI8izDLW2cE1oVN78ygsxZVtmAJycmnJcr
                                rmwHgCPvXYa91T9VN9w0uTEs2cVWMZOVb3C8U/y6MAUN/D6jvP5n7kn7Nn7rmRGPEZ0deb3O7+w03beO/VTIUEWtoeanPN49KGP6J5lCVnJ4yY0Rydp/ycexL55YJxUf3CPgrNddVzS98Lj0UBxmAjHxYVoTDb23JuYKcZDPjXBvHR49stxJjGWYWNYPye7nh+0K8zvAdqUsuY1Va0ECDxRjh5SQOhsojRmdFwM3oFiZfbsl06q3SGkT0yFqHw74I4VqAB568smOmZdGBcqxcQ7uKEcs1wTvJi9rEBDNmBZO7gwllb/3y+NKbjGlFyALdkG+MUiF+yv6Ml20rCr2h0kXk4gpGLjXE9Y3YRFgydRSxyMbEY3AEd64XQ2lg7En6E8pwh4DprIGBKbtB8U88+pQJsfLI1bBa7o1ef0fX9rXb/ybTM6/esjcgYkwOw0bMVNwXbSrPHaP1FHbX+khQ3+wUej6PFc8PaUOpoikiZ2c}}
      	                    </certificate>
                          </trustedCA>
                        </trustedCAs>
    
                        <users>
                          <user enabled=""{{true}}"" name=""{{my name}}"" username=""{{infrassur.OFFERFOURNISSEUR_3}}"" password=""{{Mypwd@1111}}"" email=""{{testorganisation3@gmal.com}}"" role=""{{API}}"" description='{{}}' />
                        </users>
    
                        <offers>
                          <offer name=""{{OfferName1}}"" code=""{{infrassur.OFFERFOURNISSEUR_3}}"">
                            <parameter name=""{{otpMaxCount}}"" value=""{{10}}"" />
                            <parameter name=""{{transactionTimeoutHours}}"" value=""{{100}}"" />
                          </offer>
                        </offers>
    
                        <organizationalUnits>
                          <organizationalUnit name=""{{}}Distrib1}}"" code=""{{}}infrassur.OFFERFOURNISSEUR_3}}"" companyRegistrationNumber=""{{123456789}}"">
                            <address>
                              <street>{{Rue du Vallon}}</street>
                              <postalCode>{{06000}}</postalCode>
                              <city>{{NICE}}</city>
                              <country>{{FRANCE}}</country>
                            </address>
                          </organizationalUnit>
                        </organizationalUnits>
    
                    </organization>            
            ";

            // Create a dictionary or dynamic object to hold your data
            var _organization = new { organization };

            // Render the template with the data (_organization)
            string organizationString = Render.StringToString(organizationTemplateXml, _organization);
            string organizationXml = organizationString.Replace("\r\n", "");

            return organizationXml;
        }
    }
}
