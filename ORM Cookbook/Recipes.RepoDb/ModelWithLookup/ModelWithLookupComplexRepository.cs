using Recipes.ModelWithLookup;
using Recipes.RepoDb.Entities;
using RepoDb;
using RepoDb.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Recipes.RepoDb.ModelWithLookup
{
    public class ModelWithLookupComplexRepository : DbRepository<SqlConnection>,
        IModelWithLookupComplexRepository<EmployeeComplex>
    {
        public ModelWithLookupComplexRepository(string connectionString)
            : base(connectionString)
        { }

        public int Create(EmployeeComplex employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");
            if (employee.EmployeeClassification == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee.EmployeeClassification)} is null.");

            return Insert<EmployeeComplex, int>(employee);
        }

        public void Delete(EmployeeComplex employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            base.Delete(employee);
        }

        public void DeleteByKey(int employeeKey)
        {
            Delete<EmployeeComplex>(employeeKey);
        }

        public IList<EmployeeComplex> FindByLastName(string lastName)
        {
            return Query<EmployeeComplex>(e => e.LastName == lastName).AsList();
        }

        public IList<EmployeeComplex> GetAll()
        {
            return QueryAll<EmployeeComplex>().AsList();
        }

        public EmployeeComplex? GetByKey(int employeeKey)
        {
            var employee = Query<EmployeeComplex>(employeeKey).FirstOrDefault();
            if (employee != null)
            {
                employee.EmployeeClassification = Query<EmployeeClassificationModelWithLookup>(employee.EmployeeClassificationKey).FirstOrDefault();
            }
            return employee;
        }

        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
        {
            return Query<EmployeeClassificationModelWithLookup>(employeeClassificationKey).FirstOrDefault();
        }

        public void Update(EmployeeComplex employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");
            if (employee.EmployeeClassification == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee.EmployeeClassification)} is null.");

            base.Update(employee);
        }
    }
}
