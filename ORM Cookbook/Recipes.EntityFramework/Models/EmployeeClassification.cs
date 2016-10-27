namespace Recipes.EF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.EmployeeClassification")]
    public partial class EmployeeClassification
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmployeeClassification()
        {
            Employees = new HashSet<Recipes.EF.Models.Employee>();
        }

        [Key]
        public int EmployeeClassificationKey { get; set; }

        [StringLength(30)]
        public string EmployeeClassificationName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recipes.EF.Models.Employee> Employees { get; set; }
    }
}
