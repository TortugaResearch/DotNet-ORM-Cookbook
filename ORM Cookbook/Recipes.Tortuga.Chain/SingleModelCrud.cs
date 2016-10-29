

using Recipes.UseCases;
using Tortuga.Chain;

namespace Recipes.Chain
{
    public class SingleModelCrud : SingleModelCrud<EmployeeClassification>
    {

        static SqlServerDataSource s_DataSource = SqlServerDataSource.CreateFromConfig("OrmCookbook");

        public override void CreateAndReadBack()
        {
            CreateAndReadBack(new EmployeeClassificationRepository(s_DataSource));
        }

        public override void CreateAndDelete()
        {
            CreateAndDelete(new EmployeeClassificationRepository(s_DataSource));
        }

        public override void GetAll()
        {
            GetAll(new EmployeeClassificationRepository(s_DataSource));
        }

        public override void GetByKey()
        {
            GetByKey(new EmployeeClassificationRepository(s_DataSource));
        }
        public override void CreateAndUpdate()
        {
            CreateAndUpdate(new EmployeeClassificationRepository(s_DataSource));

        }
    }
}
