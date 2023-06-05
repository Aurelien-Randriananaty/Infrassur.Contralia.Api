using DataObjectsTransfert.IndentitiesDto;
using Infrassur.Contralia.Api.DataTransfertObjects.IndentitiesDto;
using Infrassur.Contralia.Api.Models.Identities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrassur.Contralia.Api.Contracts.Service
{
	public interface IIdentitiesService
	{
		Task<IdentityResponse> CreateIdentitiesAsync(CreateIdentities createIdentities);
		Task<IEnumerable<IdentitiesFindResponse>> FindIdentitiesAsync(FindIdentities findIdentities);
		Task<IdentityStatusResponse> RevokeIdentitiesAsync(long id, RevokeIdentities revokeIdentities);
		Task<IdentityStatusResponse> StatusIdentitiesAsync(long id,StatusIdentities statusIdentities);
		Task<IdentityResponse> UpdateIdentitiesAsync(long id, UpdateIdentities updateIdentities);
	}
}
