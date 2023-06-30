using Entities.Organization;
using Infrassur.Contralia.Api.Contracts.Service;
using System.Threading.Tasks;
using System.Web.Http;

namespace Infrassur.Contralia.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class OrganizationController : ApiController
    {
        private readonly IServiceManager _service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public OrganizationController(IServiceManager service) => _service = service;

        /// <summary>
        /// Créer un fournisseur associé au compte
        /// </summary>
        /// <param name="requestReference"></param>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/organisation/create")]
        public async Task<IHttpActionResult> CreateOrganization([FromBody] Organization organization, string requestReference = null)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }

            var organisation = await _service.OrganisationService.CreateOrganization(requestReference, organization);

            return Ok(organisation);
        }

        /// <summary>
        /// Retourne la configuration du fourniseur et les informations des fournisseur
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/organisation/fetch")]
        public async Task<IHttpActionResult> GetOrganization([FromBody] OrganizationGet organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organisation = await _service.OrganisationService.GetOrganizations(organization);

            return Ok(organisation);
        }

        /// <summary>
        /// Liste les codes de fournisseurs associés au compte
        /// </summary>
        /// <param name="requestReference"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/organisation/list")]
        public async Task<IHttpActionResult> GetOrganization(string requestReference = null)
        {
            var organisation = await _service.OrganisationService.GetOrganizationsList(requestReference);

            return Ok(organisation);
        }

        /// <summary>
        /// Retourne les contraintes associées au compte.
        /// </summary>
        /// <param name="requestReference"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/organisation/constraints")]
        public async Task<IHttpActionResult> GetOrganizationConstraints(string requestReference = null)
        {
            var organisation = await _service.OrganisationService.GetOrganizationConstraints(requestReference);

            return Ok(organisation);
        }
    }
}