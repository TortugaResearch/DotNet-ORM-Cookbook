using LinqToDB.Mapping;
using System;

namespace Recipes.LinqToDB.Entities
{
    [Table("Division", Schema = "HR")]
    public partial class Division
    {
        [Column]
        public int CreatedByEmployeeKey { get; set; }

        [Column]
        public DateTime CreatedDate { get; set; }

        [Column]
        public Guid DivisionId { get; set; }

        [PrimaryKey, Identity]
        public int DivisionKey { get; set; }

        [Column]
        public string? DivisionName { get; set; }

        [Column]
        public float? FloorSpaceBudget { get; set; }

        [Column]
        public decimal? FteBudget { get; set; }

        [Column]
        public DateTimeOffset? LastReviewCycle { get; set; }

        [Column]
        public int? MaxEmployees { get; set; }

        [Column]
        public int ModifiedByEmployeeKey { get; set; }

        [Column]
        public DateTime ModifiedDate { get; set; }

        [Column]
        public decimal? SalaryBudget { get; set; }

        [Column]
        public TimeSpan? StartTime { get; set; }

        [Column]
        public decimal? SuppliesBudget { get; set; }
    }

    //Used for linking the entity to the test framework. Not part of the recipe.
    partial class Division : Recipes.IDivision
    {
    }
}
