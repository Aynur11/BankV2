namespace Bank.BLL
{
    /// <summary>
    /// Операции доступные клиентам.
    /// </summary>
    interface IOperations
    {
        /// <summary>
        /// Внесение денег.
        /// </summary>
        /// <param name="clientId">Идентификатор клиента.</param>
        /// <param name="accountId">Идентификтаор счета.</param>
        /// <param name="amount">Сумма денег.</param>
        void AddMoney(int clientId, int accountId, double amount);

        /// <summary>
        /// Открытие депозита.
        /// </summary>
        /// <param name="clientId">Идентификатор клиента.</param>
        /// <param name="amount">Сумма денег.</param>
        void OpenDeposit(int clientId, double amount);

        /// <summary>
        /// Выдача кредита.
        /// </summary>
        /// <param name="clientId">Идентификатор клиента.</param>
        /// <param name="amount">Сумма денег.</param>
        void IssueCredit(int clientId, double amount);

        /// <summary>
        /// Перевод денег.
        /// </summary>
        /// <param name="fromClientId">Идентификатор выполняющего перевод.</param>
        /// <param name="toClientId">Идентификатор принимающего перевод.</param>
        /// <param name="amount">Сумма денег.</param>
        void TransferMoney(int fromClientId, int toClientId, double amount);
    }
}