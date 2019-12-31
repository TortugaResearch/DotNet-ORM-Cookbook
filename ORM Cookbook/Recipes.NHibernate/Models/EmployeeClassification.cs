namespace Recipes.NHibernate.Models
{
    public partial class EmployeeClassification
    {
        public virtual int EmployeeClassificationKey { get; set; }

        public virtual string? EmployeeClassificationName { get; set; }
        public virtual bool IsExempt { get; set; }
        public virtual bool IsEmployee { get; set; }
    }
}
