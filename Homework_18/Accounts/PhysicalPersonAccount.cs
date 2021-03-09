using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_18.Models.Accounts
{
    public class PhysicalPersonAccount
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public double Rate { get; set; } = 0;
    }
}
