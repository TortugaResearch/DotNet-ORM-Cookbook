namespace Recipes.LargeBatch;

public interface ILargeBatchScenario<TEmployeeSimple>
   where TEmployeeSimple : class, IEmployeeSimple, new()
{
    /// <summary>
    /// Gets a collection of Employee rows by their name. Assume the name is not unique.
    /// </summary>
    int CountByLastName(string lastName);

    /// <summary>
    /// Insert a large collection of Employee rows.
    /// </summary>
    void InsertLargeBatch(IList<TEmployeeSimple> employees);

    /// <summary>
    /// Insert a large collection of Employee rows.
    /// </summary>
    /// <param name="employees">The employees.</param>
    /// <param name="batchSize">Size of the batch.</param>
    void InsertLargeBatch(IList<TEmployeeSimple> employees, int batchSize);

    /// <summary>
    /// Gets the maximum size of a batch.
    /// </summary>
    /// <remarks>Return Int32.MaxValue if not limited.</remarks>
    int MaximumBatchSize { get; }
}