using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Recipes.EntityFrameworkCore.Entities;

[Table("Division", Schema = "HR")]
[Index(nameof(DivisionName), Name = "UX_Division_DivisionName", IsUnique = true)]
public partial class Division
{
    public Division()
    {
        Departments = new HashSet<Department>();
    }

    [Key]
    public int DivisionKey { get; set; }

    public Guid DivisionId { get; set; }

    [Required]
    [StringLength(30)]
    public string DivisionName { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public int CreatedByEmployeeKey { get; set; }
    public int ModifiedByEmployeeKey { get; set; }

    [Column(TypeName = "decimal(14, 4)")]
    public decimal? SalaryBudget { get; set; }

    [Column(TypeName = "numeric(5, 1)")]
    public decimal? FteBudget { get; set; }

    [Column(TypeName = "decimal(14, 4)")]
    public decimal? SuppliesBudget { get; set; }

    public float? FloorSpaceBudget { get; set; }
    public int? MaxEmployees { get; set; }
    public DateTimeOffset? LastReviewCycle { get; set; }
    public TimeSpan? StartTime { get; set; }

    [ForeignKey(nameof(CreatedByEmployeeKey))]
    [InverseProperty(nameof(Employee.DivisionCreatedByEmployeeKeyNavigations))]
    public virtual Employee CreatedByEmployeeKeyNavigation { get; set; }

    [ForeignKey(nameof(ModifiedByEmployeeKey))]
    [InverseProperty(nameof(Employee.DivisionModifiedByEmployeeKeyNavigations))]
    public virtual Employee ModifiedByEmployeeKeyNavigation { get; set; }

    [InverseProperty(nameof(Department.DivisionKeyNavigation))]
    public virtual ICollection<Department> Departments { get; set; }
}