using Recipes.Immutable;
using Recipes.NPoco.Models;

namespace Recipes.NPoco.Immutable
{
    public class ImmutableScenario : ScenarioBase, IImmutableScenario<ReadOnlyEmployeeClassification>
    {
        public ImmutableScenario(string connectionString) : base(connectionString)
        {
        }

        public int Create(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            throw new NotImplementedException();
        }

        public void Delete(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            throw new NotImplementedException();
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyEmployeeClassification? FindByName(string employeeClassificationName)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<ReadOnlyEmployeeClassification> GetAll()
        {
            throw new NotImplementedException();
        }

        public ReadOnlyEmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            throw new NotImplementedException();
        }

        public void Update(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            throw new NotImplementedException();
        }
    }
}