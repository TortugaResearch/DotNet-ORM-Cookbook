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
                context.Database.ExecuteSqlInterpolated($"DELETE FROM HR.EmployeeClassification WHERE EmployeeClassificationKey = {employeeClassificationKey}");
            }
        }

        public override void Delete(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var context = CreateDbContext())
            {
                context.Database.ExecuteSqlInterpolated($"DELETE FROM HR.EmployeeClassification WHERE EmployeeClassificationKey = {classification.EmployeeClassificationKey}");
            }
        }

        public override void Update(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var context = CreateDbContext())
            {
                //Get a fresh copy of the row from the database
                var temp = context.EmployeeClassification.Find(classification.EmployeeClassificationKey);
                //Copy the changed fields
                temp.EmployeeClassificationName = classification.EmployeeClassificationName;
                context.SaveChanges();
            }
        }
    }
}
