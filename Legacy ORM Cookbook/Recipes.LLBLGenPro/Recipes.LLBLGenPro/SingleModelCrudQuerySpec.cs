using LLBLGenPro.OrmCookbook.EntityClasses;
using Recipes.LLBLGenPro.Repositories;
using Recipes.UseCases;

namespace Recipes.LLBLGenPro
{
    public class SingleModelCrudQuerySpec : SingleModelCrud<EmployeeClassificationEntity>
    {
        public override void CreateAndReadBack()
        {
            CreateAndReadBack(new EmployeeClassificationRepositoryQuerySpec());
        }

        public override void CreateAndDelete()
        {
            CreateAndDelete(new EmployeeClassificationRepositoryQuerySpec());
        }

        public override void GetAll()
        {
            GetAll(new EmployeeClassificationRepositoryQuerySpec());
        }

        public override void GetByKey()
        {
            GetByKey(new EmployeeClassificationRepositoryQuerySpec());
        }

        public override void CreateAndUpdate()
        {
            CreateAndUpdate(new EmployeeClassificationRepositoryQuerySpec());
        }
    }
}
