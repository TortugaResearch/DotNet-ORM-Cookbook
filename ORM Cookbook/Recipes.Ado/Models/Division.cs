using Recipes.Models;

namespace Recipes.Ado.Models
{
    public class Division : IDivision
    {
        public int DivisionKey { get; set; }

        public string DivisionName { get; set; }
    }
}