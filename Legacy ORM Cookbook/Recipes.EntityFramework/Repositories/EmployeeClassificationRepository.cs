using Recipes.EF.Models;
using Recipes.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.EF.Repositories
{



    public class EmployeeClassificationRepository : IEmployeeClassificationRepository<EmployeeClassification>
    {
        public virtual int Create(EmployeeClassification classification)
        {
            using (var context = new OrmCookbook())
            {
                context.EmployeeClassifications.Add(classification);
                context.SaveChanges();
                return classification.EmployeeClassificationKey;
            }
        }

        public virtual void Delete(int employeeClassificationKey)
        {
            using (var context = new OrmCookbook())
            {
                var temp = context.EmployeeClassifications.Find(employeeClassificationKey);
                if (temp != null)
                {
                    context.EmployeeClassifications.Remove(temp);
                    context.SaveChanges();
                }
            }
        }

        public virtual void Delete(EmployeeClassification classification)
        {
            using (var context = new OrmCookbook())
            {
                var temp = context.EmployeeClassifications.Find(classification.EmployeeClassificationKey);
                if (temp != null)
                {
                    context.EmployeeClassifications.Remove(temp);
                    context.SaveChanges();
                }
            }
        }

        public virtual EmployeeClassification FindByName(string employeeClassificationName)
        {
            using (var context = new OrmCookbook())
            {
                return context.EmployeeClassifications.Where(ec => ec.EmployeeClassificationName == employeeClassificationName).SingleOrDefault();
            }
        }

        public virtual IList<EmployeeClassification> GetAll()
        {
            using (var context = new OrmCookbook())
            {
                return context.EmployeeClassifications.ToList();
            }
        }

        public virtual EmployeeClassification GetByKey(int employeeClassificationKey)
        {
            using (var context = new OrmCookbook())
            {
                return context.EmployeeClassifications.Find(employeeClassificationKey);
            }
        }

        public virtual void Update(EmployeeClassification classification)
        {
            using (var context = new OrmCookbook())
            {
                var temp = context.EmployeeClassifications.Find(classification.EmployeeClassificationKey);
                temp.EmployeeClassificationName = classification.EmployeeClassificationName;
                context.SaveChanges();
            }
        }
    }
}


