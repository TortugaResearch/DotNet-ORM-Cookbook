using Microsoft.EntityFrameworkCore;
using Recipes.EntityFrameworkCore.QueryFilter.Helpers;

namespace Recipes.EntityFrameworkCore.Entities;

public class OrmCookbookContextWithQueryFilter : OrmCookbookContext
{
    public int SchoolId { get; }

    public OrmCookbookContextWithQueryFilter(DbContextOptions<OrmCookbookContext> options, int schoolId)
: base(options)
    {
        SchoolId = schoolId;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder == null)
            throw new ArgumentNullException(nameof(modelBuilder), $"{nameof(modelBuilder)} is null.");

        base.OnModelCreating(modelBuilder);

        //The ISchool interface is applied to all entities that need to be filtered by tenant.
        modelBuilder.SetQueryFilterOnAllEntities<ISchool>(s => s.SchoolId == SchoolId);
    }
}