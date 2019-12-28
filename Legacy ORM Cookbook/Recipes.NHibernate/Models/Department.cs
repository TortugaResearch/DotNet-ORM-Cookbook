using Recipes.Models;

namespace Recipes.NHibernate.Models
{
    
    
    public class Department : IDepartment<Division>
    {
        public virtual int DepartmentKey { get; set; }

        public virtual string DepartmentName { get; set; }
        
        public virtual Division Division { get; set; }
    }
}

