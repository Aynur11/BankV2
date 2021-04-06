using System.ComponentModel.DataAnnotations.Schema;
using Bank.Dal.Accounts;
using Bank.Dal.Clients;

namespace Bank.Dal.OperationsArchive
{
    /// <summary>
    /// История операций по депозиту для физ. лиц.
    /// </summary>
    public class PhysicalPersonDepositArchive : IAccountArchive
    {
        public PhysicalPersonDepositArchive(decimal amount, Operation operation, int accountId)
        {
            Amount = amount;
            Operation = operation;
            AccountId = accountId;
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
        public int AccountId { get; set; }

        /// <summary>
        /// Депозит физ. лица.
        /// </summary>
        [ForeignKey(nameof(AccountId))]
        public PhysicalPersonDeposit Deposit { get; set; }
    }
}