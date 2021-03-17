using System.ComponentModel.DataAnnotations.Schema;
using Model.Accounts;
using Model.Clients;

namespace Model.OperationsArchive
{
    /// <summary>
    /// История операций по счету для юр. лиц.
    /// </summary>
    public class LegalPersonAccountArchive
    {
        public LegalPersonAccountArchive(decimal amount, Operations operation, int legalPersonAccountId)
        {
            Amount = amount;
            Operation = operation;
            LegalPersonAccountId = legalPersonAccountId;
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
        /// ID счета юр. лица.
        /// </summary>
        public int LegalPersonAccountId { get; set; }

        /// <summary>
        /// Депозит физ. лица.
        /// </summary>
        [ForeignKey(nameof(LegalPersonAccountId))]
        public LegalPersonAccount Account { get; set; }
    }
}