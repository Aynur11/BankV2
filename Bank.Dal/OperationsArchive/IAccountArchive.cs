using Bank.Dal.Accounts;
using Bank.Dal.Clients;

namespace Bank.Dal.OperationsArchive
{
    public interface IAccountArchive
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Сумма денег, задействованная при выполнеии операции.
        /// </summary>
        decimal Amount { get; set; }

        /// <summary>
        /// Выполненная операция.
        /// </summary>
        Operation Operation { get; set; }

        /// <summary>
        /// ID счета юр. лица.
        /// </summary>
        int AccountId { get; set; }
    }
}