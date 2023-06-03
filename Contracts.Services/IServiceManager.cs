using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrassur.Contralia.Api.Contracts.Service
{
	public interface IServiceManager
	{
		IIdentitiesService IdentitiesService { get; }
	}
}
