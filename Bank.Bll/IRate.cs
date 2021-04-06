using Bank.Dal.Clients;

namespace Bank.Bll
{
    public interface IRate
    {
        /// <summary>
        /// Ставка депозита для физ. лиц.
        /// </summary>
        /// <param name="clientType">Тип клиента.</param>
        /// <returns>Ставка.</returns>
        decimal CalcPhysicalPersonDepositRate(ClientType clientType);

        /// <summary>
        /// Ставка кредита для физ. лиц.
        /// </summary>
        /// <param name="clientType">Тип клиента.</param>
        /// <returns>Ставка.</returns>
        decimal CalcPhysicalPersonCreditRate(ClientType clientType);

        /// <summary>
        /// Ставка депозита для юр. лиц.
        /// </summary>
        /// <param name="clientType">Тип клиента.</param>
        /// <returns>Ставка.</returns>
        decimal CalcLegalPersonDepositRate(ClientType clientType);

        /// <summary>
        /// Ставка кредита для юр. лиц.
        /// </summary>
        /// <param name="clientType">Тип клиента.</param>
        /// <returns>Ставка.</returns>
        decimal CalcLegalPersonCreditRate(ClientType clientType);
    }
}
