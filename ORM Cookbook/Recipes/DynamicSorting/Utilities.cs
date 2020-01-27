using System.Collections.Immutable;

namespace Recipes.DynamicSorting
{
    public static class Utilities
    {
        public static ImmutableHashSet<string> EmployeeColumnNames { get; } = ImmutableHashSet.Create
            ("EmployeeKey", "FirstName", "MiddleName", "LastName", "Title", "OfficePhone",
            "CellPhone", "EmployeeClassificationKey");
    }
}
