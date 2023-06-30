using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class OrganizationCodeParameterBadRequest : BadRequestException
    {
        public OrganizationCodeParameterBadRequest() : base("Organization code is null")
        {
        }
    }
}
