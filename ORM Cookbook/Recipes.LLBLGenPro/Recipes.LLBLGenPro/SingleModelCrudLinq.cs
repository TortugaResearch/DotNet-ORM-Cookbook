using LLBLGenPro.OrmCookbook.EntityClasses;
using Recipes.LLBLGenPro.Repositories;
using Recipes.UseCases;

namespace Recipes.LLBLGenPro
{
    public class SingleModelCrudLinq : SingleModelCrud<EmployeeClassificationEntity>
    {
        public override void CreateAndReadBack()
        {
            CreateAndReadBack(new EmployeeClassificationRepositoryLinq());
        }

        public override void CreateAndDelete()
        {
            CreateAndDelete(new EmployeeClassificationRepositoryLinq());
        }

        public override void GetAll()
        {
            GetAll(new EmployeeClassificationRepositoryLinq());
        }

        public override void GetByKey()
        {
            GetByKey(new EmployeeClassificationRepositoryLinq());
        }

        public override void CreateAndUpdate()
        {
            CreateAndUpdate(new EmployeeClassificationRepositoryLinq());
        }
    }
}
