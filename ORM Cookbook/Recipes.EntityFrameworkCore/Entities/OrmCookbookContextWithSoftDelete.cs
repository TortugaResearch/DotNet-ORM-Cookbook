using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Recipes.EntityFrameworkCore.Entities
{
    public class OrmCookbookContextWithSoftDelete : OrmCookbookContext
    {
        public OrmCookbookContextWithSoftDelete(DbContextOptions<OrmCookbookContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException(nameof(modelBuilder), $"{nameof(modelBuilder)} is null.");

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }

        public override int SaveChanges()
        {
            // Get deleted entries
            var deletedEntryCollection = ChangeTracker.Entries<ISoftDeletable>()
                .Where(p => p.State == EntityState.Deleted);

            // Set flags on deleted entries
            foreach (var entry in deletedEntryCollection)
            {
                entry.State = EntityState.Modified;
                entry.Entity.IsDeleted = true;
            }

            return base.SaveChanges();
        }
    }
}
