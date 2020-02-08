using System.Collections.Generic;

namespace Recipes.AuditColumns
{
    public interface IAuditColumnsScenario<TDepartment>
       where TDepartment : class, IDepartment, new()
    {
        int CreateDepartment(TDepartment department, User user);

        void UpdateDepartment(TDepartment department, User user);

        TDepartment GetDepartment(int departmentKey);
    }
}