using RepoDb.Attributes;

namespace Recipes.RepoDb.Entities
{
    [Map("[HR].[Employee]")]
    public class EmployeeComplex : IEmployeeComplex
    {
        [Primary]
        public int EmployeeKey { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? OfficePhone { get; set; }
        public string? CellPhone { get; set; }
        public int EmployeeClassificationKey { get; set; }
        public EmployeeClassificationModelWithLookup? EmployeeClassification { get; set; }

        //Used for linking the entity to the test framework. Not part of the recipe.
        IReadOnlyEmployeeClassification? IEmployeeComplex.EmployeeClassification
        {
            get => EmployeeClassification;
            set
            {
                EmployeeClassification = (EmployeeClassificationModelWithLookup?)value;
                EmployeeClassificationKey = (value?.EmployeeClassificationKey).GetValueOrDefault();
            }
        }
    }
}
