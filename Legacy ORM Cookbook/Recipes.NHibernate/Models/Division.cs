using Recipes.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.NHibernate.Models
{
    
    public class Division : IDivision
    {
        public virtual int DivisionKey { get; set; }

        public virtual string DivisionName { get; set; }
    }
}