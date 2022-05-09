using System.Collections.Generic;

namespace UserProfileApi.Models
{
    public class EntitlementType1
    {
        public string value { get; set; }
    }

    public class EntitlementType2
    {
        public string value { get; set; }
    }

    public class AccountInfoCreate
    {
        //[JsonProperty("Request number")]
        public string RequestNumber { get; set; }
        public string AccountOwner { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public string AccountStatus { get; set; }
        public string IsPrivileged { get; set; }
        public string AccountDescription { get; set; }
        public string ExpiryDate { get; set; }
        public string password { get; set; }

        //[JsonProperty("<Entitlement type1>")]
        public List<EntitlementType1> EntitlementType1 { get; set; }

        //[JsonProperty("<Entitlement type2>")]
        public List<EntitlementType2> EntitlementType2 { get; set; }
    }
}