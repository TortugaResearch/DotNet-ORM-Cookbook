using Recipes.EntityFrameworkCore.Entities;
using Recipes.QueryFilter;

namespace Recipes.EntityFrameworkCore.QueryFilter;

public class QueryFilterScenario : IQueryFilterScenario<Student>
{
    private readonly Func<int, OrmCookbookContextWithQueryFilter> CreateFilteredDbContext;

    public QueryFilterScenario(Func<int, OrmCookbookContextWithQueryFilter> dBContextFactory)
    {
        CreateFilteredDbContext = dBContextFactory;
    }

    public IList<Student> GetStudents(int schoolId)
    {
        using (var context = CreateFilteredDbContext(schoolId))
        {
            //SchoolId filter is automatically applied
            return context.Students.OrderBy(s => s.Name).ToList();
        }
    }
}