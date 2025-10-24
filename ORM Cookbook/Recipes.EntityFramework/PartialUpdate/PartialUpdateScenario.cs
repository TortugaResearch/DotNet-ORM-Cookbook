using Recipes.EntityFramework.Entities;
using Recipes.PartialUpdate;

namespace Recipes.EntityFramework.PartialUpdate;

public class PartialUpdateScenario : IPartialUpdateScenario<EmployeeClassification>
{
    private Func<OrmCookbookContext> CreateDbContext;

    public PartialUpdateScenario(Func<OrmCookbookContext> dBContextFactory)
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

    public EmployeeClassification GetByKey(int employeeClassificationKey)
    {
        using (var context = CreateDbContext())
        {
            return context.EmployeeClassification.Find(employeeClassificationKey);
        }
    }

    public void UpdateWithObject(EmployeeClassificationNameUpdater updateMessage)
    {
        if (updateMessage == null)
            throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

        using (var context = CreateDbContext())
        {
            //Get a fresh copy of the row from the database
            var temp = context.EmployeeClassification.Find(updateMessage.EmployeeClassificationKey);
            if (temp != null)
            {
                //Copy the changed fields
                temp.EmployeeClassificationName = updateMessage.EmployeeClassificationName;
                context.SaveChanges();
            }
        }
    }

    public void UpdateWithObject(EmployeeClassificationFlagsUpdater updateMessage)
    {
        if (updateMessage == null)
            throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

        using (var context = CreateDbContext())
        {
            //Get a fresh copy of the row from the database
            var temp = context.EmployeeClassification.Find(updateMessage.EmployeeClassificationKey);
            if (temp != null)
            {
                //Copy the changed fields
                temp.IsExempt = updateMessage.IsExempt;
                temp.IsEmployee = updateMessage.IsEmployee;
                context.SaveChanges();
            }
        }
    }

    public void UpdateWithSeparateParameters(int employeeClassificationKey, bool isExempt, bool isEmployee)
    {
        using (var context = CreateDbContext())
        {
            //Get a fresh copy of the row from the database
            var temp = context.EmployeeClassification.Find(employeeClassificationKey);
            if (temp != null)
            {
                //Copy the changed fields
                temp.IsExempt = isExempt;
                temp.IsEmployee = isEmployee;
                context.SaveChanges();
            }
        }
    }
}