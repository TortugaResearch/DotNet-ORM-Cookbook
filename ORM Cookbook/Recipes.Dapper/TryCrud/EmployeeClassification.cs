namespace Recipes.Dapper.TryCrud
{
    public class EmployeeClassification : Recipes.TryCrud.IEmployeeClassification
    {
        public int EmployeeClassificationKey { get; set; }

        /// <exclude />
        public string? EmployeeClassificationName { get; set; }
    }
}
