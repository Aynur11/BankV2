using Bank.Dal.Accounts;

namespace Bank.DesktopClient.AddingPhysicalPersonCredit
{
    public interface IModel
    {
        IAccount GetAccount { get; }
    }
}
