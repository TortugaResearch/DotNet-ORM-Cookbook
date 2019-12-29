using Recipes.Models;

namespace Recipes.NHibernate.Models
{
    public class EmployeeClassification : IEmployeeClassification
    {
        public virtual int EmployeeClassificationKey { get; set; }

        public virtual string EmployeeClassificationName { get; set; }
    }
}
