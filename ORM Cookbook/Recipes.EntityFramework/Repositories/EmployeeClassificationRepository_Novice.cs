using Recipes.EF.Models;
using Recipes.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Dapper.Repositories
{



    public class EmployeeClassificationRepository_Novice : IEmployeeClassificationRepository<EmployeeClassification>
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
                var temp = context.EmployeeClassifications.Where(ec => ec.EmployeeClassificationKey == employeeClassificationKey).SingleOrDefault();
                if (temp != null)
                {
                    context.EmployeeClassifications.Remove(temp);
                    context.SaveChanges();
                }
            }
        }

        public void Delete(EmployeeClassification classification)
        {
            using (var context = new OrmCookbook())
            {
                var temp = context.EmployeeClassifications.Where(ec => ec.EmployeeClassificationKey == classification.EmployeeClassificationKey).SingleOrDefault();
                if (temp != null)
                {
                    context.EmployeeClassifications.Remove(temp);
                    context.SaveChanges();
                }
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
                return context.EmployeeClassifications.Where(ec => ec.EmployeeClassificationKey == employeeClassificationKey).Single();
            }
        }

        public void Update(EmployeeClassification classification)
        {
            using (var context = new OrmCookbook())
            {
                var temp = context.EmployeeClassifications.Where(ec => ec.EmployeeClassificationKey == classification.EmployeeClassificationKey).SingleOrDefault();
                temp.EmployeeClassificationName = classification.EmployeeClassificationName;
                context.SaveChanges();
            }
        }
    }
}


