using Infrassur.Contralia.Api.Contracts.Service;
using Infrassur.Contralia.Api.DataTransfertObjects.IndentitiesDto;
using Infrassur.Contralia.Api.Models.Identities;
using System;
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

		public async Task<IdentityResponse> CreateIdentitiesAsync(CreateIdentities createIdentities)
		{
			IdentityResponse result = new IdentityResponse();

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
				if (!String.IsNullOrEmpty(createIdentities.RequestReference))
				{
					formData.Add(new StringContent(createIdentities.RequestReference), "requestReference");
				}

				// Appeler l'API
				String apiPath = String.Format(CORE_PREFIX + "/api/v2/identity");
				result = await ServicesExtensions.GetResponseAsType<IdentityResponse>(apiPath, HttpMethod.Post, formData);
			}

			return result;
		}

		public async Task<FindIdentities> FindIdentitiesAsync(FindIdentities identity)
		{
			throw new NotImplementedException();
		}

		public async Task<RevokeIdentities> RevokeIdentitiesAsync(RevokeIdentities identity)
		{
			throw new NotImplementedException();
		}

		public async Task<StatusIdentities> StatusIdentitiesAsync(StatusIdentities identity)
		{
			throw new NotImplementedException();
		}

		public async Task<UpdateIdentities> UpdateIdentitiesAsync(UpdateIdentities identity)
		{
			throw new NotImplementedException();
		}
	}
}