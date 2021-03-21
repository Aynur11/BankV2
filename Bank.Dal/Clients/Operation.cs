namespace Bank.Dal.Clients
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