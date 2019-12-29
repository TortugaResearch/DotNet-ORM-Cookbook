using Recipes.Models;
using System.Collections.Generic;

namespace Recipes.Repositories
{
    public interface IDivisionWithChildrenRepository<TDivision, TDepartment>
            where TDivision : IDivision<IDepartment>, new()
            where TDepartment : IDepartment, new()
    {
        TDivision GetByKey(int employeeClassificationKey);

        IList<TDivision> GetAll();

        int Create(TDivision classification);
        void Update(TDivision classification);
        void Delete(TDivision classification);
        void Delete(int employeeClassificationKey);

    }
}
