using Recipes.PartialUpdate;

namespace Recipes.RepoDb.PartialUpdate
{
    public class EmployeeClassification : IEmployeeClassification
    {
        public int EmployeeClassificationKey { get; set; }

        /// <exclude />
        public string? EmployeeClassificationName { get; set; }

        public bool IsExempt { get; set; }
        public bool IsEmployee { get; set; }
    }
}
