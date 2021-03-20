namespace Bank.DAL.Clients
{
    /// <summary>
    /// Возможные операции со счетами.
    /// </summary>
    public enum Operation : byte
    {
        AddAccount,
        AddDeposit,
        AddCredit,
        TransferMoney
    }
}