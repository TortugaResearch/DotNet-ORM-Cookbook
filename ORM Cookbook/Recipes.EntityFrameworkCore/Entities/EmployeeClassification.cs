using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Recipes.EntityFrameworkCore.Entities;

[Table("EmployeeClassification", Schema = "HR")]
[Index(nameof(EmployeeClassificationName), Name = "UX_EmployeeClassification_EmployeeClassificationName", IsUnique = true)]
public partial class EmployeeClassification
{
    public EmployeeClassification()
    {
        Employees = new HashSet<Employee>();
    }

    [Key]
    public int EmployeeClassificationKey { get; set; }

    [Required]
    [StringLength(30)]
    public string EmployeeClassificationName { get; set; }

    public bool IsExempt { get; set; }

    [Required]
    public bool? IsEmployee { get; set; }

    [InverseProperty(nameof(Employee.EmployeeClassificationKeyNavigation))]
    public virtual ICollection<Employee> Employees { get; set; }
}