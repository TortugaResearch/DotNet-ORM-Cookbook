using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Recipes.EntityFramework.Entities;

[Table("HR.Division")]
public partial class Division
{
    [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Division()
    {
        Department = new HashSet<Department>();
    }

    [Key]
    public int DivisionKey { get; set; }

    public Guid DivisionId { get; set; }

    [Required]
    [StringLength(30)]
    public string? DivisionName { get; set; }

    [Column(TypeName = "datetime2")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime2")]
    public DateTime ModifiedDate { get; set; }

    public int CreatedByEmployeeKey { get; set; }

    public int ModifiedByEmployeeKey { get; set; }

    public decimal? SalaryBudget { get; set; }

    [Column(TypeName = "numeric")]
    public decimal? FteBudget { get; set; }

    public decimal? SuppliesBudget { get; set; }

    public float? FloorSpaceBudget { get; set; }

    public int? MaxEmployees { get; set; }

    public DateTimeOffset? LastReviewCycle { get; set; }

    public TimeSpan? StartTime { get; set; }

    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Department> Department { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Employee? Employee1 { get; set; }
}