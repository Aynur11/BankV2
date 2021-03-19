using Bank.DAL.Accounts;
using System.ComponentModel.DataAnnotations.Schema;
using Bank.DAL.Clients;

namespace Bank.DAL.OperationsArchive
{
    /// <summary>
    /// История операций по счету для физ. лиц.
    /// </summary>
    public class PhysicalPersonAccountArchive
    {
        public PhysicalPersonAccountArchive(decimal amount, Operations operation, int physicalPersonAccountId)
        {
            Amount = amount;
            Operation = operation;
            PhysicalPersonAccountId = physicalPersonAccountId;
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
        /// ID счета физ. лица.
        /// </summary>
        public int PhysicalPersonAccountId { get; set; }

        /// <summary>
        /// Счет физ. лица.
        /// </summary>
        [ForeignKey(nameof(PhysicalPersonAccountId))]
        public PhysicalPersonAccount Account { get; set; }
    }
}