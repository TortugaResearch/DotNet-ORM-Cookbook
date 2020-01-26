using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.EntityFramework.Entities
{
    [Table("HR.EmployeeClassification")]
    public partial class EmployeeClassification
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
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

        public bool IsEmployee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
