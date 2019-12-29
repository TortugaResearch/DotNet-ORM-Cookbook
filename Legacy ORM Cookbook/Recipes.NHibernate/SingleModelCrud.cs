using Recipes.NHibernate.Models;
using Recipes.NHibernate.Repositories;
using Recipes.UseCases;

namespace Recipes.NHibernate
{
    public class SingleModelCrud : SingleModelCrud<EmployeeClassification>
    {
        public override void CreateAndReadBack()
        {
            CreateAndReadBack(new EmployeeClassificationRepository());
        }

        public override void CreateAndDelete()
        {
            CreateAndDelete(new EmployeeClassificationRepository());
        }

        public override void GetAll()
        {
            GetAll(new EmployeeClassificationRepository());
        }

        public override void GetByKey()
        {
            GetByKey(new EmployeeClassificationRepository());
        }
        public override void CreateAndUpdate()
        {
            CreateAndUpdate(new EmployeeClassificationRepository());

        }
    }


}
