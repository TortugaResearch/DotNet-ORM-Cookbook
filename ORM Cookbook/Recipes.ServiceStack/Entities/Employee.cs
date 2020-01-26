using ServiceStack;
using ServiceStack.DataAnnotations;

namespace Recipes.ServiceStack.Entities
{
    [Alias("Employee")]
    [Schema("HR")]
    public partial class Employee
    {
        [PrimaryKey, AutoIncrement]
        [Alias("EmployeeKey")]
        public int Id { get; set; }

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

        [References(typeof(EmployeeClassification))]
        [Alias("EmployeeClassificationKey")]
        public int? EmployeeClassificationId { get; set; }

        [Reference]
        public virtual EmployeeClassification? EmployeeClassification { get; set; }
    }

    //Used for linking the entity to the test framework. Not part of the recipe.
    public partial class Employee : IEmployeeSimple
    {
        [Ignore]
        public int EmployeeKey { get => Id; set => Id = value; }
        [Ignore]
        int IEmployeeSimple.EmployeeClassificationKey { get => EmployeeClassificationId ?? 0; set => EmployeeClassificationId = value; }
    }

    //Used for linking the entity to the test framework. Not part of the recipe.
    partial class Employee : IEmployeeComplex
    {
        IReadOnlyEmployeeClassification? IEmployeeComplex.EmployeeClassification { 
            get => EmployeeClassification;
            set => EmployeeClassification = value?.ConvertTo<EmployeeClassification>();
        }
    }
}
