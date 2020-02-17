using Microsoft.Data.SqlClient;
using Recipes.RepoDb.Models;
using Recipes.Pagination;
using RDB = RepoDb;
using RepoDb;
using RepoDb.Enumerations;
using RepoDb.Extensions;
using System;
using System.Collections.Generic;

namespace Recipes.RepoDb.Pagination
{
    public class PaginationScenario : BaseRepository<EmployeeSimple, SqlConnection>,
        IPaginationScenario<EmployeeSimple>
    {
        public PaginationScenario(string connectionString)
            : base(connectionString, RDB.Enumerations.ConnectionPersistency.Instance)
        { }

        public void InsertBatch(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            InsertAll(employees);
        }

        public IList<EmployeeSimple> PaginateWithPageSize(string lastName, int page, int pageSize)
        {
            var orderBy = OrderField.Parse(new
            {
                FirstName = Order.Ascending,
                EmployeeKey = Order.Ascending
            });

            return BatchQuery(page,
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
                return BatchQuery(page,
                    take,
                    orderBy,
                    group).AsList();
            }
            else
            {
                return BatchQuery(page,
                    take,
                    orderBy,
                    e => e.LastName == lastName).AsList();
            }
        }

        public IList<EmployeeSimple> PaginateWithSkipTake(string lastName, int skip, int take)
        {
            var orderBy = OrderField.Parse(new
            {
                FirstName = Order.Ascending,
                EmployeeKey = Order.Ascending
            });
            var page = skip / take;

            return BatchQuery(page,
                take,
                orderBy,
                e => e.LastName == lastName).AsList();
        }
    }
}
