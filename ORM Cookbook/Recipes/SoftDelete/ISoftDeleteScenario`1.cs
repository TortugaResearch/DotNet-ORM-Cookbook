namespace Recipes.SoftDelete;

public interface ISoftDeleteScenario<TDepartment>
   where TDepartment : class, IDepartment, new()
{
    /// <summary>
    /// Creates the department.
    /// </summary>
    /// <param name="department">The department.</param>
    /// <param name="user">The user.</param>
    /// <returns>System.Int32.</returns>
    int CreateDepartment(TDepartment department);

    /// <summary>
    /// Deletes the department.
    /// </summary>
    /// <param name="department">The department.</param>
    void DeleteDepartment(TDepartment department);

    /// <summary>
    /// Updates the department.
    /// </summary>
    /// <param name="department">The department.</param>
    /// <param name="user">The user.</param>
    void UpdateDepartment(TDepartment department);

    /// <summary>
    /// Undeletes the department.
    /// </summary>
    /// <param name="departmentKey">The department key.</param>
    void UndeleteDepartment(int departmentKey);

    /// <summary>
    /// Gets the department.
    /// </summary>
    /// <param name="departmentKey">The department key.</param>
    /// <returns>TDepartment.</returns>
    TDepartment? GetDepartment(int departmentKey);

    /// <summary>
    /// Gets the department ignoring the IsDeleted flag.
    /// </summary>
    /// <param name="departmentKey">The department key.</param>
    /// <returns>System.Nullable&lt;TDepartment&gt;.</returns>
    TDepartment? GetDepartmentIgnoringIsDeleted(int departmentKey);
}
