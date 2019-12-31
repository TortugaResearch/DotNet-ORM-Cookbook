using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [StringLength(30)]
        public string? EmployeeClassificationName { get; set; }

        public bool IsExempt { get; set; }

        [Required]
        public bool? IsEmployee { get; set; }

        [InverseProperty("EmployeeClassificationKeyNavigation")]
        public virtual ICollection<Employee> Employee { get; }
    }
}
