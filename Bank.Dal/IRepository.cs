using Bank.Dal.Accounts;
using System;
using System.Collections.Generic;

namespace Bank.Dal
{
    /// <summary>
    /// Интерфейс взаимодействия с таблицами.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    public interface IRepository<T> : IDisposable
        where T : class
    {
        /// <summary>
        /// Формирует список клиентов.
        /// </summary>
        /// <returns>Список клиентов.</returns>
        List<T> GetClients();

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
        
        ///// <summary>
        ///// Возвращает все счета клиента.
        ///// </summary>
        ///// <param name="clientId">Номер клиента.</param>
        ///// <returns>Все счета.</returns>
        //List<T> GetAllClientAccounts(int clientId);

        ///// <summary>
        ///// Возвращает все депозиты клиента.
        ///// </summary>
        ///// <param name="clientId">Номер клиента.</param>
        ///// <returns>Все депозиты.</returns>
        //List<T3> GetAllClientDeposits(int clientId);

        ///// <summary>
        ///// Возвращает все кредиты клиента.
        ///// </summary>
        ///// <param name="clientId">Номер клиента.</param>
        ///// <returns>Все кредиты.</returns>
        //List<T2> GetAllClientCredits(int clientId);

        /// <summary>
        /// Добавляет клиента.
        /// </summary>
        /// <param name="client">Добавляемый клент.</param>
        void AddClient(T client);

        /// <summary>
        /// Удаляет клиента.
        /// </summary>
        /// <param name="client">Удаляемый клиент.</param>
        void RemoveClient(T client);

        /// <summary>
        /// Выполняет сохранение.
        /// </summary>
        void Save();

        /// <summary>
        /// Выполняет сохранение.
        /// </summary>
        /// <param name="client">Отредактированный клиент.</param>
        void Update(T client);
    }
}