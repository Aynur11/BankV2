using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_18.Models.Clients;
using Microsoft.EntityFrameworkCore;

namespace Homework_18.Models.Accounts
{
    public class LegalPersonAccountContext : DbContext
    {
        public LegalPersonAccountContext(DbContextOptions<LegalPersonAccountContext> options) : base(options)
        {

        }

        public DbSet<LegalPersonAccount> Accounts { get; set; }
    }
}
