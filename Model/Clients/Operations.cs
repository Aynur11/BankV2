namespace Model.Clients
{
    /// <summary>
    /// Возможные операции со счетами.
    /// </summary>
    public enum Operations : byte
    {
        AddAccount,
        AddDeposit,
        AddCredit,
        TransferMoney
    }
}