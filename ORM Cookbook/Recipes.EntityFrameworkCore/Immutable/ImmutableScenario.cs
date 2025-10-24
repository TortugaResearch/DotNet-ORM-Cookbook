using Recipes.EntityFrameworkCore.Entities;
using Recipes.EntityFrameworkCore.Models;
using Recipes.Immutable;
using System.Collections.Immutable;
using System.Data;

namespace Recipes.EntityFrameworkCore.Immutable;

public class ImmutableScenario : IImmutableScenario<ReadOnlyEmployeeClassification>
{
    private Func<OrmCookbookContext> CreateDbContext;

    public ImmutableScenario(Func<OrmCookbookContext> dBContextFactory)
    {
        CreateDbContext = dBContextFactory;
    }

    public int Create(ReadOnlyEmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var context = CreateDbContext())
        {
            var temp = classification.ToEntity();
            context.EmployeeClassifications.Add(temp);
            context.SaveChanges();
            return temp.EmployeeClassificationKey;
        }
    }

    public virtual void Delete(ReadOnlyEmployeeClassification classification)
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

    public ReadOnlyEmployeeClassification? FindByName(string employeeClassificationName)
    {
        using (var context = CreateDbContext())
        {
            return context.EmployeeClassifications
                .Where(ec => ec.EmployeeClassificationName == employeeClassificationName)
                .Select(x => new ReadOnlyEmployeeClassification(x)).SingleOrDefault();
        }
    }

    public IReadOnlyList<ReadOnlyEmployeeClassification> GetAll()
    {
        using (var context = CreateDbContext())
        {
            return context.EmployeeClassifications.Select(x => new ReadOnlyEmployeeClassification(x)).ToImmutableArray();
        }
    }

    public ReadOnlyEmployeeClassification GetByKey(int employeeClassificationKey)
    {
        using (var context = CreateDbContext())
        {
            var temp = context.EmployeeClassifications.Find(employeeClassificationKey);
            if (temp == null)
                throw new DataException($"No row was found for key {employeeClassificationKey}.");
            return new ReadOnlyEmployeeClassification(temp);
        }
    }

    public void Update(ReadOnlyEmployeeClassification classification)
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
                temp.IsEmployee = classification.IsEmployee;
                temp.IsExempt = classification.IsExempt;
                context.SaveChanges();
            }
        }
    }
}