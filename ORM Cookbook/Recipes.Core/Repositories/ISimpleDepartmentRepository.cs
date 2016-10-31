using Recipes.Models;
using System.Collections.Generic;

namespace Recipes.Repositories
{
    public interface ISimpleDepartmentRepository<TDepartment>
        where TDepartment : IDepartment, new()
    {
        TDepartment GetByKey(int employeeClassificationKey);

        IList<TDepartment> GetAll();

        int Create(TDepartment classification);
        void Update(TDepartment classification);
        void Delete(TDepartment classification);
        void Delete(int employeeClassificationKey);

    }
}
