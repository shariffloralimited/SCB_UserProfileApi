using System.Collections.Generic;

namespace UserProfileApi.Models
{
    public class EntitlementInfo
    {
        public string AccountOwner { get; set; }
        public string AccountName { get; set; }

        //[JsonProperty("<Entitlement Name>")]
        public List<EntitlementName> EntitlementName { get; set; }
    }

    public class EntitlementName
    {
        public string Name { get; set; }
    }
}