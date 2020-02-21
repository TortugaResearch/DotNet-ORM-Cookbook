using Microsoft.EntityFrameworkCore;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.MultipleDB;
using System;
using System.Collections.Generic;
using System.Linq;

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
                context.EmployeeClassification.Add(classification);
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