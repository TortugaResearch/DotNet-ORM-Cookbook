using System;
using System.Collections.Generic;
using Recipes.Joins;
using Recipes.ServiceStack.Entities;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Recipes.ServiceStack.Joins
{
    public class JoinsScenario : IJoinsScenario<EmployeeDetail, Employee>
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public JoinsScenario(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public int Create(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                return (int)db.Insert(employee, true);
            }
        }

        public IList<EmployeeDetail> FindByEmployeeClassificationKey(int employeeClassificationKey)
        {
            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                var q = db.From<Employee>()
                    .Join<EmployeeClassification>()
                    .Where<EmployeeClassification>(x => x.Id == employeeClassificationKey);
                return db.Select<EmployeeDetail>(q);
            }
        }

        public IList<EmployeeDetail> FindByLastName(string lastName)
        {
            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                var q = db.From<Employee>()
                    .Join<EmployeeClassification>()
                    .Where(x => x.LastName == lastName);
                return db.Select<EmployeeDetail>(q);
            }
        }

        public EmployeeDetail? GetByEmployeeKey(int employeeKey)
        {
            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                var q = db.From<Employee>().Join<EmployeeClassification>()
                    .Where(x => x.Id == employeeKey);
                return db.Single<EmployeeDetail>(q);
            }
        }

        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
        {
            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                return db.SingleById<EmployeeClassification>(employeeClassificationKey);
            }
        }
    }
}
