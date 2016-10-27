namespace Recipes.Models
{
    /// <summary>
    /// This model shows a Department with a FK represented as an integer.
    /// </summary>
    public interface IDepartment
    {
        int DepartmentKey { get; set; }
        string DepartmentName { get; set; }
        int DivisionKey { get; set; }
    }
}
