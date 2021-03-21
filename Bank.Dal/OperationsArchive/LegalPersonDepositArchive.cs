using System.ComponentModel.DataAnnotations.Schema;
using Bank.Dal.Accounts;
using Bank.Dal.Clients;

namespace Bank.Dal.OperationsArchive
{
    /// <summary>
    /// История операций по депозиту для юр. лиц.
    /// </summary>
    public class LegalPersonDepositArchive
    {
        public LegalPersonDepositArchive(decimal amount, Operation operation, int legalPersonDepositId)
        {
            Amount = amount;
            Operation = operation;
            LegalPersonDepositId = legalPersonDepositId;
        }
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Сумма денег, задействованная при выполнеии операции.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Выполненная операция.
        /// </summary>
        public Operation Operation { get; set; }

        /// <summary>
        /// ID депозита юр. лица.
        /// </summary>
        public int LegalPersonDepositId { get; set; }

        /// <summary>
        /// Депозит физ. лица.
        /// </summary>
        [ForeignKey(nameof(LegalPersonDepositId))]
        public LegalPersonDeposit Deposit { get; set; }
    }
}