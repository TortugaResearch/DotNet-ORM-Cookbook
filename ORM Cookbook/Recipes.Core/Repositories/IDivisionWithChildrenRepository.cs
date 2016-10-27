using Recipes.Models;
using System.Collections.Generic;

namespace Recipes.Repositories
{
    public interface IDivisionWithChildrenRepository<TModel, TDepartment>
            where TModel : IDivision<IDepartment>, new()
            where TDepartment : IDepartment, new()
    {
        TModel GetByKey(int employeeClassificationKey);

        IList<TModel> GetAll();

        int Create(TModel classification);
        void Update(TModel classification);
        void Delete(TModel classification);
        void Delete(int employeeClassificationKey);

    }
}
