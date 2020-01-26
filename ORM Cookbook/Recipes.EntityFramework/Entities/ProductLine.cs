using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.EntityFramework.Entities
{
    [Table("Production.ProductLine")]
    public partial class ProductLine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductLine()
        {
            Product = new HashSet<Product>();
        }

        [Key]
        public int ProductLineKey { get; set; }

        [Required]
        [StringLength(50)]
        public string? ProductLineName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
