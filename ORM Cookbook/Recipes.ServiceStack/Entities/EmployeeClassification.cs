using System.Collections.Generic;
using Recipes.TryCrud;
using ServiceStack.DataAnnotations;

namespace Recipes.ServiceStack.Entities
{
    [Alias("EmployeeClassification")]
    [Schema("HR")]
    public class EmployeeClassification :
        IEmployeeClassification,
        Recipes.SingleModelCrudAsync.IEmployeeClassification,
        Recipes.SingleModelCrud.IEmployeeClassification
    {
        [PrimaryKey, AutoIncrement]
        [Alias("EmployeeClassificationKey")]
        public int Id { get; set; }

        [Default(0)]
        public bool IsExempt { get; set; }

        [Default(1)]
        public bool? IsEmployee { get; set; }

        [Reference] public virtual List<Employee> Employees { get; } = new List<Employee>();

        [Ignore]
        public int EmployeeClassificationKey
        {
            get => Id;
            set => Id = value;
        }

        [Required] [StringLength(30)] public string? EmployeeClassificationName { get; set; }
    }

    [Alias("EmployeeClassification")]
    [Schema("HR")]
    public class EmployeeClassificationPartial :
        Recipes.PartialUpdate.IEmployeeClassification
    {
        [PrimaryKey, AutoIncrement]
        [Alias("EmployeeClassificationKey")]
        public int Id { get; set; }

        [Reference] public virtual List<Employee> Employees { get; } = new List<Employee>();

        [Ignore]
        public int EmployeeClassificationKey
        {
            get => Id;
            set => Id = value;
        }

        [Required] [StringLength(30)] public string? EmployeeClassificationName { get; set; }

        public bool IsExempt { get; set; }

        [Required] public bool IsEmployee { get; set; }
    }
}