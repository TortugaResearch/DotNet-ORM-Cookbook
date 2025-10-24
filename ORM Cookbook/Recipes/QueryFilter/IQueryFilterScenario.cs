namespace Recipes.QueryFilter;

public interface IQueryFilterScenario<TStudent>
    where TStudent : class, IStudent, new()
{
    IList<TStudent> GetStudents(int schoolId);
}