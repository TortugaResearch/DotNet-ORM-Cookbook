namespace Recipes.NHibernate.Entities
{
    public partial class EmployeeClassification : IEmployeeClassification
    {
        public virtual int EmployeeClassificationKey { get; set; }

        public virtual string? EmployeeClassificationName { get; set; }
        public virtual bool IsEmployee { get; set; }
        public virtual bool IsExempt { get; set; }
    }
}
