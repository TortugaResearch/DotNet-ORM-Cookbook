
using Recipes.NHibernate.Models;
using Recipes.Repositories;
using System.Collections.Generic;
using System;

namespace Recipes.NHibernate.Repositories
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

