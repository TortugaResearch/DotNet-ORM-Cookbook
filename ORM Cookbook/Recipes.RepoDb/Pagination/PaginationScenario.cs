using Recipes.Pagination;
using Recipes.RepoDB.Models;
using RepoDb;
using RepoDb.Enumerations;
using RepoDb.Extensions;

namespace Recipes.RepoDB.Pagination
{
    public class PaginationScenario : IPaginationScenario<EmployeeSimple>
    {
        readonly string m_ConnectionString;

        public PaginationScenario(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        public void InsertBatch(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var repository = new EmployeeSimpleRepository(m_ConnectionString, ConnectionPersistency.Instance))
                repository.InsertAll(employees);
        }

        public IList<EmployeeSimple> PaginateWithPageSize(string lastName, int page, int pageSize)
        {
            var orderBy = OrderField.Parse(new
            {
                FirstName = Order.Ascending,
                EmployeeKey = Order.Ascending
            });

            using (var repository = new EmployeeSimpleRepository(m_ConnectionString, ConnectionPersistency.Instance))
                return repository.BatchQuery(page,
                    pageSize,
                    orderBy,
                    e => e.LastName == lastName).AsList();
        }

        public IList<EmployeeSimple> PaginateWithSkipPast(string lastName, EmployeeSimple? skipPast, int take)
        {
            var orderBy = OrderField.Parse(new
            {
                FirstName = Order.Ascending,
                EmployeeKey = Order.Ascending
            });
            var page = 0;

            using (var repository = new EmployeeSimpleRepository(m_ConnectionString, ConnectionPersistency.Instance))
                if (skipPast != null)
                {
                    var lastNameField = new QueryField("LastName", lastName);
                    var firstNameField = new QueryField("FirstName", Operation.GreaterThan, skipPast.FirstName);
                    var firstNameAndEmployeeKeyFields = new QueryGroup(new[]
                    {
                    new QueryField("FirstName", skipPast.FirstName),
                    new QueryField("EmployeeKey", Operation.GreaterThan, skipPast.EmployeeKey)
                });
                    var group = new QueryGroup(lastNameField,
                        new QueryGroup(firstNameField.AsEnumerable(),
                            firstNameAndEmployeeKeyFields.AsEnumerable(), Conjunction.Or));
                    return repository.BatchQuery(page,
                        take,
                        orderBy,
                        group).AsList();
                }
                else
                {
                    return repository.BatchQuery(page,
                        take,
                        orderBy,
                        e => e.LastName == lastName).AsList();
                }
        }

        public IList<EmployeeSimple> PaginateWithSkipTake(string lastName, int skip, int take)
        {
            using (var repository = new EmployeeSimpleRepository(m_ConnectionString, ConnectionPersistency.Instance))
            {
                var orderBy = OrderField.Parse(new
                {
                    FirstName = Order.Ascending,
                    EmployeeKey = Order.Ascending
                });
                var page = skip / take;

                return repository.BatchQuery(page,
                    take,
                    orderBy,
                    e => e.LastName == lastName).AsList();
            }
        }
    }
}