using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Dal.Accounts;

namespace Bank.DesktopClient.AddingAccountWindow
{
    public interface IModelAddingAnyAccountWindow
    {
        ///// <summary>
        ///// Сумма денег с проверкой коррекности ввода.
        ///// </summary>
        //decimal Amount { get; }

        ///// <summary>
        ///// Период ведения счета с проверкой корректности ввода.
        ///// </summary>
        //int Period { get; }

        ///// <summary>
        ///// Выбранная валюта.
        ///// </summary>
        //Currency Currency { get; }

        ///// <summary>
        ///// С капитализацией?
        ///// </summary>
        //bool WithCapitalization { get; }
        IAccount GetAccount { get; }
        void InitData(decimal amount, int period, Currency currency, bool withCapitalization);
    }
}
