using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Recipes.EntityFrameworkCore.Entities
{
    [Table("Division", Schema = "HR")]
    public partial class Division
    {
        public Division()
        {
            Department = new HashSet<Department>();
        }

        public int CreatedByEmployeeKey { get; set; }

        public DateTime CreatedDate { get; set; }

        [InverseProperty("DivisionKeyNavigation")]
        [SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "EF Core requires a public setter on collections in entities.")]
        public virtual ICollection<Department> Department { get; set; }

        public Guid DivisionId { get; set; }

        [Key]
        public int DivisionKey { get; set; }

        [Required]
        [StringLength(30)]
        public string? DivisionName { get; set; }

        public float? FloorSpaceBudget { get; set; }

        [Column(TypeName = "numeric(5, 1)")]
        public decimal? FteBudget { get; set; }

        public DateTimeOffset? LastReviewCycle { get; set; }
        public int? MaxEmployees { get; set; }
        public int ModifiedByEmployeeKey { get; set; }

        public DateTime ModifiedDate { get; set; }

        [Column(TypeName = "decimal(14, 4)")]
        public decimal? SalaryBudget { get; set; }

        public TimeSpan? StartTime { get; set; }

        [Column(TypeName = "decimal(14, 4)")]
        public decimal? SuppliesBudget { get; set; }
    }
}
