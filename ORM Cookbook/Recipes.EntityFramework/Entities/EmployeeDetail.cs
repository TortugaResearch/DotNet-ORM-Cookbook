using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.EntityFramework.Entities
{
    [Table("HR.EmployeeDetail")]
    public partial class EmployeeDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeKey { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? MiddleName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string? LastName { get; set; }

        [StringLength(100)]
        public string? Title { get; set; }

        [StringLength(15)]
        public string? OfficePhone { get; set; }

        [StringLength(15)]
        public string? CellPhone { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeClassificationKey { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(30)]
        public string? EmployeeClassificationName { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool IsExempt { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool IsEmployee { get; set; }
    }
}
