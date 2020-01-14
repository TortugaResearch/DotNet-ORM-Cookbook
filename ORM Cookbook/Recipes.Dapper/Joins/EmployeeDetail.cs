using Recipes.Joins;

namespace Recipes.Dapper.Joins
{
    public class EmployeeDetail : IEmployeeDetail
    {
        public int EmployeeKey { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? OfficePhone { get; set; }
        public string? CellPhone { get; set; }
        public int EmployeeClassificationKey { get; set; }
        public string? EmployeeClassificationName { get; set; }
        public bool IsExempt { get; set; }
        public bool IsEmployee { get; set; }
    }
}
