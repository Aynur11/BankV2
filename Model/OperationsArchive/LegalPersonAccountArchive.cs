using Model.Clients;

namespace Model.OperationsArchive
{
    /// <summary>
    /// История операций по счету для юр. лиц.
    /// </summary>
    public class LegalPersonAccountArchive
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Сумма денег, задействованная при выполнеии операции.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Выполненная операция.
        /// </summary>
        public Operations Operation { get; set; }

        /// <summary>
        /// Внешний ключ.
        /// </summary>
        public int LegalPersonAccountId { get; set; }
    }
}