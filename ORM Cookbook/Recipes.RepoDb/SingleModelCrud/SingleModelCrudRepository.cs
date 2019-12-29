using Recipes.SingleModelCrud;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Recipes.RepoDb.SingleModelCrud
{
    public class SingleModelCrudRepository : ISingleModelCrudRepository<EmployeeClassification>
    {
        readonly string m_ConnectionString;

        /// <summary>
        /// Opens a database connection.
        /// </summary>
        /// <remarks>Caller must dispose the connection.</remarks>
        SqlConnection OpenConnection()
        {
            var con = new SqlConnection(m_ConnectionString);
            con.Open();
            return con;
        }

        public SingleModelCrudRepository(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var con = OpenConnection())
                return con.Insert<EmployeeClassification, int>(classification);
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            using (var con = OpenConnection())
                con.Delete<EmployeeClassification>(employeeClassificationKey);
        }

        public void Delete(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var con = OpenConnection())
                con.Delete(classification);
        }

        public EmployeeClassification? FindByName(string employeeClassificationName)
        {
            using (var con = OpenConnection())
                return con.Query<EmployeeClassification>(new { EmployeeClassificationName = employeeClassificationName }).FirstOrDefault();
        }

        public IList<EmployeeClassification> GetAll()
        {
            using (var con = OpenConnection())
                return con.QueryAll<EmployeeClassification>().ToList();
        }

        public EmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            using (var con = OpenConnection())
                return con.Query<EmployeeClassification>(employeeClassificationKey).FirstOrDefault();
        }

        public void Update(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var con = OpenConnection())
                con.Update(classification);
        }
    }
}
