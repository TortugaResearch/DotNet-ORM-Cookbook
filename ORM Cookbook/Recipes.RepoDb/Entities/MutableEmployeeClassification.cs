using Recipes.Immutable;
using RepoDb.Attributes;
using System;

namespace Recipes.RepoDb.Entities
{
    [Map("[HR].[EmployeeClassification]")]
    public class MutableEmployeeClassification
    {
        public MutableEmployeeClassification() { }

        public MutableEmployeeClassification(IReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            EmployeeClassificationKey = classification.EmployeeClassificationKey;
            EmployeeClassificationName = classification.EmployeeClassificationName;
            IsExempt = classification.IsExempt;
            IsEmployee = classification.IsEmployee;
        }

        [Primary]
        public int EmployeeClassificationKey { get; set; }

        public string? EmployeeClassificationName { get; set; }

        public bool IsExempt { get; set; }

        public bool IsEmployee { get; set; }

        internal ReadOnlyEmployeeClassification ToImmutable()
        {
            return new ReadOnlyEmployeeClassification(this);
        }
    }
}
