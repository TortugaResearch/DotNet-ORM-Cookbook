using Recipes.Chain.Models;
using Recipes.Repositories;
using System.Collections.Generic;
using Tortuga.Chain;

namespace Recipes.Chain
{
    internal class SimpleDepartmentRepository : ISimpleDepartmentRepository<SimpleDepartment>
    {
        readonly SqlServerDataSource m_DataSource;

        public SimpleDepartmentRepository(SqlServerDataSource dataSource)
        {
            m_DataSource = dataSource;
        }

        public int Create(SimpleDepartment department)
        {
            return m_DataSource.Insert(department).ToInt32().Execute();
        }

        public void Delete(int departmentKey)
        {
            m_DataSource.DeleteByKey("HR.Department", departmentKey).Execute();
        }

        public void Delete(SimpleDepartment department)
        {
            m_DataSource.Delete(department).Execute();
        }

        public IList<SimpleDepartment> GetAll()
        {
            return m_DataSource.From("HR.Department").ToCollection<SimpleDepartment>().Execute();
        }

        public IList<Division> GetAllDivisions()
        {
            return m_DataSource.From("HR.Division").ToCollection<Division>().Execute();
        }

        public SimpleDepartment GetByKey(int departmentKey)
        {
            return m_DataSource.From("HR.Department", new { DepartmentKey = departmentKey }).ToObject<SimpleDepartment>().Execute();
        }

        public void Update(SimpleDepartment department)
        {
            m_DataSource.Update(department).Execute();
        }
    }
}

