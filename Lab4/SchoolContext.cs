using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace EFConsole6
{
    public class SchoolContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public SchoolContext() : base() { }

        public Microsoft.EntityFrameworkCore.DbSet<Student> Students { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Grade> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = DESKTOP-EEBEU5F\\SQLEXPRESS; Database = TestPerson; Trusted_Connection = True");
            //ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>()
                .HasMany<Student>(s => s.Students)
                .WithOne(g => g.Grade);
        }
    }
}
