using Recipes.EF.Models;
using System.Data.Entity;

namespace Recipes.Dapper.Repositories
{

    public class EmployeeClassificationRepository_Intermediate : EmployeeClassificationRepository
    {
        public override void Delete(int employeeClassificationKey)
        {
            using (var context = new OrmCookbook())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM HR.EmployeeClassification WHERE EmployeeClassificationKey = @p0", employeeClassificationKey);
            }
        }

        public override void Delete(EmployeeClassification classification)
        {
            using (var context = new OrmCookbook())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM HR.EmployeeClassification WHERE EmployeeClassificationKey = @p0", classification.EmployeeClassificationKey);
            }
        }

        public override void Update(EmployeeClassification classification)
        {
            using (var context = new OrmCookbook())
            {
                context.Entry(classification).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}


