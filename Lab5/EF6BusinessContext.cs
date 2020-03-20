using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class EF6BusinessContext : DbContext
    {
        public virtual DbSet<Business> Businesses { get; set; }
    }
}
