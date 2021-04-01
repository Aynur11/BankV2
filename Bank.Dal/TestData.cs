using System;
using Bank.Dal.Clients;

namespace Bank.Dal
{
    /// <summary>
    /// Содержит тестовые данные для заполнения БД.
    /// </summary>
    public class TestData
    {
        /// <summary>
        /// Тестовые данные для заполнения таблиц.
        /// </summary>
        public void FillAllTables()
        {
            using (BankContext context = new BankContext())
            {
                context.PhysicalPersonClients.Add(
                    new PhysicalPersonClient("Леонид", "Кравцов", "Григорьевич", new DateTime(1990, 02, 28),
                        ClientType.Vip)
                );
                context.PhysicalPersonClients.Add(
                    new PhysicalPersonClient("Николай", "Савелин", "Константинович", new DateTime(1987, 4, 22),
                        ClientType.Usual)
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
}