#if !EFCore5
using Microsoft.EntityFrameworkCore;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.MultipleDB;
using System;
using System.Collections.Generic;
using System.Linq;

//This relies on SetColumnName, which was broken in EF Core 5.

namespace Recipes.EntityFrameworkCore.MultipleDB
{
    public class MultipleDBScenario : IMultipleDBScenario<EmployeeClassification>
    {
        private Func<OrmCookbookContext> CreateDbContext;

        public MultipleDBScenario(Func<OrmCookbookContext> dBContextFactory)
        {
            CreateDbContext = dBContextFactory;
        }

        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var context = CreateDbContext())
            {
                context.EmployeeClassifications.Add(classification);
                context.SaveChanges();
                return classification.EmployeeClassificationKey;
            }
        }

        public void Delete(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var context = CreateDbContext())
            {
                context.Entry(classification).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
            {
                var temp = new EmployeeClassification() { EmployeeClassificationKey = employeeClassificationKey };
                context.Entry(temp).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public EmployeeClassification? FindByName(string employeeClassificationName)
        {
            using (var context = CreateDbContext())
            {
                return context.EmployeeClassifications.Where(ec => ec.EmployeeClassificationName == employeeClassificationName).SingleOrDefault();
            }
        }

        public IList<EmployeeClassification> GetAll()
        {
            using (var context = CreateDbContext())
            {
                return context.EmployeeClassifications.ToList();
            }
        }

        public EmployeeClassification GetByKey(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
            {
                return context.EmployeeClassifications.Find(employeeClassificationKey);
            }
        }

        public void Update(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var context = CreateDbContext())
            {
                context.Entry(classification).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
#endif