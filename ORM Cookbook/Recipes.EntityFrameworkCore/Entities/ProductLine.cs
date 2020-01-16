using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.EntityFrameworkCore.Entities
{
    [Table("ProductLine", Schema = "Production")]
    public partial class ProductLine
    {
        public ProductLine()
        {
            Product = new HashSet<Product>();
        }

        [Key]
        public int ProductLineKey { get; set; }

        [Required]
        [StringLength(50)]
        public string? ProductLineName { get; set; }

        [InverseProperty("ProductLineKeyNavigation")]
        public virtual ICollection<Product> Product { get; }
    }
}
