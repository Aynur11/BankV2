using System;
using System.Collections.Generic;
using Bank.Dal.Accounts;

namespace Bank.Dal
{
    /// <summary>
    /// Интерфейс взаимодействия с таблицами.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IRepository<T> : IDisposable
        where T : class
    {
        /// <summary>
        /// Формирует список клиентов.
        /// </summary>
        /// <returns>Список клиентов.</returns>
        List<T> GetClients();

        /// <summary>
        /// Получить список ID всех счетов клиента.
        /// </summary>
        /// <param name="clientId">ID клиента.</param>
        /// <returns></returns>
        List<int> GetAllClientAccountsId(int clientId);

        /// <summary>
        /// Добавить счет.
        /// </summary>
        /// <param name="clientId">ID клиента.</param>
        /// <param name="currency">Валюта.</param>
        /// <param name="amount">Сумма денег для внесения на счет.</param>
        /// <param name="rate">Возможная ставка в процентах.</param>
        void AddAccount(int clientId, Currency currency, decimal amount, decimal rate = 0);

        /// <summary>
        /// Выдать кредит.
        /// </summary>
        /// <param name="clientId">ID клиента.</param>
        /// <param name="currency">Валюта.</param>
        /// <param name="amount">Сумма денег для выдачи.</param>
        /// <param name="period"></param>
        /// <param name="rate">Ставка в процентах.</param>
        void AddCredit(int clientId, Currency currency, decimal amount, int period, decimal rate);

        /// <summary>
        /// Открыть депозит.
        /// </summary>
        /// <param name="clientId">ID клиента.</param>
        /// <param name="currency">Валюта.</param>
        /// <param name="amount">Сумма денег для внесения в депозит.</param>
        /// <param name="period"></param>
        /// <param name="withCapitalization">С капитализацией?</param>
        /// <param name="rate">Ставка в процентах.</param>
        void AddDeposit(int clientId, Currency currency, decimal amount, int period, bool withCapitalization, decimal rate);

        /// <summary>
        /// Перевод денег.
        /// </summary>
        /// <param name="fromClientId">Идентификатор выполняющего перевод.</param>
        /// <param name="fromAccountId">ID счета для списания денег.</param>
        /// <param name="toClientId">Идентификатор принимающего перевод.</param>
        /// <param name="toAccountId">ID счета для внесения денег.</param>
        /// <param name="amount">Сумма денег.</param>
        //void TransferMoney(int fromClientId, int fromAccountId, int toClientId, int toAccountId, decimal amount);
    }
}