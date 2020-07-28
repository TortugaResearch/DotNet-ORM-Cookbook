using System.Collections.Generic;

namespace Recipes.QueryFilter
{
    public interface IQueryFilterScenario<TStudent>
        where TStudent : class, IStudent, new()
    {
        IList<TStudent> GetStudents(int schoolId);

        void InsertBatch(IList<TStudent> students);
    }
}
