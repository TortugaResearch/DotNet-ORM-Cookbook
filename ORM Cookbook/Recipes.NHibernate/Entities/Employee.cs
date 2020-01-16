namespace Recipes.NHibernate.Entities
{
    public partial class Employee : IEmployeeSimple
    {
        public virtual string? CellPhone { get; set; }
        public virtual int EmployeeClassificationKey { get; set; }
        public virtual int EmployeeKey { get; set; }
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
        public virtual string? MiddleName { get; set; }
        public virtual string? OfficePhone { get; set; }
        public virtual string? Title { get; set; }
    }
}
