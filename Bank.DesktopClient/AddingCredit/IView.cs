using Bank.Dal.Accounts;

namespace Bank.DesktopClient.AddingCredit
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


        IAccount GetAccount { get; }
    }
}
