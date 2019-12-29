using Recipes.SingleModelCrud;
using RepoDb.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.RepoDb.SingleModelCrud
{
    [Map("HR.EmployeeClassification")]
    public class EmployeeClassification : IEmployeeClassification
    {
        [Primary]
        public int EmployeeClassificationKey { get; set; }

        /// <exclude />
        public string? EmployeeClassificationName { get; set; }
    }
}
