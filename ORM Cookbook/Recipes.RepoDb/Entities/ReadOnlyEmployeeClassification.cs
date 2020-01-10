using Recipes.Immutable;
using RepoDb.Attributes;

namespace Recipes.RepoDb.Immutable
{
    [Map("[HR].[EmployeeClassification]")]
    public class ReadOnlyEmployeeClassification : IReadOnlyEmployeeClassification
    {
        public ReadOnlyEmployeeClassification(int employeeClassificationKey,
            string employeeClassificationName,
            bool isExempt,
            bool isEmployee)
        {
            EmployeeClassificationKey = employeeClassificationKey;
            EmployeeClassificationName = employeeClassificationName;
            IsExempt = isExempt;
            IsEmployee = isEmployee;
        }

        [Primary]
        public int EmployeeClassificationKey { get; }

        public string EmployeeClassificationName { get; }

        public bool IsExempt { get; }

        public bool IsEmployee { get; }
    }
}
