using Microsoft.Data.SqlClient;
using Recipes.RepoDb.Models;
using Recipes.Upsert;
using RDB = RepoDb;
using RepoDb;
using System;
using System.Linq;

namespace Recipes.RepoDb.Upsert
{
    public class UpsertScenario : BaseRepository<Division, SqlConnection>,
        IUpsertScenario<Division>
    {
        public UpsertScenario(string connectionString)
            : base(connectionString, RDB.Enumerations.ConnectionPersistency.Instance)
        { }

        public Division GetByKey(int divisionKey)
        {
            return Query(e => e.DivisionKey == divisionKey).FirstOrDefault();
        }

        public int UpsertByName(Division division)
        {
            if (division == null)
                throw new ArgumentNullException(nameof(division), $"{nameof(division)} is null.");

            return (int)Merge(division, Field.From("DivisionName"));
        }

        public int UpsertByPrimaryKey(Division division)
        {
            if (division == null)
                throw new ArgumentNullException(nameof(division), $"{nameof(division)} is null.");

            return (int)Merge(division, Field.From("DivisionKey"));
        }
    }
}
