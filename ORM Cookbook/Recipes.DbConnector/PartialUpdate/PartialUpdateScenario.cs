using Recipes.DbConnector.Models;
using Recipes.PartialUpdate;

namespace Recipes.DbConnector.PartialUpdate;

public class PartialUpdateScenario : ScenarioBase, IPartialUpdateScenario<EmployeeClassification>
{
    public PartialUpdateScenario(string connectionString) : base(connectionString)
    {
    }

    public int Create(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        const string sql = @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName, IsExempt, IsEmployee)
                        OUTPUT Inserted.EmployeeClassificationKey
                        VALUES(@EmployeeClassificationName, @IsExempt, @IsEmployee)";

        return DbConnector.Scalar<int>(sql, classification).Execute();
    }

    public EmployeeClassification? GetByKey(int employeeClassificationKey)
    {
        const string sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @employeeClassificationKey;";

        return DbConnector.ReadSingle<EmployeeClassification>(sql, new { employeeClassificationKey }).Execute();
    }

    public void UpdateWithObject(EmployeeClassificationNameUpdater updateMessage)
    {
        if (updateMessage == null)
            throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

        const string sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        DbConnector.NonQuery(sql, updateMessage).Execute();
    }

    public void UpdateWithObject(EmployeeClassificationFlagsUpdater updateMessage)
    {
        if (updateMessage == null)
            throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

        const string sql = @"UPDATE HR.EmployeeClassification
                        SET IsExempt = @IsExempt, IsEmployee = @IsEmployee
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        DbConnector.NonQuery(sql, updateMessage).Execute();
    }

    public void UpdateWithSeparateParameters(int employeeClassificationKey, bool isExempt, bool isEmployee)
    {
        const string sql = @"UPDATE HR.EmployeeClassification
                        SET IsExempt = @isExempt, IsEmployee = @isEmployee
                        WHERE EmployeeClassificationKey = @employeeClassificationKey;";

        DbConnector.NonQuery(sql, new { employeeClassificationKey, isExempt, isEmployee }).Execute();
    }
}