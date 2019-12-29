using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Recipes.EntityFrameworkCore.Entities
{
    [Table("EmployeeClassification", Schema = "HR")]
    public partial class EmployeeClassification
    {
        public EmployeeClassification()
        {
            Employee = new HashSet<Employee>();
        }

        [Key]
        public int EmployeeClassificationKey { get; set; }

        [StringLength(30)]
        public string? EmployeeClassificationName { get; set; }

        [InverseProperty("EmployeeClassificationKeyNavigation")]
        [SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "EF Core requires a public setter on collections in entities.")]
        public virtual ICollection<Employee>? Employee { get; set; }
    }
}
