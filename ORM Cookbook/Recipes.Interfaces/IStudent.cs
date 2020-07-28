namespace Recipes
{
    public interface IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public int SchoolId { get; set; }
    }
}
