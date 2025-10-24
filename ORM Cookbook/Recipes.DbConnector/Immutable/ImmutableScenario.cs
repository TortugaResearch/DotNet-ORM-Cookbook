using DbConnector.Core;
using DbConnector.Core.Extensions;
using Recipes.DbConnector.Models;
using Recipes.Immutable;
using System.Collections.Immutable;
using System.Data;
using System.Data.Common;

namespace Recipes.DbConnector.Immutable;

public class ImmutableScenario : ScenarioBase, IImmutableScenario<ReadOnlyEmployeeClassification>
{
    public ImmutableScenario(string connectionString) : base(connectionString)
    {
    }

    public int Create(ReadOnlyEmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        const string sql = @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName, IsExempt, IsEmployee)
                        OUTPUT Inserted.EmployeeClassificationKey
                        VALUES(@EmployeeClassificationName, @IsExempt, @IsEmployee);";

        return DbConnector.Scalar<int>(sql, classification).Execute();
    }

    public void Delete(ReadOnlyEmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        DbConnector.NonQuery(sql, classification).Execute();
    }

    public void DeleteByKey(int employeeClassificationKey)
    {
        var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @employeeClassificationKey;";

        DbConnector.NonQuery(sql, new { employeeClassificationKey }).Execute();
    }

    public ReadOnlyEmployeeClassification? FindByName(string employeeClassificationName)
    {
        var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @employeeClassificationName;";

        //DbConnector currently does not support direct constructor mapping (v1.2.1)
        return DbConnector.ReadTo<ReadOnlyEmployeeClassification>(
            sql: sql,
            param: new { employeeClassificationName },
            onLoad: (ReadOnlyEmployeeClassification result, IDbExecutionModel em, DbDataReader odr) =>
            {
                //Leverage extension from "DbConnector.Core.Extensions"
                dynamic row = odr.SingleOrDefault(em.Token, em.JobCommand);

                if (row != null)
                    result = new ReadOnlyEmployeeClassification(row.EmployeeClassificationKey, row.EmployeeClassificationName, row.IsExempt, row.IsEmployee);

                //Alternative: Extract values from the DbDataReader manually
                //if (odr.HasRows && odr.Read())
                //{
                //    int employeeClassificationKey = odr.GetValue(nameof(ReadOnlyEmployeeClassification.EmployeeClassificationKey)) as int? ?? 0;
                //    string employeeClassificationName = odr.GetValue(nameof(ReadOnlyEmployeeClassification.EmployeeClassificationName)) as string;
                //    bool isExempt = odr.GetValue(nameof(ReadOnlyEmployeeClassification.IsExempt)) as bool? ?? false;
                //    bool isEmployee = odr.GetValue(nameof(ReadOnlyEmployeeClassification.IsEmployee)) as bool? ?? false;

                //    result = new ReadOnlyEmployeeClassification(employeeClassificationKey, employeeClassificationName, isExempt, isEmployee);

                //    if (odr.Read())//SingleOrDefault behavior
                //    {
                //        throw new InvalidOperationException("The query result has more than one result.");
                //    }
                //}

                return result;
            })
            .Execute();
    }

    public IReadOnlyList<ReadOnlyEmployeeClassification> GetAll()
    {
        var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.EmployeeClassification ec;";

        //DbConnector currently does not support direct constructor mapping (v1.2.1)
        return DbConnector.ReadTo<List<ReadOnlyEmployeeClassification>>(
            sql: sql,
            param: null,
            onLoad: (List<ReadOnlyEmployeeClassification> result, IDbExecutionModel em, DbDataReader odr) =>
            {
                result = new List<ReadOnlyEmployeeClassification>();

                //Extract values from the DbDataReader manually
                if (odr.HasRows)
                {
                    while (odr.Read())
                    {
                        if (em.Token.IsCancellationRequested)
                            return result;

                        int employeeClassificationKey = odr.GetValue(nameof(ReadOnlyEmployeeClassification.EmployeeClassificationKey)) as int? ?? 0;
                        string employeeClassificationName = odr.GetValue(nameof(ReadOnlyEmployeeClassification.EmployeeClassificationName)) as string;
                        bool isExempt = odr.GetValue(nameof(ReadOnlyEmployeeClassification.IsExempt)) as bool? ?? false;
                        bool isEmployee = odr.GetValue(nameof(ReadOnlyEmployeeClassification.IsEmployee)) as bool? ?? false;

                        result.Add(new ReadOnlyEmployeeClassification(employeeClassificationKey, employeeClassificationName, isExempt, isEmployee));
                    }
                }

                return result;
            })
            .Execute()
            .ToImmutableList();
    }

    public ReadOnlyEmployeeClassification? GetByKey(int employeeClassificationKey)
    {
        var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @employeeClassificationKey;";

        //DbConnector currently does not support direct constructor mapping (v1.2.1)
        return DbConnector.ReadTo<ReadOnlyEmployeeClassification>(
            sql: sql,
            param: new { employeeClassificationKey },
            onLoad: (ReadOnlyEmployeeClassification result, IDbExecutionModel em, DbDataReader odr) =>
            {
                //Leverage extension from "DbConnector.Core.Extensions"
                dynamic row = odr.Single(em.Token, em.JobCommand);

                if (row != null)
                    result = new ReadOnlyEmployeeClassification(row.EmployeeClassificationKey, row.EmployeeClassificationName, row.IsExempt, row.IsEmployee);

                //Alternative: Extract values from the DbDataReader manually
                //if (odr.HasRows && odr.Read())
                //{
                //    int employeeClassificationKey = odr.GetValue(nameof(ReadOnlyEmployeeClassification.EmployeeClassificationKey)) as int? ?? 0;
                //    string employeeClassificationName = odr.GetValue(nameof(ReadOnlyEmployeeClassification.EmployeeClassificationName)) as string;
                //    bool isExempt = odr.GetValue(nameof(ReadOnlyEmployeeClassification.IsExempt)) as bool? ?? false;
                //    bool isEmployee = odr.GetValue(nameof(ReadOnlyEmployeeClassification.IsEmployee)) as bool? ?? false;

                //    result = new ReadOnlyEmployeeClassification(employeeClassificationKey, employeeClassificationName, isExempt, isEmployee);

                //    if (odr.Read())//Single behavior
                //    {
                //        throw new InvalidOperationException("The query result has more than one result.");
                //    }
                //}
                //else
                //{
                //    //Single behavior
                //    throw new InvalidOperationException("The query result is empty.");
                //}

                return result;
            })
            .Execute();
    }

    public void Update(ReadOnlyEmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        var sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName, IsExempt = @IsExempt, IsEmployee = @IsEmployee
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        DbConnector.NonQuery(sql, classification).Execute();
    }
}