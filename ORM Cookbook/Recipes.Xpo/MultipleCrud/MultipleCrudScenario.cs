using Recipes.Xpo.Entities;
using Recipes.MultipleCrud;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;

namespace Recipes.Xpo.MultipleCrud
{
    public class MultipleCrudScenario : IMultipleCrudScenario<Employee>
    {

        public void DeleteBatch(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            Session.DefaultSession.Delete(employees);
        }

        public void DeleteBatchByKey(IList<int> employeeKeys)
        {
            if (employeeKeys == null || employeeKeys.Count == 0)
                throw new ArgumentException($"{nameof(employeeKeys)} is null or empty.", nameof(employeeKeys));

            using (var uow = new UnitOfWork())
            {
                foreach (var key in employeeKeys)
                    uow.GetObjectByKey<Employee>(key).Delete();
                uow.CommitChanges();
            }
        }

        public IList<Employee> FindByLastName(string lastName)
        {
            return Session.DefaultSession.Query<Employee>().Where(ec => ec.LastName == lastName).ToList();
        }

        public void InsertBatch(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            Session.DefaultSession.Save(employees);

        }

        public IList<int> InsertBatchReturnKeys(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            Session.DefaultSession.Save(employees);

            return employees.Select(e => e.EmployeeKey).ToList();
        }

        public IList<Employee> InsertBatchReturnRows(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            Session.DefaultSession.Save(employees);
            return employees;
        }

        public void InsertBatchWithRefresh(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            Session.DefaultSession.Save(employees);
        }

        public void UpdateBatch(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            Session.DefaultSession.Save(employees);
        }
    }
}
