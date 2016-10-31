using Recipes.Models;
using System.Collections.Generic;

namespace Recipes.Repositories
{
    public interface IDepartmentWithChildRepository<TModel, TDivision>
            where TModel : IDepartment<TDivision>, new()
            where TDivision : IDivision
    {
        TModel GetByKey(int departmentKey);

        IList<TModel> GetAll();

        int Create(TModel department);
        void Update(TModel department);
        void Delete(TModel department);
        void Delete(int departmentKey);
        IList<TDivision> GetAllDivisions();
    }
}
