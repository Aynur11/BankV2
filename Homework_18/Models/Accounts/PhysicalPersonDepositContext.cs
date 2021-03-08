using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Homework_18.Models.Accounts
{
    public class PhysicalPersonDepositContext : DbContext
    {
        public PhysicalPersonDepositContext(DbContextOptions<PhysicalPersonDepositContext> options) : base(options)
        {

        }

        public DbSet<PhysicalPersonDeposit> Deposits { get; set; }
    }
}