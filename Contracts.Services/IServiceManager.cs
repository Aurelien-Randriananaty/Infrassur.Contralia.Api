using Contracts.Services;

namespace Infrassur.Contralia.Api.Contracts.Service
{
    public interface IServiceManager
	{
		IIdentitiesService IdentitiesService { get; }
		IOrganizationService OrganisationService { get; }
	}
}
