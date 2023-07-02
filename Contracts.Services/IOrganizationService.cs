using DataObjectsTransfert.OrganizationDto;
using Entities.Organization;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IOrganizationService
    {
        Task<OrganizationSetDto> CreateOrganization(string requestReference, Organization organization);
        Task<OrganizationGetResponse> GetOrganizations(OrganizationGet organization);
        Task<OrganizationListResponse> GetOrganizationsList(string requestReference);
        Task<OrganizationConstraintsResponse> GetOrganizationConstraints(string requestReference);
    }
}
