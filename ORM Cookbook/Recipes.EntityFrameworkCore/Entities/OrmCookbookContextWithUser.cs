using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Recipes.EntityFrameworkCore.Entities
{
    public class OrmCookbookContextWithUser : OrmCookbookContext
    {
        readonly User m_User;

        public OrmCookbookContextWithUser(DbContextOptions<OrmCookbookContext> options, User user)
    : base(options)
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
                addedEntity.CreatedDate = DateTime.UtcNow;
                addedEntity.CreatedByEmployeeKey = m_User.UserKey;
                addedEntity.ModifiedDate = DateTime.UtcNow;
                addedEntity.ModifiedByEmployeeKey = m_User.UserKey;
            }

            // Set audit fields of modified entries
            foreach (var modifiedEntity in modifiedEntryCollection)
            {
                modifiedEntity.ModifiedDate = DateTime.UtcNow;
                modifiedEntity.ModifiedByEmployeeKey = m_User.UserKey;
            }

            return base.SaveChanges();
        }
    }
}
