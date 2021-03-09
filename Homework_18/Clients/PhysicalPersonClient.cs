using System;

namespace Homework_18.Models.Clients
{
    /// <summary>
    /// Физическое лицо.
    /// </summary>
    public class PhysicalPersonClient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
