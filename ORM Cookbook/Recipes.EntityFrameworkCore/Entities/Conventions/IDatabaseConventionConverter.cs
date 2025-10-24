using Microsoft.EntityFrameworkCore;

namespace Recipes.EntityFrameworkCore.Entities.Conventions;

public interface IDatabaseConventionConverter

{
    void SetConvention(ModelBuilder modelBuilder);
}