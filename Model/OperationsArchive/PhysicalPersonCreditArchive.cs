using Bank.DAL.Accounts;
using System.ComponentModel.DataAnnotations.Schema;
using Bank.DAL.Clients;

namespace Bank.DAL.OperationsArchive
{
    /// <summary>
    /// История операций по кредиту для физ. лиц.
    /// </summary>
    public class PhysicalPersonCreditArchive
    {
        public PhysicalPersonCreditArchive(decimal amount, Operations operation, int physicalPersonCreditId)
        {
            Amount = amount;
            Operation = operation;
            PhysicalPersonCreditId = physicalPersonCreditId;
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
        public Operations Operation { get; set; }

        /// <summary>
        /// ID кредита физ. лица.
        /// </summary>
        public int PhysicalPersonCreditId { get; set; }

        /// <summary>
        /// Кредит физ. лица.
        /// </summary>
        [ForeignKey(nameof(PhysicalPersonCreditId))]
        public PhysicalPersonCredit Credit { get; set; }
    }
}