using DataObjectsTransfert.IndentitiesDto;
using Entities.Exceptions;
using Infrassur.Contralia.Api.Contracts.Service;
using Infrassur.Contralia.Api.DataTransfertObjects.IndentitiesDto;
using Infrassur.Contralia.Api.Models.Identities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrassur.Contralia.Api.Service
{
    public class IdentitiesService : IIdentitiesService
	{
		private static readonly String OFFER_CODE = ConfigurationManager.AppSettings["OFFER_CODE"];
		private static readonly String ORGANIZATIONAL_UNIT_CODE = ConfigurationManager.AppSettings["ORGANIZATIONAL_UNIT_CODE"];

		private static readonly String CORE_PREFIX = ConfigurationManager.AppSettings["CORE_PREFIX"];
		private static readonly String EDOC_PREFIX = ConfigurationManager.AppSettings["EDOC_PREFIX"];
		private String requestReference = string.Empty;
        private IdentityResponse result;

        public async Task<IdentityResponse> CreateIdentitiesAsync(CreateIdentities createIdentities)
		{
			if (string.IsNullOrEmpty(createIdentities.Email) ||
				string.IsNullOrEmpty(createIdentities.FirstName) ||
				string.IsNullOrEmpty(createIdentities.LastName) ||
				string.IsNullOrEmpty(createIdentities.PhoneNumber))
			{
				return new IdentityResponse();
			}

			using (MultipartFormDataContent formData = new MultipartFormDataContent())
			{
				bool temporary = createIdentities.Temporary ? createIdentities.Temporary : false;
				formData.Add(new StringContent(createIdentities.Temporary.ToString()), "temporary");
				if (!String.IsNullOrEmpty(createIdentities.DeclaredLevel.ToString()))
				{
					formData.Add(new StringContent(Enum.IsDefined(typeof(DeclaredLevel), createIdentities.DeclaredLevel).ToString()), "declaresLevel");
				}
				if (!String.IsNullOrEmpty(createIdentities.Description))
				{
					formData.Add(new StringContent(createIdentities.Description), "description");
				}
				if (!String.IsNullOrEmpty(createIdentities.OrganizationCode))
				{
					formData.Add(new StringContent(createIdentities.OrganizationCode), "organizationCode");
				}

				formData.Add(new StringContent(createIdentities.FirstName), "firstname");
				formData.Add(new StringContent(createIdentities.LastName), "lastname");
				formData.Add(new StringContent(createIdentities.Email), "email");
				formData.Add(new StringContent(createIdentities.PhoneNumber), "phoneNumber");

				if (!String.IsNullOrEmpty(createIdentities.PkiId))
				{
					formData.Add(new StringContent(createIdentities.PkiId), "pkId");
				}
				requestReference = !string.IsNullOrEmpty(createIdentities.RequestReference) ? createIdentities.RequestReference : "";


				// Appeler l'API
				String apiPath = String.Format(CORE_PREFIX + "/api/v2/identity");
				result = await ServicesExtensions.GetResponseAsType<IdentityResponse>(apiPath, HttpMethod.Post, formData, requestReference);
			}

			return result;
		}

		public async Task<IEnumerable<IdentitiesFindResponse>> FindIdentitiesAsync(FindIdentities findIdentities)
		{
			if(findIdentities == null)
			{
				return null;
			}

			List<IdentitiesFindResponse> result = null;

			using (MultipartFormDataContent formData = new MultipartFormDataContent())
			{
				if (!string.IsNullOrEmpty(findIdentities.Id.ToString()))
				{
					formData.Add(new StringContent(findIdentities.Id.ToString()), "id");
				}
				if (!string.IsNullOrEmpty(findIdentities.Email))
				{
					formData.Add(new StringContent(findIdentities.Email), "email");
				}
				if (!string.IsNullOrEmpty(findIdentities.FirstName))
				{
					formData.Add(new StringContent(findIdentities.FirstName), "firstName");
				}
				if (!string.IsNullOrEmpty(findIdentities.LastName))
				{
					formData.Add(new StringContent(findIdentities.LastName), "lastName");
				}

				//requestReference = !string.IsNullOrEmpty(updateIdentity.RequestReference) ? "?requestReference=" + updateIdentity.RequestReference : "";
				requestReference = !string.IsNullOrEmpty(findIdentities.RequestReference) ? findIdentities.RequestReference : "";

				if (!string.IsNullOrEmpty(findIdentities.PkiId))
				{
					formData.Add(new StringContent(findIdentities.PkiId), "pkiId");
				}

				//string apiPath = string.Format(CORE_PREFIX + "/api/identity/{0}/update" + requestReference, id);
				string apiPath = string.Format(CORE_PREFIX + "/api/identity/find");

				result = await ServicesExtensions.GetResponseAsType<List<IdentitiesFindResponse>>(apiPath, HttpMethod.Get, formData, requestReference);
			}

			return result;				
			
		}

		public async Task<IdentityStatusResponse> RevokeIdentitiesAsync(long id, RevokeIdentities revokeIdentities)
		{
			IdentityStatusResponse result = null;

			if (string.IsNullOrEmpty(id.ToString()) || string.IsNullOrEmpty(revokeIdentities.Reason.ToString()))
            {
				throw new IdParametersBadRequestException();
            }
			using (MultipartFormDataContent formData = new MultipartFormDataContent())
			{
				
				formData.Add(new StringContent(Enum.IsDefined(typeof(Reason), revokeIdentities.Reason).ToString()), "description");

				if(!String.IsNullOrEmpty(revokeIdentities.ReasonDetails))
				{
					formData.Add(new StringContent(revokeIdentities.ReasonDetails), "rReasonDetails");
				}				

				//requestReference = !string.IsNullOrEmpty(updateIdentity.RequestReference) ? "?requestReference=" + updateIdentity.RequestReference : "";
				requestReference = !string.IsNullOrEmpty(revokeIdentities.RequestReference) ? revokeIdentities.RequestReference : "";

				
				
				//string apiPath = string.Format(CORE_PREFIX + "/api/identity/{0}/update" + requestReference, id);
				string apiPath = string.Format(CORE_PREFIX + "/api/identity/{0}/revoke", id);
				result = await ServicesExtensions.GetResponseAsType<IdentityStatusResponse>(apiPath, HttpMethod.Post, formData, requestReference);
			}

			return result;
		}

		public async Task<IdentityStatusResponse> StatusIdentitiesAsync(long id, StatusIdentities statusIdentities)
		{
			IdentityStatusResponse result = null;
			MultipartFormDataContent formData = null;
			if (id == 0)
			{
				return null;
			}
			requestReference = !string.IsNullOrEmpty(statusIdentities.RequestReference) ? statusIdentities.RequestReference : "";

			string apiPath = string.Format(CORE_PREFIX + "/api/identity/{0}/status", id);
			result = await ServicesExtensions.GetResponseAsType<IdentityStatusResponse>(apiPath, HttpMethod.Get, formData, requestReference);

			return result;
		}

		public async Task<IdentityResponse> UpdateIdentitiesAsync(long id, UpdateIdentities updateIdentity)
		{
			IdentityResponse result = new IdentityResponse();

			if (string.IsNullOrEmpty(id.ToString()))
			{			
				return null;
            }
			using (MultipartFormDataContent formData = new MultipartFormDataContent()) 
			{
				if (!string.IsNullOrEmpty(updateIdentity.Description))
				{
					formData.Add(new StringContent(updateIdentity.Description), "description");
				}
				if (!string.IsNullOrEmpty(updateIdentity.Email))
				{
					formData.Add(new StringContent(updateIdentity.Email), "email");
				}				
				if (!string.IsNullOrEmpty(updateIdentity.FirstName))
				{
					formData.Add(new StringContent(updateIdentity.FirstName), "firstName");
				}
				if (!string.IsNullOrEmpty(updateIdentity.LastName))
				{
					formData.Add(new StringContent(updateIdentity.LastName), "lastName");
				}

				//requestReference = !string.IsNullOrEmpty(updateIdentity.RequestReference) ? "?requestReference=" + updateIdentity.RequestReference : "";
				requestReference = !string.IsNullOrEmpty(updateIdentity.RequestReference) ? updateIdentity.RequestReference : "";

				if (!string.IsNullOrEmpty(updateIdentity.PhoneNumber))
				{
					formData.Add(new StringContent(updateIdentity.PhoneNumber), "phoneNumber");
				}
				if (!String.IsNullOrEmpty(updateIdentity.DeclaredLevel.ToString()))
				{
					formData.Add(new StringContent(Enum.IsDefined(typeof(DeclaredLevel), updateIdentity.DeclaredLevel).ToString()), "declaresLevel");
				}
				if (!string.IsNullOrEmpty(updateIdentity.OrganizationCode))
				{
					formData.Add(new StringContent(updateIdentity.OrganizationCode), "organizationCode");
				}
				if (!string.IsNullOrEmpty(updateIdentity.PkiId))
				{
					formData.Add(new StringContent(updateIdentity.PkiId), "pkiId");
				}
				formData.Add(new StringContent(updateIdentity.ResetCounters.ToString()), "resetCounters");
				//string apiPath = string.Format(CORE_PREFIX + "/api/identity/{0}/update" + requestReference, id);
				string apiPath = string.Format(CORE_PREFIX + "/api/identity/{0}/update", id);
				result = await ServicesExtensions.GetResponseAsType<IdentityResponse>(apiPath, HttpMethod.Post, formData, requestReference);
			}

			return result;
        }
	}
}