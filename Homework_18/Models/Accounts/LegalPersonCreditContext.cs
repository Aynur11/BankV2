using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Homework_18.Models.Accounts
{
    public class LegalPersonCreditContext : DbContext
    {
        public LegalPersonCreditContext(DbContextOptions<LegalPersonCreditContext> options) : base(options)
        {

        }

        public DbSet<LegalPersonCredit> Credits { get; set; }
    }
}
