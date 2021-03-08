using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Homework_18.Models.Accounts
{
    public class PhysicalPersonAccountContext : DbContext
    {
        public PhysicalPersonAccountContext(DbContextOptions<PhysicalPersonAccountContext> options) : base(options)
        {

        }

        public DbSet<PhysicalPersonAccount> Accounts { get; set; }
    }
}
