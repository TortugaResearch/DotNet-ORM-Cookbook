using System.Collections.Generic;

namespace Recipes.Repositories
{
    public interface IEmployeeClassificationRepository<TModel>
        where TModel : IEmployeeClassification, new()
    {
        TModel GetByKey(int employeeClassificationKey);

        IList<TModel> GetAll();

        int Create(TModel classification);
        void Update(TModel classification);
        void Delete(TModel classification);
        void Delete(int employeeClassificationKey);

    }
}
