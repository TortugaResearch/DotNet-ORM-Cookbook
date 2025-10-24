using System.Data.Entity;

namespace Recipes.EntityFramework.Entities;

public class OrmCookbookContextWithUser : OrmCookbookContext
{
    readonly User m_User;

    public OrmCookbookContextWithUser(string nameOrConnectionString, bool lazyLoadingEnabled, User user)
: base(nameOrConnectionString, lazyLoadingEnabled)
    {
        m_User = user;
    }

    public override int SaveChanges()
    {
        // Get added entries
        var addedEntryCollection = ChangeTracker.Entries<IAuditableEntity>()
           .Where(p => p.State == EntityState.Added)
           .Select(p => p.Entity);

        // Get modified entries
        var modifiedEntryCollection = ChangeTracker.Entries<IAuditableEntity>()
          .Where(p => p.State == EntityState.Modified)
          .Select(p => p.Entity);

        // Set audit fields of added entries
        foreach (var addedEntity in addedEntryCollection)
        {
            addedEntity.CreatedDate = DateTime.Now;
            addedEntity.CreatedByEmployeeKey = m_User.UserKey;
            addedEntity.ModifiedDate = DateTime.Now;
            addedEntity.ModifiedByEmployeeKey = m_User.UserKey;
        }

        // Set audit fields of modified entries
        foreach (var modifiedEntity in modifiedEntryCollection)
        {
            modifiedEntity.ModifiedDate = DateTime.Now;
            modifiedEntity.ModifiedByEmployeeKey = m_User.UserKey;
        }

        return base.SaveChanges();
    }
}