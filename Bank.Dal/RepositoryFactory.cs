using System;
using Bank.Dal.Accounts;

namespace Bank.Dal
{
    public static class RepositoryFactory
    {
        public static IRepositoryHistory GetRepository(IAccount account)
        {
            if (account is PhysicalPersonAccount || account is PhysicalPersonCredit || account is PhysicalPersonDeposit)
            {
                return new PhysicalPersonClientRepository();
            }

            if (account is LegalPersonAccount || account is LegalPersonCredit || account is LegalPersonDeposit)
            {
                return new LegalPersonClientRepository();
            }
            return null;
        }
    }
}
