namespace Recipes.NHibernate.Entities
{
    public partial class EmployeeComplex
    {
        public virtual string? CellPhone { get; set; }
        public virtual EmployeeClassification? EmployeeClassification { get; set; }
        public virtual int EmployeeKey { get; set; }
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
        public virtual string? MiddleName { get; set; }
        public virtual string? OfficePhone { get; set; }
        public virtual string? Title { get; set; }
    }

    partial class EmployeeComplex : IEmployeeComplex
    {
        IReadOnlyEmployeeClassification? IEmployeeComplex.EmployeeClassification
        {
            get => EmployeeClassification;
            set => EmployeeClassification = (EmployeeClassification?)value;
        }
    }
}
