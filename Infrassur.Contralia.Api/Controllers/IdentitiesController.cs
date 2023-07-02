using DataObjectsTransfert.IndentitiesDto;
using Infrassur.Contralia.Api.Contracts.Service;
using Infrassur.Contralia.Api.DataTransfertObjects.IndentitiesDto;
using Infrassur.Contralia.Api.Models.Identities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Infrassur.Contralia.Api.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	public class IdentitiesController : ApiController
	{
		private readonly IServiceManager _service;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="service"></param>
        public IdentitiesController(IServiceManager service) => _service = service;
        
        /// <summary>
        /// Create a identity
        /// </summary>
        /// <param name="createIdentities">createIdentities is a Model to create an identity</param>
        /// <returns></returns>
        [HttpPost]
		[Route("~/api/identities/create")]
		public async Task<IHttpActionResult> CreateIndenity([FromBody] CreateIdentities createIdentities)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var identity = await _service.IdentitiesService.CreateIdentitiesAsync(createIdentities);
			return Ok(identity);
		}

		/// <summary>
		/// update Identity by id
		/// </summary>
		/// <param name="id">id of identity to update</param>
		/// <param name="updateIdentities">createIdentities is a Model to update an identity</param>
		/// <returns></returns>
		[HttpPost]
		[Route("~/api/identities/{id:long}/update")]
		public async Task<IHttpActionResult> UpdateIndenity(long id, [FromBody] UpdateIdentities updateIdentities)
		{
			var identity = await _service.IdentitiesService.UpdateIdentitiesAsync(id, updateIdentities);
			return Ok(identity);
		}

		/// <summary>
		/// Find Identity (NB: if specify an ID API return one identity
		/// </summary>
		/// <param name="findIdentities"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("~/api/identities/find")]
		public async Task<IHttpActionResult> FindIdentities([FromBody] FindIdentities findIdentities)
		{
			var identities = await _service.IdentitiesService.FindIdentitiesAsync(findIdentities);
			return Ok(identities);
		}

		/// <summary>
		/// Check status of an Identity using 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="statusIdentities"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("~/api/identities/{id:long}/status")]
		public async Task<IHttpActionResult> GetStatusIdentity(long id, [FromBody] StatusIdentities statusIdentities)
		{
			var statusIdentity = await _service.IdentitiesService.StatusIdentitiesAsync(id, statusIdentities);
			return Ok(statusIdentity);
		}

		/// <summary>
		/// Revoke an identity using id
		/// </summary>
		/// <param name="id"></param>
		/// <param name="revokeIdentities"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("~/api/identities/{id:long}/revoke")]
		public async Task<IHttpActionResult> RevokeIndenity(long id, [FromBody] RevokeIdentities revokeIdentities)
		{
			var identity = await _service.IdentitiesService.RevokeIdentitiesAsync(id, revokeIdentities);
			return Ok(identity);
		}
	}
}