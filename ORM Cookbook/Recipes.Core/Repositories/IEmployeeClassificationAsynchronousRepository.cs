using Recipes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipes.Repositories
{
    public interface IEmployeeClassificationAsynchronousRepository<TModel>
        where TModel : IEmployeeClassification, new()
    {
        Task<TModel> GetByKeyAsync(int employeeClassificationKey);

        Task<TModel> FindByNameAsync(string employeeClassificationName);

        Task<IList<TModel>> GetAllAsync();

        Task<int> CreateAsync(TModel classification);
        Task UpdateAsync(TModel classification);
        Task DeleteAsync(TModel classification);
        Task DeleteAsync(int employeeClassificationKey);

    }
}
