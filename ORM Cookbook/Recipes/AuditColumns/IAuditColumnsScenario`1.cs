namespace Recipes.AuditColumns;

public interface IAuditColumnsScenario<TDepartment>
   where TDepartment : class, IDepartment, new()
{
	/// <summary>
	/// Creates the department.
	/// </summary>
	/// <param name="department">The department.</param>
	/// <param name="user">The user.</param>
	/// <returns>System.Int32.</returns>
	int CreateDepartment(TDepartment department, User user);

	/// <summary>
	/// Updates the department.
	/// </summary>
	/// <param name="department">The department.</param>
	/// <param name="user">The user.</param>
	void UpdateDepartment(TDepartment department, User user);

	/// <summary>
	/// Gets the department.
	/// </summary>
	/// <param name="departmentKey">The department key.</param>
	/// <returns>TDepartment.</returns>
	TDepartment? GetDepartment(int departmentKey, User user);
}
