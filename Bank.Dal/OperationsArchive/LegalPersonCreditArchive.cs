using System.ComponentModel.DataAnnotations.Schema;
using Bank.Dal.Accounts;
using Bank.Dal.Clients;

namespace Bank.Dal.OperationsArchive
{
    /// <summary>
    /// История операций по кредиту для юр. лиц.
    /// </summary>
    public class LegalPersonCreditArchive
    {
        public LegalPersonCreditArchive(decimal amount, Operation operation, int legalPersonCreditId)
        {
            Amount = amount;
            Operation = operation;
            LegalPersonCreditId = legalPersonCreditId;
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
        /// ID кредита юр. лица.
        /// </summary>
        public int LegalPersonCreditId { get; set; }

        /// <summary>
        /// Кредит юр. лица.
        /// </summary>
        [ForeignKey(nameof(LegalPersonCreditId))]
        public LegalPersonCredit Credit { get; set; }
    }
}
