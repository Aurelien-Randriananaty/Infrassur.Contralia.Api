using Contracts.Services;
using Infrassur.Contralia.Api.Contracts.Service;
using Services;
using System;

namespace Infrassur.Contralia.Api.Service
{
	public sealed class ServiceManager : IServiceManager
	{
		private readonly Lazy<IIdentitiesService> _identitiesService;
		private readonly Lazy<IOrganizationService>	_organisationService;

		public ServiceManager()
		{
			_identitiesService = new Lazy<IIdentitiesService>(() => new IdentitiesService());
			_organisationService = new Lazy<IOrganizationService>(() => new OrganizationService());
		}

		public IIdentitiesService IdentitiesService => _identitiesService.Value;

        public IOrganizationService OrganisationService => _organisationService.Value;
    }
}