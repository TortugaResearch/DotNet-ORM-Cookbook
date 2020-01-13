namespace Recipes.NHibernate.Entities
{
    public partial class EmployeeDetail
    {
        public virtual int EmployeeKey { get; set; }
        public virtual string? FirstName { get; set; }
        public virtual string? MiddleName { get; set; }
        public virtual string? LastName { get; set; }
        public virtual string? Title { get; set; }
        public virtual string? OfficePhone { get; set; }
        public virtual string? CellPhone { get; set; }
        public virtual int EmployeeClassificationKey { get; set; }
        public virtual string? EmployeeClassificationName { get; set; }
        public virtual bool IsExempt { get; set; }
        public virtual bool IsEmployee { get; set; }
    }
}
