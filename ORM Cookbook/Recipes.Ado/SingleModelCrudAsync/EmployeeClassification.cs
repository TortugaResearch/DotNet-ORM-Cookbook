namespace Recipes.Ado.SingleModelCrudAsync
{
    public class EmployeeClassification : Recipes.SingleModelCrudAsync.IEmployeeClassification
    {
        public int EmployeeClassificationKey { get; set; }

        /// <exclude />
        public string? EmployeeClassificationName { get; set; }
    }
}
