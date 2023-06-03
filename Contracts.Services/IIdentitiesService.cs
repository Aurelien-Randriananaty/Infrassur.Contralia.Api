using Infrassur.Contralia.Api.DataTransfertObjects.IndentitiesDto;
using Infrassur.Contralia.Api.Models.Identities;
using System.Threading.Tasks;

namespace Infrassur.Contralia.Api.Contracts.Service
{
	public interface IIdentitiesService
	{
		Task<IdentityResponse> CreateIdentitiesAsync(CreateIdentities createIdentities);
		Task<FindIdentities> FindIdentitiesAsync(FindIdentities findIdentities);
		Task<RevokeIdentities> RevokeIdentitiesAsync(RevokeIdentities revokeIdentities);
		Task<StatusIdentities> StatusIdentitiesAsync(StatusIdentities statusIdentities);
		Task<UpdateIdentities> UpdateIdentitiesAsync(UpdateIdentities updateIdentities);
	}
}
