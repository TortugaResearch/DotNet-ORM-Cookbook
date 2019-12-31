using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Chain.SingleModelCrud
{
    [Table("HR.EmployeeClassification")]
    public class EmployeeClassification : Recipes.SingleModelCrud.IEmployeeClassification
    {
        public int EmployeeClassificationKey { get; set; }

        /// <exclude />
        public string? EmployeeClassificationName { get; set; }
    }
}
