
using Recipes.EF.Models;
using Recipes.EF.Repositories;
using Recipes.UseCases;

namespace Recipes.EF
{
    public class SingleModelCrud_Intermediate : SingleModelCrud<EmployeeClassification>
    {

        public override void CreateAndReadBack()
        {
            CreateAndReadBack(new EmployeeClassificationRepository_Intermediate());
        }

        public override void CreateAndDelete()
        {
            CreateAndDelete(new EmployeeClassificationRepository_Intermediate());
        }

        public override void GetAll()
        {
            GetAll(new EmployeeClassificationRepository_Intermediate());
        }

        public override void GetByKey()
        {
            GetByKey(new EmployeeClassificationRepository_Intermediate());
        }

        public override void CreateAndUpdate()
        {
            CreateAndUpdate(new EmployeeClassificationRepository());
        }
    }
}
