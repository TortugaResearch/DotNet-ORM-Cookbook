using Recipes.EF.Models;
using Recipes.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Recipes.Dapper.Repositories
{



    public class EmployeeClassificationRepository_Intermediate : IEmployeeClassificationRepository<EmployeeClassification>
    {
        public int Create(EmployeeClassification classification)
        {
            using (var context = new OrmCookbook())
            {
                context.EmployeeClassifications.Add(classification);
                context.SaveChanges();
                return classification.EmployeeClassificationKey;
            }
        }

        public void Delete(int employeeClassificationKey)
        {
            using (var context = new OrmCookbook())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM HR.EmployeeClassification WHERE EmployeeClassificationKey = @p0", employeeClassificationKey);
            }
        }

        public void Delete(EmployeeClassification classification)
        {
            using (var context = new OrmCookbook())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM HR.EmployeeClassification WHERE EmployeeClassificationKey = @p0", classification.EmployeeClassificationKey);
            }
        }

        public IList<EmployeeClassification> GetAll()
        {
            using (var context = new OrmCookbook())
            {
                return context.EmployeeClassifications.ToList();
            }
        }

        public EmployeeClassification GetByKey(int employeeClassificationKey)
        {
            using (var context = new OrmCookbook())
            {
                return context.EmployeeClassifications.Where(ec => ec.EmployeeClassificationKey == employeeClassificationKey).SingleOrDefault();
            }
        }

        public void Update(EmployeeClassification classification)
        {
            using (var context = new OrmCookbook())
            {
                context.Entry(classification).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}


