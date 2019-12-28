using System.Collections.Generic;

namespace Recipes.SingleModelCrud
{
    public interface ISingleModelCrudRepository<TEmployeeClassification>
       where TEmployeeClassification : IEmployeeClassification, new()
    {
        TEmployeeClassification GetByKey(int employeeClassificationKey);

        TEmployeeClassification FindByName(string employeeClassificationName);

        IList<TEmployeeClassification> GetAll();

        int Create(TEmployeeClassification classification);

        void Update(TEmployeeClassification classification);

        void Delete(TEmployeeClassification classification);

        void DeleteByKey(int employeeClassificationKey);
    }
}
