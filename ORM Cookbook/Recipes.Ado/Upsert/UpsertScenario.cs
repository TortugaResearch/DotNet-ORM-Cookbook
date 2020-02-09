using Microsoft.Data.SqlClient;
using Recipes.Ado.Models;
using Recipes.Upsert;
using System;

namespace Recipes.Ado.Upsert
{
    public class UpsertScenario : SqlServerScenarioBase, IUpsertScenario<Division>
    {
        public UpsertScenario(string connectionString) : base(connectionString)
        { }

        public Division GetByKey(int divisionKey)
        {
            const string sql = @"SELECT d.DivisionKey,
       d.DivisionId,
       d.DivisionName,
       d.CreatedDate,
       d.ModifiedDate,
       d.CreatedByEmployeeKey,
       d.ModifiedByEmployeeKey,
       d.SalaryBudget,
       d.FteBudget,
       d.SuppliesBudget,
       d.FloorSpaceBudget,
       d.MaxEmployees,
       d.LastReviewCycle,
       d.StartTime FROM HR.Division d WHERE d.DivisionKey = @DivisionKey;";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@DivisionKey", divisionKey);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    return new Division(reader);
                }
            }
        }

        public int UpsertByName(Division division)
        {
            if (division == null)
                throw new ArgumentNullException(nameof(division), $"{nameof(division)} is null.");

            const string sql = @"MERGE INTO HR.Division target
USING
(
    VALUES
        (@DivisionKey, @DivisionId, @DivisionName, @ModifiedDate, @CreatedByEmployeeKey,
         @ModifiedByEmployeeKey, @SalaryBudget, @FteBudget, @SuppliesBudget, @FloorSpaceBudget, @MaxEmployees,
         @LastReviewCycle, @StartTime
        )
) source (DivisionKey, DivisionId, DivisionName, ModifiedDate, CreatedByEmployeeKey,
          ModifiedByEmployeeKey, SalaryBudget, FteBudget, SuppliesBudget, FloorSpaceBudget, MaxEmployees,
          LastReviewCycle, StartTime
         )
ON target.DivisionName = source.DivisionName
WHEN MATCHED THEN
    UPDATE SET DivisionId = source.DivisionId,
               ModifiedDate = source.ModifiedDate,
               ModifiedByEmployeeKey = source.ModifiedByEmployeeKey,
               SalaryBudget = source.SalaryBudget,
               FteBudget = source.FteBudget,
               SuppliesBudget = source.SuppliesBudget,
               FloorSpaceBudget = source.FloorSpaceBudget,
               MaxEmployees = source.MaxEmployees,
               LastReviewCycle = source.LastReviewCycle,
               StartTime = source.StartTime
WHEN NOT MATCHED THEN
    INSERT
    (
        DivisionId,
        DivisionName,
        CreatedByEmployeeKey,
        ModifiedByEmployeeKey,
        SalaryBudget,
        FteBudget,
        SuppliesBudget,
        FloorSpaceBudget,
        MaxEmployees,
        LastReviewCycle,
        StartTime
    )
    VALUES
    (source.DivisionId, source.DivisionName, source.CreatedByEmployeeKey, source.ModifiedByEmployeeKey,
     source.SalaryBudget, source.FteBudget, source.SuppliesBudget, source.FloorSpaceBudget, source.MaxEmployees,
     source.LastReviewCycle, source.StartTime)
OUTPUT Inserted.DivisionKey;";

            //update audit column
            division.ModifiedDate = DateTime.UtcNow;

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@DivisionKey", division.DivisionKey);
                cmd.Parameters.AddWithValue("@DivisionName", division.DivisionName);
                cmd.Parameters.AddWithValue("@DivisionId", division.DivisionId);
                cmd.Parameters.AddWithValue("@ModifiedDate", division.ModifiedDate);
                cmd.Parameters.AddWithValue("@CreatedByEmployeeKey", division.CreatedByEmployeeKey);
                cmd.Parameters.AddWithValue("@ModifiedByEmployeeKey", division.ModifiedByEmployeeKey);
                cmd.Parameters.AddWithValue("@FteBudget", (object?)division.FteBudget ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SuppliesBudget", (object?)division.SuppliesBudget ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FloorSpaceBudget", (object?)division.FloorSpaceBudget ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MaxEmployees", (object?)division.MaxEmployees ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LastReviewCycle", (object?)division.LastReviewCycle ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StartTime", (object?)division.StartTime ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SalaryBudget", (object?)division.SalaryBudget ?? DBNull.Value);

                return (int)cmd.ExecuteScalar();
            }
        }

        public int UpsertByPrimaryKey(Division division)
        {
            if (division == null)
                throw new ArgumentNullException(nameof(division), $"{nameof(division)} is null.");

            const string sql = @"MERGE INTO HR.Division target
USING
(
    VALUES
        (@DivisionKey, @DivisionId, @DivisionName, @ModifiedDate, @CreatedByEmployeeKey,
         @ModifiedByEmployeeKey, @SalaryBudget, @FteBudget, @SuppliesBudget, @FloorSpaceBudget, @MaxEmployees,
         @LastReviewCycle, @StartTime
        )
) source (DivisionKey, DivisionId, DivisionName, ModifiedDate, CreatedByEmployeeKey,
          ModifiedByEmployeeKey, SalaryBudget, FteBudget, SuppliesBudget, FloorSpaceBudget, MaxEmployees,
          LastReviewCycle, StartTime
         )
ON target.DivisionKey = source.DivisionKey
WHEN MATCHED THEN
    UPDATE SET DivisionId = source.DivisionId,
               DivisionName = source.DivisionName,
               ModifiedDate = source.ModifiedDate,
               ModifiedByEmployeeKey = source.ModifiedByEmployeeKey,
               SalaryBudget = source.SalaryBudget,
               FteBudget = source.FteBudget,
               SuppliesBudget = source.SuppliesBudget,
               FloorSpaceBudget = source.FloorSpaceBudget,
               MaxEmployees = source.MaxEmployees,
               LastReviewCycle = source.LastReviewCycle,
               StartTime = source.StartTime
WHEN NOT MATCHED THEN
    INSERT
    (
        DivisionId,
        DivisionName,
        CreatedByEmployeeKey,
        ModifiedByEmployeeKey,
        SalaryBudget,
        FteBudget,
        SuppliesBudget,
        FloorSpaceBudget,
        MaxEmployees,
        LastReviewCycle,
        StartTime
    )
    VALUES
    (source.DivisionId, source.DivisionName, source.CreatedByEmployeeKey, source.ModifiedByEmployeeKey,
     source.SalaryBudget, source.FteBudget, source.SuppliesBudget, source.FloorSpaceBudget, source.MaxEmployees,
     source.LastReviewCycle, source.StartTime)
OUTPUT Inserted.DivisionKey;";

            //update audit column
            division.ModifiedDate = DateTime.UtcNow;

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@DivisionKey", division.DivisionKey);
                cmd.Parameters.AddWithValue("@DivisionName", division.DivisionName);
                cmd.Parameters.AddWithValue("@DivisionId", division.DivisionId);
                cmd.Parameters.AddWithValue("@ModifiedDate", division.ModifiedDate);
                cmd.Parameters.AddWithValue("@CreatedByEmployeeKey", division.CreatedByEmployeeKey);
                cmd.Parameters.AddWithValue("@ModifiedByEmployeeKey", division.ModifiedByEmployeeKey);
                cmd.Parameters.AddWithValue("@FteBudget", (object?)division.FteBudget ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SuppliesBudget", (object?)division.SuppliesBudget ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FloorSpaceBudget", (object?)division.FloorSpaceBudget ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MaxEmployees", (object?)division.MaxEmployees ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LastReviewCycle", (object?)division.LastReviewCycle ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StartTime", (object?)division.StartTime ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SalaryBudget", (object?)division.SalaryBudget ?? DBNull.Value);

                return (int)cmd.ExecuteScalar();
            }
        }
    }
}
