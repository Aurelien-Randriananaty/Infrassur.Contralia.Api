using Infrassur.Contralia.Api.Contracts.Service;
using Infrassur.Contralia.Api.DataTransfertObjects.IndentitiesDto;
using Infrassur.Contralia.Api.Models.Identities;
using System.Threading.Tasks;
using System.Web.Http;

namespace Infrassur.Contralia.Api.Controllers
{
	public class IdentitiesController : ApiController
	{
		private readonly IServiceManager _service;

        public IdentitiesController(IServiceManager service) => _service = service;

        // POST: createIdentity
        [HttpPost]
		[Route("~/api/identities/create")]
		public async Task<IdentityResponse> CreateIndenity([FromBody] CreateIdentities createIdentities)
		{
			var identity = await _service.IdentitiesService.CreateIdentitiesAsync(createIdentities);
			return identity;
		}
	}
}