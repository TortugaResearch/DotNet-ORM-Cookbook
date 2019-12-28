using Recipes.Models;
using System.Collections.Generic;

namespace Recipes.Repositories
{
    public interface IDepartmentWithChildRepository<TDepartment, TDivision>
            where TDepartment : IDepartment<TDivision>, new()
            where TDivision : IDivision
    {
        TDepartment GetByKey(int departmentKey);

        IList<TDepartment> GetAll();

        int Create(TDepartment department);
        void Update(TDepartment department);
        void Delete(TDepartment department);
        void Delete(int departmentKey);
        IList<TDivision> GetAllDivisions();
    }
}
