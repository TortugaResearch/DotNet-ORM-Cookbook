namespace Recipes.PartialUpdate
{
    public interface IPartialUpdateRepository<TEmployeeClassification>
       where TEmployeeClassification : class, IEmployeeClassification, new()
    {
        /// <summary>
        /// Gets an EmployeeClassification row by its primary key.
        /// </summary>
        TEmployeeClassification? GetByKey(int employeeClassificationKey);

        /// <summary>
        /// Create a new EmployeeClassification row, returning the new primary key.
        /// </summary>
        int Create(TEmployeeClassification classification);

        void UpdateWithObject(EmployeeClassificationNameUpdater updateMessage);

        void UpdateWithObject(EmployeeClassificationFlagsUpdater updateMessage);

        void UpdateWithSeparateParameters(int employeeClassificationKey, bool isExempt, bool isEmployee);
    }
}
