using Recipes.EF.Models;
using Recipes.Repositories;
using System;
using System.Collections.Generic;

namespace Recipes.EF.Repositories
{
    internal class DepartmentWithChildRepository : IDepartmentWithChildRepository<Department, Division>
    {
        public int Create(Department department)
        {
            throw new NotImplementedException();
        }

        public void Delete(int departmentKey)
        {
            throw new NotImplementedException();
        }

        public void Delete(Department department)
        {
            throw new NotImplementedException();
        }

        public IList<Department> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<Division> GetAllDivisions()
        {
            throw new NotImplementedException();
        }

        public Department GetByKey(int departmentKey)
        {
            throw new NotImplementedException();
        }

        public void Update(Department department)
        {
            throw new NotImplementedException();
        }
    }
}

