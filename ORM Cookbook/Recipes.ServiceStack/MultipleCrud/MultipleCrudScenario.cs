using System;
using Recipes.MultipleCrud;
using Recipes.ServiceStack.Entities;
using ServiceStack.Data;
using System.Collections.Generic;
using System.Linq;
using ServiceStack.OrmLite;

namespace Recipes.ServiceStack.MultipleCrud
{
    public class MultipleCrudScenario : ScenarioBase, IMultipleCrudScenario<Employee>
    {
        public MultipleCrudScenario(IDbConnectionFactory dbConnectionFactory): base(dbConnectionFactory)
        {
        }

        public void DeleteBatch(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var db = OpenConnection())
                db.DeleteAll(employees);
        }

        public void DeleteBatchByKey(IList<int> employeeKeys)
        {
            if (employeeKeys == null || employeeKeys.Count == 0)
                throw new ArgumentException($"{nameof(employeeKeys)} is null or empty.", nameof(employeeKeys));
            
            using (var db = OpenConnection())
                db.DeleteByIds<Employee>(employeeKeys);
        }

        public IList<Employee> FindByLastName(string lastName)
        {
            using (var db = OpenConnection())
                return db.Select<Employee>(e => e.LastName == lastName);
        }

        public void InsertBatch(IList<Employee> employees)
        {
            using (var db = OpenConnection())
                db.InsertAll(employees);
        }

        public IList<int> InsertBatchReturnKeys(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var db = OpenConnection())
                db.SaveAll(employees);

            return employees.Select(e => e.Id).ToList();
        }

        public IList<Employee> InsertBatchReturnRows(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var db = OpenConnection())
                db.SaveAll(employees);

            return employees;
        }

        public void InsertBatchWithRefresh(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));
            
            using (var db = OpenConnection())
                db.SaveAll(employees);
        }

        public void UpdateBatch(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));
            
            using (var db = OpenConnection())
                db.UpdateAll(employees);
        }
    }
}