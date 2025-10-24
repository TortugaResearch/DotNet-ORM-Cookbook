namespace Recipes;

/// <summary>
/// The ISchool interface represents an entity that may be filtered by a tenant ID.
/// </summary>
public interface ISchool
{
    /// <summary>
    /// Gets or sets the tenant ID. In this case, a school identifier.
    /// </summary>
    /// <value>The school identifier.</value>
    public int SchoolId { get; set; }
}