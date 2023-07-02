namespace Entities.Exceptions
{
    public class OrganizationCodeParameterBadRequest : BadRequestException
    {
        public OrganizationCodeParameterBadRequest() : base("Organization code is null")
        {
        }
    }
}
