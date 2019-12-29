using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.SingleModelCrudAsync
{
    public interface ISingleModelCrudAsyncRepository<TEmployeeClassification>
       where TEmployeeClassification : class, IEmployeeClassification, new()
    {
        Task<TEmployeeClassification?> GetByKeyAsync(int employeeClassificationKey, CancellationToken cancellationToken = default);

        Task<TEmployeeClassification?> FindByNameAsync(string employeeClassificationName, CancellationToken cancellationToken = default);

        Task<IList<TEmployeeClassification>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<int> CreateAsync(TEmployeeClassification classification);

        Task UpdateAsync(TEmployeeClassification classification);

        Task DeleteAsync(TEmployeeClassification classification);

        Task DeleteByKeyAsync(int employeeClassificationKey);
    }
}
