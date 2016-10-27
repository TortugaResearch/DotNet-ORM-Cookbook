using System.Collections.Generic;
using System;

namespace Recipes.Repositories
{
    public interface IEmployeeClassification
    {
        int EmployeeClassificationKey { get; set; }
        string EmployeeClassificationName { get; set; }
    }
}
