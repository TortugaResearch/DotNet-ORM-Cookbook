using Recipes.SingleModelCrudAsync;
using RepoDb.Attributes;

namespace Recipes.RepoDb.SingleModelCrudAsync
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
