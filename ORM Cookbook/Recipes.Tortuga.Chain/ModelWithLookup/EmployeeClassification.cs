using Recipes.ModelWithLookup;
using System.ComponentModel.DataAnnotations.Schema;
using Tortuga.Chain;

namespace Recipes.Chain.ModelWithLookup
{
    [Table("HR.EmployeeClassification")]
    public class EmployeeClassification : IEmployeeClassification
    {
        public int EmployeeClassificationKey { get; set; }

        /// <exclude />
        public string? EmployeeClassificationName { get; set; }

        public bool IsExempt { get; set; }

        public bool IsEmployee { get; set; }
    }
}
