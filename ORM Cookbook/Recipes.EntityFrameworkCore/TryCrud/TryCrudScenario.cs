using Recipes.EntityFrameworkCore.Entities;
using Recipes.TryCrud;
using System.Data;

namespace Recipes.EntityFrameworkCore.TryCrud
{
    public class TryCrudScenario : ITryCrudScenario<EmployeeClassification>
    {
        private Func<OrmCookbookContext> CreateDbContext;

        public TryCrudScenario(Func<OrmCookbookContext> dBContextFactory)
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

        public void DeleteByKeyOrException(int employeeClassificationKey)
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
                else
                    throw new DataException($"No row was found for key {employeeClassificationKey}.");
            }
        }

        public bool DeleteByKeyWithStatus(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
            {
                //Find the row you wish to delete
                var temp = context.EmployeeClassifications.Find(employeeClassificationKey);
                if (temp != null)
                {
                    context.EmployeeClassifications.Remove(temp);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }

        public void DeleteOrException(EmployeeClassification classification)
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
                else
                    throw new DataException($"No row was found for key {classification.EmployeeClassificationKey}.");
            }
        }

        public bool DeleteWithStatus(EmployeeClassification classification)
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
                    return true;
                }
                else
                    return false;
            }
        }

        public EmployeeClassification FindByNameOrException(string employeeClassificationName)
        {
            using (var context = CreateDbContext())
            {
                return context.EmployeeClassifications.Where(ec => ec.EmployeeClassificationName == employeeClassificationName).Single();
            }
        }

        public EmployeeClassification? FindByNameOrNull(string employeeClassificationName)
        {
            using (var context = CreateDbContext())
            {
                return context.EmployeeClassifications.Where(ec => ec.EmployeeClassificationName == employeeClassificationName).SingleOrDefault();
            }
        }

        public EmployeeClassification GetByKeyOrException(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
            {
                return context.EmployeeClassifications.Find(employeeClassificationKey) ?? throw new DataException($"No row was found for key {employeeClassificationKey}.");
            }
        }

        public EmployeeClassification? GetByKeyOrNull(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
            {
                return context.EmployeeClassifications.Find(employeeClassificationKey);
            }
        }

        public void UpdateOrException(EmployeeClassification classification)
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
                else
                    throw new DataException($"No row was found for key {classification.EmployeeClassificationKey}.");
            }
        }

        public bool UpdateWithStatus(EmployeeClassification classification)
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
                    return true;
                }
                else
                    return false;
            }
        }
    }
}