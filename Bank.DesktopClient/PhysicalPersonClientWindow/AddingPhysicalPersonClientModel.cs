using System;

namespace Bank.DesktopClient.PhysicalPersonClientWindow
{
    public class AddingPhysicalPersonClientModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsVip { get; set; }
    }
}