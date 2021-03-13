namespace Model.Clients
{
    /// <summary>
    /// Возможные операции со счетами.
    /// </summary>
    public enum Operations : byte
    {
        AddMoney,
        OpenDeposit,
        IssueCredit,
        TransferMoney
    }
}