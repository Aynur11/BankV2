﻿using Bank.Dal.Accounts;

namespace Bank.DesktopClient.AddingPhysicalPersonCredit
{
    public interface IView
    {
        /// <summary>
        /// Сумма денег с проверкой коррекности ввода.
        /// </summary>
        decimal Amount { get; }

        /// <summary>
        /// Период ведения счета с проверкой корректности ввода.
        /// </summary>
        int Period { get; }

        /// <summary>
        /// Выбранная валюта.
        /// </summary>
        Currency Currency { get; }

        /// <summary>
        /// Получить счет.
        /// </summary>
        IAccount GetAccount { get; }
    }
}