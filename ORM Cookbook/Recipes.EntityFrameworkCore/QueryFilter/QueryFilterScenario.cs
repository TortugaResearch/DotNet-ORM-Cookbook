using Recipes.EntityFrameworkCore.Entities;
using Recipes.QueryFilter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.EntityFrameworkCore.QueryFilter
{
    public class QueryFilterScenario : IQueryFilterScenario<Student>
    {
        private readonly Func<OrmCookbookContext> CreateDbContext;

        public QueryFilterScenario(Func<OrmCookbookContext> dBContextFactory)
        {
            CreateDbContext = dBContextFactory;
        }

        public IList<Student> GetStudents(int schoolId)
        {
            using (var context = CreateDbContext())
            {
                context.SchoolId = schoolId;
                return context.Students.OrderBy(s => s.Name).ToList(); 
            }
        }

        public void InsertBatch(IList<Student> students)
        {
            using (var context = CreateDbContext())
            {
                context.Students.AddRange(students);
                context.SaveChanges();
            }
        }
    }
}
