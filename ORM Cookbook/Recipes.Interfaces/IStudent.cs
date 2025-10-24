namespace Recipes;

public interface IStudent : ISchool
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string Subject { get; set; }
}