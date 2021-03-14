using Model;
using Model.Clients;
using System;

namespace Controller
{
    public class TestData
    {
        private readonly BankContext context;

        public TestData()
        {
            context = new BankContext();
        }

        public void FillAllTables()
        {
            context.PhysicalPersonClients.Add(
                new PhysicalPersonClient("Леонид", "Кравцов", "Григорьевич", new DateTime(1990, 02, 28), ClientType.Vip)
            );
            context.PhysicalPersonClients.Add(
                new PhysicalPersonClient("Николай", "Савелин", "Константинович", new DateTime(1987, 4, 22), ClientType.Usual)
            );

            context.LegalPersonClients.Add(
                new LegalPersonClient("ОАО Прогрессивные технологии", ClientType.Usual)
            );
            context.LegalPersonClients.Add(
                new LegalPersonClient("ООО Сельхозстрой", ClientType.Vip)
            );
            context.SaveChanges();
        }
    }
}