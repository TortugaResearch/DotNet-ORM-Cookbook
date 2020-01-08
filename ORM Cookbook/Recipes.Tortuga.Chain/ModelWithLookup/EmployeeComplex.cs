using Recipes.ModelWithLookup;
using System.ComponentModel.DataAnnotations.Schema;
using Tortuga.Anchor.Modeling;
using Tortuga.Chain;

namespace Recipes.Chain.ModelWithLookup
{
    [Table("HR.Employee")]
    public class EmployeeComplex : IEmployeeComplex
    {
        public int EmployeeKey { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? OfficePhone { get; set; }
        public string? CellPhone { get; set; }

        //Used for Insert/Update operations
        public int EmployeeClassificationKey => EmployeeClassification?.EmployeeClassificationKey ?? 0;

        [Decompose] //Used for Read operations
        public EmployeeClassification? EmployeeClassification { get; set; }

        //Used for linking the entity to the test framework. Not part of the recipe.
        IEmployeeClassification? IEmployeeComplex.EmployeeClassification
        {
            get => EmployeeClassification;
            set => EmployeeClassification = (EmployeeClassification?)value;
        }
    }
}
