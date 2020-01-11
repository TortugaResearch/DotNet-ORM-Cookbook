using Recipes.Immutable;
using RepoDb.Attributes;
using System;

namespace Recipes.RepoDb.Entities
{
    [Map("[HR].[EmployeeClassification]")]
    public class ReadOnlyEmployeeClassification : IReadOnlyEmployeeClassification
    {
        public ReadOnlyEmployeeClassification(MutableEmployeeClassification classification)
        {
            if (classification?.EmployeeClassificationName == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification.EmployeeClassificationName)} is null.");

            EmployeeClassificationKey = classification.EmployeeClassificationKey;
            EmployeeClassificationName = classification.EmployeeClassificationName;
            IsExempt = classification.IsExempt;
            IsEmployee = classification.IsEmployee;
        }

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
