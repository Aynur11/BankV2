using Bank.Dal.Accounts;

namespace Bank.DesktopClient.AddingLegalPersonCredit
{
    public interface IModelLegalPersonCredit
    {
        IAccount GetAccount { get; }
    }
}
