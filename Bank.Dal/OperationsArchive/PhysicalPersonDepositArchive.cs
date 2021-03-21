using System.ComponentModel.DataAnnotations.Schema;
using Bank.Dal.Accounts;
using Bank.Dal.Clients;

namespace Bank.Dal.OperationsArchive
{
    /// <summary>
    /// История операций по депозиту для физ. лиц.
    /// </summary>
    public class PhysicalPersonDepositArchive
    {
        public PhysicalPersonDepositArchive(decimal amount, Operation operation, int physicalPersonDepositId)
        {
            Amount = amount;
            Operation = operation;
            PhysicalPersonDepositId = physicalPersonDepositId;
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
        /// ID депозита физ. лица.
        /// </summary>
        public int PhysicalPersonDepositId { get; set; }

        /// <summary>
        /// Депозит физ. лица.
        /// </summary>
        [ForeignKey(nameof(PhysicalPersonDepositId))]
        public PhysicalPersonDeposit Deposit { get; set; }
    }
}