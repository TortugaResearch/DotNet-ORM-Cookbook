using Recipes.EntityFramework.Entities;
using Recipes.SingleModelCrud;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.EntityFramework.SingleModelCrud
{
    public class SingleModelCrudScenario : ISingleModelCrudScenario<EmployeeClassification>
    {
        private Func<OrmCookbookContext> CreateDbContext;

        public SingleModelCrudScenario(Func<OrmCookbookContext> dBContextFactory)
        {
            CreateDbContext = dBContextFactory;
        }

        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var context = CreateDbContext())
            {
                context.EmployeeClassification.Add(classification);
                context.SaveChanges();
                return classification.EmployeeClassificationKey;
            }
        }

        public virtual void Delete(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var context = CreateDbContext())
            {
                //Find the row you wish to delete
                var temp = context.EmployeeClassification.Find(classification.EmployeeClassificationKey);
                if (temp != null)
                {
                    context.EmployeeClassification.Remove(temp);
                    context.SaveChanges();
                }
            }
        }

        public virtual void DeleteByKey(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
            {
                //Find the row you wish to delete
                var temp = context.EmployeeClassification.Find(employeeClassificationKey);
                if (temp != null)
                {
                    context.EmployeeClassification.Remove(temp);
                    context.SaveChanges();
                }
            }
        }

        public EmployeeClassification FindByName(string employeeClassificationName)
        {
            using (var context = CreateDbContext())
            {
                return context.EmployeeClassification.Where(ec => ec.EmployeeClassificationName == employeeClassificationName).SingleOrDefault();
            }
        }

        public IList<EmployeeClassification> GetAll()
        {
            using (var context = CreateDbContext())
            {
                return context.EmployeeClassification.ToList();
            }
        }

        public EmployeeClassification GetByKey(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
            {
                return context.EmployeeClassification.Find(employeeClassificationKey);
            }
        }

        public virtual void Update(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var context = CreateDbContext())
            {
                //Get a fresh copy of the row from the database
                var temp = context.EmployeeClassification.Find(classification.EmployeeClassificationKey);
                if (temp != null)
                {
                    //Copy the changed fields
                    temp.EmployeeClassificationName = classification.EmployeeClassificationName;
                    context.SaveChanges();
                }
            }
        }
    }
}
