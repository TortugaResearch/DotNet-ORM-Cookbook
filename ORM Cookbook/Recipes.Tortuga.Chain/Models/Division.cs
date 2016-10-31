using Recipes.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Chain.Models
{
    [Table("HR.Division")]
    public class Division : IDivision
    {
        public int DivisionKey { get; set; }

        public string DivisionName { get; set; }
    }
}