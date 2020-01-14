using Microsoft.EntityFrameworkCore;
using Recipes.EntityFrameworkCore.Entities;
using System;

namespace Recipes.EntityFrameworkCore.SingleModelCrud
{
    public class SingleModelCrudRepository2 : SingleModelCrudRepository
    {
        private Func<OrmCookbookContext> CreateDbContext;

        public SingleModelCrudRepository2(Func<OrmCookbookContext> dBContextFactory) : base(dBContextFactory)
        {
            CreateDbContext = dBContextFactory;
        }

        public override void DeleteByKey(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
            {
                var temp = new EmployeeClassification() { EmployeeClassificationKey = employeeClassificationKey };
                context.Entry(temp).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public override void Delete(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var context = CreateDbContext())
            {
                context.Entry(classification).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public override void Update(EmployeeClassification classification)
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
