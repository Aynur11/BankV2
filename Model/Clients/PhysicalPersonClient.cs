using System;
using System.Collections.Generic;
using Model.Accounts;

namespace Model.Clients
{
    /// <summary>
    /// Физическое лицо.
    /// </summary>
    public class PhysicalPersonClient
    {
        public PhysicalPersonClient(string firstName, string lastName, string middleName, DateTime birthDay)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            BirthDay = birthDay;
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
        public DateTime BirthDay { get; set; }

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
