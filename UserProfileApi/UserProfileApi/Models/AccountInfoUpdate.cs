namespace UserProfileApi.Models
{
    public class AccountInfoUpdate
    {
        public string AccountOwner { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public string IsPrivileged { get; set; }
        public string AccountDescription { get; set; }
        public string ExpiryDate { get; set; }
    }
}