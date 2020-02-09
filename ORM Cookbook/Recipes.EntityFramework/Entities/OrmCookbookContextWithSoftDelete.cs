using System.Data.Entity;
using System.Linq;

namespace Recipes.EntityFramework.Entities
{
    public class OrmCookbookContextWithSoftDelete : OrmCookbookContext
    {
        public OrmCookbookContextWithSoftDelete(string nameOrConnectionString, bool lazyLoadingEnabled)
: base(nameOrConnectionString, lazyLoadingEnabled)
        {
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
