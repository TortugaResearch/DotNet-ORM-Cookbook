using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Chain.SingleModelCrudAsync
{
    [Table("HR.EmployeeClassification")]
    public class EmployeeClassification : Recipes.SingleModelCrudAsync.IEmployeeClassification
    {
        public int EmployeeClassificationKey { get; set; }

        /// <exclude />
        public string? EmployeeClassificationName { get; set; }
    }
}
