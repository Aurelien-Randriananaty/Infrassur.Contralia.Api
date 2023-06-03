using Infrassur.Contralia.Api.Contracts.Service;
using System;

namespace Infrassur.Contralia.Api.Service
{
	public sealed class ServiceManager : IServiceManager
	{
		private readonly Lazy<IIdentitiesService> _identitiesService;

		public ServiceManager()
		{
			_identitiesService = new Lazy<IIdentitiesService>(() => new IdentitiesService());
		}

		public IIdentitiesService IdentitiesService => _identitiesService.Value;
	}
}