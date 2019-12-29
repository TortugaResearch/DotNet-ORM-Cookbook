using Recipes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipes.Repositories
{
    public interface IEmployeeClassificationAsynchronousRepository<TEmployeeClassification>
        where TEmployeeClassification : IEmployeeClassification, new()
    {
        Task<TEmployeeClassification> GetByKeyAsync(int employeeClassificationKey);

        Task<TEmployeeClassification> FindByNameAsync(string employeeClassificationName);

        Task<IList<TEmployeeClassification>> GetAllAsync();

        Task<int> CreateAsync(TEmployeeClassification classification);
        Task UpdateAsync(TEmployeeClassification classification);
        Task DeleteAsync(TEmployeeClassification classification);
        Task DeleteAsync(int employeeClassificationKey);

    }
}
