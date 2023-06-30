using Contracts.Services;
using DataObjectsTransfert.OrganizationDto;
using Entities.Exceptions;
using Entities.Organization;
using Infrassur.Contralia.Api.Service;
using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Services
{
    public class OrganizationService : IOrganizationService
    {
        private static readonly String CORE_PREFIX = ConfigurationManager.AppSettings["CORE_PREFIX"];
        private String requestReference = string.Empty;
        //private OrganizationSetDto result;

        public async Task<OrganizationSetDto> CreateOrganization(string requestReference, Organization organization)
        {
            OrganizationSetDto resultOrganisationCreated = null;
            string xmlTemplate = string.Empty;
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, "http://www.contralia.fr/organization"); // Exclude default namespaces
            XmlSerializer serializer = new XmlSerializer(typeof(Organization));

            using (StringWriter stringWriter = new StringWriter())
            {

                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings
                {
                    Indent = true,
                    OmitXmlDeclaration = false // not Remove the XML declaration <?xml version="1.0" encoding="UTF-16"?>
                }))
                {
                    serializer.Serialize(xmlWriter, organization, namespaces);

                    xmlTemplate = stringWriter.ToString();

                    Console.WriteLine(xmlTemplate);
                }
            }

            OrganizationBase organizationBase = new OrganizationBase()
            {
                RequestReference = requestReference,
                Xml = xmlTemplate // DynamicTemplateXml.CreateOrganizationTemplateXml(organization)
            };

            using (MultipartFormDataContent formData = new MultipartFormDataContent())
            {
                formData.Add(new StringContent(organizationBase.Xml), "xml");
                requestReference = !string.IsNullOrEmpty(organizationBase.RequestReference) ? organizationBase.RequestReference : "";
                // Appeler l'API
                String apiPath = String.Format(CORE_PREFIX + "/api/v2/organizations/set");
                resultOrganisationCreated = await ServicesExtensions.GetResponseAsType<OrganizationSetDto>(apiPath, HttpMethod.Post, formData, requestReference);
            }

            return resultOrganisationCreated;
        }

        public async Task<OrganizationList> GetOrganizationsList(string requestReference)
        {
            OrganizationList organizationList = null;
            using (MultipartFormDataContent formData = new MultipartFormDataContent())
            {
                requestReference = requestReference ?? string.Empty;

                // Appeler l'API
                String apiPath = String.Format(CORE_PREFIX + "/api/v2/organizations/list");
                organizationList = await ServicesExtensions.GetResponseAsType<OrganizationList>(apiPath, HttpMethod.Get, formData, requestReference);
            }

            return organizationList;
        }

        public async Task<OrganizationGetResponse> GetOrganizations(OrganizationGet organization)
        {
            if (string.IsNullOrWhiteSpace(organization.OrganizationCode))
            {
                throw new OrganizationCodeParameterBadRequest();
            }

            OrganizationGetResponse organizationGet = null;

            using (MultipartFormDataContent formData = new MultipartFormDataContent()) 
            {
                requestReference = !string.IsNullOrEmpty(organization.RequestReference) ? organization.RequestReference : "";

                // Appeler l'API
                String apiPath = String.Format(CORE_PREFIX + "/api/v2/organizations/get" + $"?organizationCode={organization.OrganizationCode}");
                organizationGet = await ServicesExtensions.GetResponseAsType<OrganizationGetResponse>(apiPath, HttpMethod.Get, formData, requestReference);
            }

            return organizationGet;
        }

        public async Task<OrganizationConstraintsResponse> GetOrganizationConstraints(string requestReference)
        {
            OrganizationConstraintsResponse organizationConstraints = null;
            using (MultipartFormDataContent formData = new MultipartFormDataContent())
            {
                requestReference = requestReference ?? string.Empty;

                // Appeler l'API
                String apiPath = String.Format(CORE_PREFIX + "/api/v2/organizations/constraints");
                organizationConstraints = await ServicesExtensions.GetResponseAsType<OrganizationConstraintsResponse>(apiPath, HttpMethod.Get, formData, requestReference);
            }

            return organizationConstraints;
        }
    }
}
