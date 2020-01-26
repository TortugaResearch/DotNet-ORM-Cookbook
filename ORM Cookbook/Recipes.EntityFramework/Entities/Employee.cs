using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Recipes.EntityFramework.Entities
{
    [Table("HR.Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Division = new HashSet<Division>();
            Division1 = new HashSet<Division>();
        }

        [Key]
        public int EmployeeKey { get; set; }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

        [StringLength(100)]
        public string? Title { get; set; }

        [StringLength(15)]
        public string? OfficePhone { get; set; }

        [StringLength(15)]
        public string? CellPhone { get; set; }

        public int EmployeeClassificationKey { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Division> Division { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Division> Division1 { get; set; }

        public virtual EmployeeClassification? EmployeeClassification { get; set; }
    }
}
