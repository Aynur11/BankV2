using Bank.Dal.Clients;

namespace Bank.Bll
{
    /// <summary>
    /// Расчет ставки.
    /// </summary>
    public class Rate
    {
        /// <summary>
        /// Ставка депозита для физ. лиц.
        /// </summary>
        /// <param name="clientType">Тип клиента.</param>
        /// <returns>Ставка.</returns>
        public decimal CalcPhysicalPersonDepositRate(ClientType clientType)
        {
            return clientType == ClientType.Usual ? 3.15m : 4.5m;
        }

        /// <summary>
        /// Ставка кредита для физ. лиц.
        /// </summary>
        /// <param name="clientType">Тип клиента.</param>
        /// <returns>Ставка.</returns>
        public decimal CalcPhysicalPersonCreditRate(ClientType clientType)
        {
            return clientType == ClientType.Usual ? 20.05m : 15.25m;
        }

        /// <summary>
        /// Ставка депозита для юр. лиц.
        /// </summary>
        /// <param name="clientType">Тип клиента.</param>
        /// <returns>Ставка.</returns>
        public decimal CalcLegalPersonDepositRate(ClientType clientType)
        {
            return clientType == ClientType.Usual ? 2.05m : 3.55m;
        }

        /// <summary>
        /// Ставка кредита для юр. лиц.
        /// </summary>
        /// <param name="clientType">Тип клиента.</param>
        /// <returns>Ставка.</returns>
        public decimal CalcLegalPersonCreditRate(ClientType clientType)
        {
            return clientType == ClientType.Usual ? 18.05m : 14.65m;
        }
    }
}
