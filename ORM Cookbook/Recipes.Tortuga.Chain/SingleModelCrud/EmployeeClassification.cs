using Recipes.SingleModelCrud;
using System.ComponentModel.DataAnnotations.Schema;
using Tortuga.Chain;

namespace Recipes.Chain.SingleModelCrud
{
    [Table("HR.EmployeeClassification")]
    public class EmployeeClassification : IEmployeeClassification
    {
        public int EmployeeClassificationKey { get; set; }

        /// <exclude />
        public string? EmployeeClassificationName { get; set; }
    }
}
