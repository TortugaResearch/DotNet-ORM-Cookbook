using Recipes.DbConnector.Models;
using Recipes.TryCrud;
using System.Data;

namespace Recipes.DbConnector.TryCrud;

public class TryCrudScenario : ScenarioBase, ITryCrudScenario<EmployeeClassification>
{
    public TryCrudScenario(string connectionString) : base(connectionString)
    {
    }

    public int Create(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        return DbConnector.Scalar<int>(
        @"INSERT INTO " + EmployeeClassification.TableName
        + @"(
                    EmployeeClassificationName,
                    IsEmployee,
                    IsExempt
                )
                OUTPUT Inserted.EmployeeClassificationKey
                VALUES (
                    @EmployeeClassificationName,
                    @IsEmployee,
                    @IsExempt
                )"
        , classification)
        .Execute();
    }

    public void DeleteByKeyOrException(int employeeClassificationKey)
    {
        var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @employeeClassificationKey;";

        var rowCount = DbConnector.NonQuery(sql, new { employeeClassificationKey }).Execute();
        if (rowCount != 1)
            throw new DataException($"No row was found for key {employeeClassificationKey}.");
    }

    public bool DeleteByKeyWithStatus(int employeeClassificationKey)
    {
        var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @employeeClassificationKey;";

        return 1 == DbConnector.NonQuery(sql, new { employeeClassificationKey }).Execute();
    }

    public void DeleteOrException(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        var rowCount = DbConnector.NonQuery(sql, classification).Execute();
        if (rowCount != 1)
            throw new DataException($"No row was found for key {classification.EmployeeClassificationKey}.");
    }

    public bool DeleteWithStatus(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        return 1 == DbConnector.NonQuery(sql, classification).Execute();
    }

    public EmployeeClassification FindByNameOrException(string employeeClassificationName)
    {
        var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @employeeClassificationName;";

        return DbConnector.ReadSingle<EmployeeClassification>(sql, new { employeeClassificationName }).Execute();
    }

    public EmployeeClassification? FindByNameOrNull(string employeeClassificationName)
    {
        var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @employeeClassificationName;";

        return DbConnector.ReadSingleOrDefault<EmployeeClassification>(sql, new { employeeClassificationName }).Execute();
    }

    public EmployeeClassification GetByKeyOrException(int employeeClassificationKey)
    {
        var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @employeeClassificationKey;";

        return DbConnector.ReadSingle<EmployeeClassification>(sql, new { employeeClassificationKey }).Execute();
    }

    public EmployeeClassification? GetByKeyOrNull(int employeeClassificationKey)
    {
        var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @employeeClassificationKey;";

        return DbConnector.ReadSingleOrDefault<EmployeeClassification>(sql, new { employeeClassificationKey }).Execute();
    }

    public void UpdateOrException(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        var sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        var rowCount = DbConnector.NonQuery(sql, classification).Execute();
        if (rowCount != 1)
            throw new DataException($"No row was found for key {classification.EmployeeClassificationKey}.");
    }

    public bool UpdateWithStatus(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        var sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        return 1 == DbConnector.NonQuery(sql, classification).Execute();
    }
}