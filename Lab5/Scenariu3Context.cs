using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Scenariu3Context : DbContext
    {
        public virtual DbSet<Photograph> Photographs{ get; set; }

        public virtual DbSet<PhotographFullImage> PhotographFullImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Photograph>()
                .HasRequired(p => p.PhotographFullImage)
                .WithRequiredPrincipal(p => p.Photograph);
            modelBuilder.Entity<Photograph>()
                .ToTable("Photograph", "BazaDeDate");
            modelBuilder.Entity<PhotographFullImage>()
                .ToTable("Photograph", "BazaDeDate");
        }

    }
}
