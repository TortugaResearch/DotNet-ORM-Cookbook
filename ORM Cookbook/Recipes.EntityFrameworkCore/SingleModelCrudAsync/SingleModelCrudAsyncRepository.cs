using Microsoft.EntityFrameworkCore;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.SingleModelCrudAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.EntityFrameworkCore.SingleModelCrudAsync
{
    public class SingleModelCrudAsyncRepository : ISingleModelCrudAsyncRepository<EmployeeClassification>
    {
        private Func<OrmCookbookContext> CreateDbContext;

        public SingleModelCrudAsyncRepository(Func<OrmCookbookContext> dBContextFactory)
        {
            CreateDbContext = dBContextFactory;
        }

        public async Task<int> CreateAsync(EmployeeClassification classification)
        {
            using (var context = CreateDbContext())
            {
                context.EmployeeClassification.Add(classification);
                await context.SaveChangesAsync();
                return classification.EmployeeClassificationKey;
            }
        }

        public async Task DeleteAsync(EmployeeClassification classification)
        {
            using (var context = CreateDbContext())
            {
                var temp = await context.EmployeeClassification.FindAsync(classification.EmployeeClassificationKey);
                if (temp != null)
                {
                    context.EmployeeClassification.Remove(temp);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteByKeyAsync(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
            {
                var temp = await context.EmployeeClassification.FindAsync(employeeClassificationKey);
                if (temp != null)
                {
                    context.EmployeeClassification.Remove(temp);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<EmployeeClassification> FindByNameAsync(string employeeClassificationName)
        {
            using (var context = CreateDbContext())
            {
                return await context.EmployeeClassification.Where(ec => ec.EmployeeClassificationName == employeeClassificationName).SingleOrDefaultAsync();
            }
        }

        public async Task<IList<EmployeeClassification>> GetAllAsync()
        {
            using (var context = CreateDbContext())
            {
                return await context.EmployeeClassification.ToListAsync();
            }
        }

        public async Task<EmployeeClassification> GetByKeyAsync(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
            {
                return await context.EmployeeClassification.FindAsync(employeeClassificationKey);
            }
        }

        public async Task UpdateAsync(EmployeeClassification classification)
        {
            using (var context = CreateDbContext())
            {
                var temp = await context.EmployeeClassification.FindAsync(classification.EmployeeClassificationKey);
                temp.EmployeeClassificationName = classification.EmployeeClassificationName;
                await context.SaveChangesAsync();
            }
        }
    }
}
