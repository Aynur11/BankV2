using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Clients;

namespace Controller
{
    class Class1
    {
        private BankContext context;

        public Class1()
        {
            context = new BankContext();
            context.PhysicalPersonClients.Add(
                new PhysicalPersonClient("Ivan", "Ivanov", "Ivanovich", Convert.ToDateTime("10.10.1990"))
                );
            context.SaveChanges();
        }
    }
}
