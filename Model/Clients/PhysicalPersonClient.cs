using Bank.DAL.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.DAL.Clients
{
    /// <summary>
    /// Физическое лицо.
    /// </summary>
    public class PhysicalPersonClient
    {
        public PhysicalPersonClient(string firstName, string lastName, string middleName, DateTime birthday, ClientType type)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Birthday = birthday;
            Type = type;
        }
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }


        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// День рождения.
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Привилегии для клиента.
        /// </summary>
        public ClientType Type { get; set; }

        /// <summary>
        /// Список счетов клиента.
        /// </summary>
        public List<PhysicalPersonAccount> Accounts { get; set; }

        /// <summary>
        /// Список кредитов клиента.
        /// </summary>
        public List<PhysicalPersonCredit> Credits { get; set; }

        /// <summary>
        /// Список депозитов клиента.
        /// </summary>
        public List<PhysicalPersonDeposit> Deposits { get; set; }
    }
}
