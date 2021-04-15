using Bank.Dal.Accounts;

namespace Bank.DesktopClient.AddingAccountWindow
{
    public interface IModelAddingAnyAccountWindow
    {
        IAccount GetAccount { get; }
    }
}
