using Bank.Dal.Accounts;
using System;
using System.Collections.Generic;

namespace Bank.Dal
{
    /// <summary>
    /// Интерфейс взаимодействия с таблицами.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    interface IRepository<T1, T2, T3, T4, T5, T6> : IDisposable
        where T1 : class
    {
        /// <summary>
        /// Формирует список клиентов.
        /// </summary>
        /// <returns>Список клиентов.</returns>
        List<T1> GetClients();

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
        /// Возвращает историю операция по кредиту.
        /// </summary>
        /// <param name="accountId">Номер счета.</param>
        /// <returns>История операций.</returns>
        List<T6> GetCreditHistory(int accountId);

        /// <summary>
        /// Возвращает историю операция по счету.
        /// </summary>
        /// <param name="accountId">Номер счета.</param>
        /// <returns>История операций.</returns>
        List<T5> GetAccountHistory(int accountId);

        /// <summary>
        /// Возвращает все счета клиента.
        /// </summary>
        /// <param name="clientId">Номер клиента.</param>
        /// <returns>Все счета.</returns>
        List<T4> GetAllClientAccounts(int clientId);

        /// <summary>
        /// Возвращает все депозиты клиента.
        /// </summary>
        /// <param name="clientId">Номер клиента.</param>
        /// <returns>Все депозиты.</returns>
        List<T3> GetAllClientDeposits(int clientId);

        /// <summary>
        /// Возвращает все кредиты клиента.
        /// </summary>
        /// <param name="clientId">Номер клиента.</param>
        /// <returns>Все кредиты.</returns>
        List<T2> GetAllClientCredits(int clientId);

        /// <summary>
        /// Добавляет клиента.
        /// </summary>
        /// <param name="client">Добавляемый клент.</param>
        void AddClient(T1 client);

        /// <summary>
        /// Удаляет клиента.
        /// </summary>
        /// <param name="client">Удаляемый клиент.</param>
        void RemoveClient(T1 client);

        /// <summary>
        /// Выполняет сохранение.
        /// </summary>
        void Save();

        /// <summary>
        /// Выполняет сохранение.
        /// </summary>
        /// <param name="client">Отредактированный клиент.</param>
        void Update(T1 client);
    }
}