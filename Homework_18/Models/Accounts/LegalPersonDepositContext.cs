using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Homework_18.Models.Accounts
{
    public class LegalPersonDepositContext : DbContext
    {
        public LegalPersonDepositContext(DbContextOptions<LegalPersonDepositContext> options) : base(options)
        {

        }

        public DbSet<LegalPersonDeposit> Deposits { get; set; }
    }
}
