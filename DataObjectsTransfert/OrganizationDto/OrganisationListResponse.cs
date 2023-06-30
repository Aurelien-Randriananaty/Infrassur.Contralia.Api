using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataObjectsTransfert.OrganizationDto
{
    //[JsonObject("organizations")]
    public class OrganisationListResponse
    {
        //[JsonProperty("organization")]
        public List<OrganizationList> OrganizationList { get; set; }
    }

    //[JsonObject("organization")]
    public class OrganizationList
    {
        //[JsonProperty("code")]
        public string  Code { get; set; }
    }
}
