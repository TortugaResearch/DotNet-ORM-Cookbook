using Microsoft.Data.SqlClient;
using Recipes.TryCrud;
using System;
using System.Data;

namespace Recipes.Ado.TryCrud
{
    public class TryCrudRepository : ITryCrudRepository<EmployeeClassification>
    {
        readonly string m_ConnectionString;

        public TryCrudRepository(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName)
                        OUTPUT Inserted.EmployeeClassificationKey
                        VALUES(@EmployeeClassificationName )";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationName", classification.EmployeeClassificationName);
                return (int)cmd.ExecuteScalar();
            }
        }

        public void DeleteByKeyOrException(int employeeClassificationKey)
        {
            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationKey", employeeClassificationKey);
                var rowCount = cmd.ExecuteNonQuery();
                if (rowCount != 1)
                    throw new DataException($"No row was found for key {employeeClassificationKey}.");
            }
        }

        public bool DeleteByKeyWithStatus(int employeeClassificationKey)
        {
            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationKey", employeeClassificationKey);
                return 1 == cmd.ExecuteNonQuery();
            }
        }

        public void DeleteOrException(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationKey", classification.EmployeeClassificationKey);
                var rowCount = cmd.ExecuteNonQuery();
                if (rowCount != 1)
                    throw new DataException($"No row was found for key {classification.EmployeeClassificationKey}.");
            }
        }

        public bool DeleteWithStatus(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationKey", classification.EmployeeClassificationKey);
                return 1 == cmd.ExecuteNonQuery();
            }
        }

        public EmployeeClassification FindByNameOrException(string employeeClassificationName)
        {
            var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @EmployeeClassificationName;";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationName", employeeClassificationName);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        throw new DataException($"No row was found for '{employeeClassificationName}'.");

                    return new EmployeeClassification()
                    {
                        EmployeeClassificationKey = reader.GetInt32(reader.GetOrdinal("EmployeeClassificationKey")),
                        EmployeeClassificationName = reader.GetString(reader.GetOrdinal("EmployeeClassificationName"))
                    };
                }
            }
        }

        public EmployeeClassification? FindByNameOrNull(string employeeClassificationName)
        {
            var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @EmployeeClassificationName;";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationName", employeeClassificationName);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    return new EmployeeClassification()
                    {
                        EmployeeClassificationKey = reader.GetInt32(reader.GetOrdinal("EmployeeClassificationKey")),
                        EmployeeClassificationName = reader.GetString(reader.GetOrdinal("EmployeeClassificationName"))
                    };
                }
            }
        }

        public EmployeeClassification GetByKeyOrException(int employeeClassificationKey)
        {
            var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationKey", employeeClassificationKey);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        throw new DataException($"No row was found for key {employeeClassificationKey}.");

                    return new EmployeeClassification()
                    {
                        EmployeeClassificationKey = reader.GetInt32(reader.GetOrdinal("EmployeeClassificationKey")),
                        EmployeeClassificationName = reader.GetString(reader.GetOrdinal("EmployeeClassificationName"))
                    };
                }
            }
        }

        public EmployeeClassification? GetByKeyOrNull(int employeeClassificationKey)
        {
            var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationKey", employeeClassificationKey);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    return new EmployeeClassification()
                    {
                        EmployeeClassificationKey = reader.GetInt32(reader.GetOrdinal("EmployeeClassificationKey")),
                        EmployeeClassificationName = reader.GetString(reader.GetOrdinal("EmployeeClassificationName"))
                    };
                }
            }
        }

        public void UpdateOrException(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationKey", classification.EmployeeClassificationKey);
                cmd.Parameters.AddWithValue("@EmployeeClassificationName", classification.EmployeeClassificationName);
                var rowCount = cmd.ExecuteNonQuery();
                if (rowCount != 1)
                    throw new DataException($"No row was found for key {classification.EmployeeClassificationKey}.");
            }
        }

        public bool UpdateWithStatus(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationKey", classification.EmployeeClassificationKey);
                cmd.Parameters.AddWithValue("@EmployeeClassificationName", classification.EmployeeClassificationName);
                return 1 == cmd.ExecuteNonQuery();
            }
        }

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
    }
}
