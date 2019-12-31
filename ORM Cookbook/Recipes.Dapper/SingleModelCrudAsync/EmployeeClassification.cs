namespace Recipes.Dapper.SingleModelCrudAsync
{
    public class EmployeeClassification : Recipes.SingleModelCrudAsync.IEmployeeClassification
    {
        public int EmployeeClassificationKey { get; set; }

        /// <exclude />
        public string? EmployeeClassificationName { get; set; }
    }
}
