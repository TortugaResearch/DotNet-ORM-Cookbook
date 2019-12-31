namespace Recipes.Dapper.PartialUpdate
{
    public class EmployeeClassification : Recipes.PartialUpdate.IEmployeeClassification
    {
        public int EmployeeClassificationKey { get; set; }

        /// <exclude />
        public string? EmployeeClassificationName { get; set; }

        public bool IsExempt { get; set; }
        public bool IsEmployee { get; set; }
    }
}
