using Recipes.EntityFrameworkCore.Entities;
using Recipes.SingleModelCrud;

namespace Recipes.EntityFrameworkCore.SingleModelCrud
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
                context.EmployeeClassifications.Add(classification);
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
                var temp = context.EmployeeClassifications.Find(classification.EmployeeClassificationKey);
                if (temp != null)
                {
                    context.EmployeeClassifications.Remove(temp);
                    context.SaveChanges();
                }
            }
        }

        public virtual void DeleteByKey(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
            {
                //Find the row you wish to delete
                var temp = context.EmployeeClassifications.Find(employeeClassificationKey);
                if (temp != null)
                {
                    context.EmployeeClassifications.Remove(temp);
                    context.SaveChanges();
                }
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

        public EmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
            {
                return context.EmployeeClassifications.Find(employeeClassificationKey);
            }
        }

        public virtual void Update(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var context = CreateDbContext())
            {
                //Get a fresh copy of the row from the database
                var temp = context.EmployeeClassifications.Find(classification.EmployeeClassificationKey);
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