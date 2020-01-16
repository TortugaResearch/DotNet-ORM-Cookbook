using RepoDb.Attributes;

namespace Recipes.RepoDb.Entities
{
    [Map("[HR].[EmployeeClassification]")]
    public class EmployeeClassificationModelWithLookup : IEmployeeClassification
    {
        [Primary]
        public int EmployeeClassificationKey { get; set; }

        /// <exclude />
        public string? EmployeeClassificationName { get; set; }

        public bool IsExempt { get; set; }

        public bool IsEmployee { get; set; }
    }
}
