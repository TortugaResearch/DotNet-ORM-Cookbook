using Recipes.Chain.Models;
using Recipes.Repositories;
using System.Collections.Generic;
using Tortuga.Chain;

namespace Recipes.Chain
{
    internal class DepartmentWithChildRepository : IDepartmentWithChildRepository<Department, Division>
    {
        readonly SqlServerDataSource m_DataSource;

        public DepartmentWithChildRepository(SqlServerDataSource dataSource)
        {
            m_DataSource = dataSource;
        }

        public int Create(Department department)
        {
            return m_DataSource.Insert(department).ToInt32().Execute();
        }

        public void Delete(int departmentKey)
        {
            m_DataSource.DeleteByKey("HR.Department", departmentKey).Execute();
        }

        public void Delete(Department department)
        {
            m_DataSource.Delete(department).Execute();
        }

        public IList<Department> GetAll()
        {
            return m_DataSource.From("HR.DepartmentDetail").ToCollection<Department>().Execute();
        }

        public IList<Division> GetAllDivisions()
        {
            return m_DataSource.From("HR.Division").ToCollection<Division>().Execute();
        }

        public Department GetByKey(int departmentKey)
        {
            return m_DataSource.From("HR.DepartmentDetail", new { DepartmentKey = departmentKey }).ToObject<Department>().Execute();
        }

        public void Update(Department department)
        {
            m_DataSource.Update(department).Execute();
        }
    }
}

