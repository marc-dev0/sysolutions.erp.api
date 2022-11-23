namespace Sysolutions.Erp.Application.Services.Accounts.Queries.GetAccountById
{
    public class GetAccountByIdResponse
    {
        public int AccountId { get; set; }
        public string Client { get; set; }
        public string Secret { get; set; }
        public string IdentificationDocument { get; set; }
        public string StateDescription { get; set; }
        public string State { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
    }
}
