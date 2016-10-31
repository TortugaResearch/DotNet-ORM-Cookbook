namespace Recipes.Models
{
    /// <summary>
    /// This model shows a Department with a FK represented as a child object.
    /// </summary>
    /// <typeparam name="TDivision">The type of the t division.</typeparam>
    public interface IDepartment<TDivision> where TDivision : IDivision
    {
        int DepartmentKey { get; set; }
        string DepartmentName { get; set; }
        TDivision Division { get; set; }
    }
}
