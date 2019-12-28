using Recipes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipes.Repositories
{
    public interface IEmployeeClassificationRepository<TEmployeeClassification>
        where TEmployeeClassification : IEmployeeClassification, new()
    {
        TEmployeeClassification GetByKey(int employeeClassificationKey);

        TEmployeeClassification FindByName(string employeeClassificationName);

        IList<TEmployeeClassification> GetAll();

        int Create(TEmployeeClassification classification);
        void Update(TEmployeeClassification classification);
        void Delete(TEmployeeClassification classification);
        void Delete(int employeeClassificationKey);

    }
}
