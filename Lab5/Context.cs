namespace Lab5
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class ModelSelfReferences : DbContext
    {
        public ModelSelfReferences()
            : base("name=ModelSelfReferences")
        {
        }

        public virtual DbSet<SelfReference> SelfReferences { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SelfReference>()
                .HasMany(m => m.References)
                .WithOptional(m => m.ParentSelfReference);
        }
    }

    public class ScenariuUnu
    {
        public void AddReference(SelfReference selfReference)
        {
            using (var context = new ModelSelfReferences())
            {
                context.SelfReferences.Add(selfReference);
                context.SaveChanges();
            }
        }

        public List<SelfReference> GetAllReferences()
        {
            using (var context = new ModelSelfReferences())
            {
                return context.SelfReferences.ToList();
            }
        }
    }
}