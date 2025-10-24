using System.Data;

namespace Recipes.Ado.Models;

public class Division : IDivision
{
    public Division()
    {
    }

    public Division(IDataReader reader)
    {
        if (reader == null)
            throw new ArgumentNullException(nameof(reader), $"{nameof(reader)} is null.");

        CreatedByEmployeeKey = reader.GetInt32(reader.GetOrdinal("CreatedByEmployeeKey"));
        CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"));
        DivisionId = reader.GetGuid(reader.GetOrdinal("DivisionId"));
        DivisionKey = reader.GetInt32(reader.GetOrdinal("DivisionKey"));
        DivisionName = reader.GetString(reader.GetOrdinal("DivisionName"));

        if (!reader.IsDBNull(reader.GetOrdinal("FloorSpaceBudget")))
            FloorSpaceBudget = reader.GetFloat(reader.GetOrdinal("FloorSpaceBudget"));

        if (!reader.IsDBNull(reader.GetOrdinal("FteBudget")))
            FteBudget = reader.GetDecimal(reader.GetOrdinal("FteBudget"));

        if (!reader.IsDBNull(reader.GetOrdinal("LastReviewCycle")))
            LastReviewCycle = (DateTimeOffset)reader.GetValue(reader.GetOrdinal("LastReviewCycle"));

        if (!reader.IsDBNull(reader.GetOrdinal("MaxEmployees")))
            MaxEmployees = reader.GetInt32(reader.GetOrdinal("MaxEmployees"));
        ModifiedByEmployeeKey = reader.GetInt32(reader.GetOrdinal("ModifiedByEmployeeKey"));
        ModifiedDate = reader.GetDateTime(reader.GetOrdinal("ModifiedDate"));

        if (!reader.IsDBNull(reader.GetOrdinal("SalaryBudget")))
            SalaryBudget = reader.GetDecimal(reader.GetOrdinal("SalaryBudget"));

        if (!reader.IsDBNull(reader.GetOrdinal("StartTime")))
            StartTime = (TimeSpan)reader.GetValue(reader.GetOrdinal("StartTime"));

        if (!reader.IsDBNull(reader.GetOrdinal("SuppliesBudget")))
            SuppliesBudget = reader.GetDecimal(reader.GetOrdinal("SuppliesBudget"));
    }

    public int CreatedByEmployeeKey { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid DivisionId { get; set; }

    public int DivisionKey { get; set; }

    public string? DivisionName { get; set; }

    public float? FloorSpaceBudget { get; set; }

    public decimal? FteBudget { get; set; }

    public DateTimeOffset? LastReviewCycle { get; set; }
    public int? MaxEmployees { get; set; }
    public int ModifiedByEmployeeKey { get; set; }

    public DateTime ModifiedDate { get; set; }

    public decimal? SalaryBudget { get; set; }

    public TimeSpan? StartTime { get; set; }

    public decimal? SuppliesBudget { get; set; }
}