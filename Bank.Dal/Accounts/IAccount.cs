namespace Bank.Dal.Accounts
{
    public interface IAccount
    {
        int Id { get; set; }
        int ClientId { get; set; }
        decimal Amount { get; set; }
        Currency Currency { get; set; }
    }
}