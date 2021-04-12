using Bank.Dal.Accounts;

namespace Bank.DesktopClient.AddingAccountWindow
{
    public interface IViewAddingAnyAccountWindow
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
        /// С капитализацией?
        /// </summary>
        bool WithCapitalization { get; }

        IAccount GetAccount { get; }
    }
}
