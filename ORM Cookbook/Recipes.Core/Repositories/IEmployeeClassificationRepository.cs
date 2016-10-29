using Recipes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipes.Repositories
{
    public interface IEmployeeClassificationRepository<TModel>
        where TModel : IEmployeeClassification, new()
    {
        TModel GetByKey(int employeeClassificationKey);

        TModel FindByName(string employeeClassificationName);

        IList<TModel> GetAll();

        int Create(TModel classification);
        void Update(TModel classification);
        void Delete(TModel classification);
        void Delete(int employeeClassificationKey);

    }
}
