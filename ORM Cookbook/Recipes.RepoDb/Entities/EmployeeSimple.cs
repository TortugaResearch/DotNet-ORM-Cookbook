using RepoDb.Attributes;

namespace Recipes.RepoDb.Entities
{
    [Map("[HR].[Employee]")]
    public class EmployeeSimple : IEmployeeSimple
    {
        public string? CellPhone { get; set; }

        public int EmployeeClassificationKey { get; set; }

        [Primary]
        public int EmployeeKey { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? OfficePhone { get; set; }
        public string? Title { get; set; }
    }
}
