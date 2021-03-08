using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Homework_18.Models.Accounts
{
    public class PhysicalPersonCreditContext : DbContext
    {
        public PhysicalPersonCreditContext(DbContextOptions<PhysicalPersonCreditContext> options) : base(options)
        {

        }

        public DbSet<PhysicalPersonCredit> Credits { get; set; }
    }
}
