using System;

namespace Homework_18.Models.Clients
{
    /// <summary>
    /// Физическое лицо.
    /// </summary>
    public class PhysicalPersonClient : ClientBase
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
