namespace Bank.Dal.Accounts
{
    public interface IAccount
    {
        int ClientId { get; set; }
        decimal Amount { get; set; }
        Currency Currency { get; set; }
    }
}