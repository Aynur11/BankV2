using Bank.Dal.Accounts;

namespace Bank.DesktopClient.AddingCredit
{
    public interface IModel
    {
        IAccount GetAccount { get; }
    }
}
