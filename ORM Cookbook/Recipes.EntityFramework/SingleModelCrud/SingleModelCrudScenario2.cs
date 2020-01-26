using System.Data.Entity;
using Recipes.EntityFramework.Entities;
using System;

namespace Recipes.EntityFramework.SingleModelCrud
{
    public class SingleModelCrudScenario2 : SingleModelCrudScenario
    {
        private Func<OrmCookbookContext> CreateDbContext;

        public SingleModelCrudScenario2(Func<OrmCookbookContext> dBContextFactory) : base(dBContextFactory)
        {
            CreateDbContext = dBContextFactory;
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

        public override void DeleteByKey(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
            {
                var temp = new EmployeeClassification() { EmployeeClassificationKey = employeeClassificationKey };
                context.Entry(temp).State = EntityState.Deleted;
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
