using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class EF6EmployeeContext : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .Map<FullTimeEmployee>(m => m.Requires("EmployeeType")
                    .HasValue(1))
                .Map<HourlyEmployee>(m => m.Requires("EmployeeType")
                    .HasValue(2));
        }

    }
}
