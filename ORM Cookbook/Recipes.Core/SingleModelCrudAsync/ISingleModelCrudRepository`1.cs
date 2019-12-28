using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipes.SingleModelCrudAsync
{
    public interface ISingleModelCrudAsyncRepository<TEmployeeClassification>
       where TEmployeeClassification : IEmployeeClassification, new()
    {
        Task<TEmployeeClassification> GetByKeyAsync(int employeeClassificationKey);

        Task<TEmployeeClassification> FindByNameAsync(string employeeClassificationName);

        Task<IList<TEmployeeClassification>> GetAllAsync();

        Task<int> CreateAsync(TEmployeeClassification classification);

        Task UpdateAsync(TEmployeeClassification classification);

        Task DeleteAsync(TEmployeeClassification classification);

        Task DeleteByKeyAsync(int employeeClassificationKey);
    }
}
