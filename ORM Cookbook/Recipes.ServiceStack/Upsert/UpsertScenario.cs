using System;
using System.Collections.Generic;
using System.Text;
using Recipes.ServiceStack.Entities;
using Recipes.Upsert;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Recipes.ServiceStack.Upsert
{
    class UpsertScenario : IUpsertScenario<Division>
    {
        private IDbConnectionFactory _dbConnectionFactory;

        public UpsertScenario(IDbConnectionFactory dbConnectionFactory)
        {
            this._dbConnectionFactory = dbConnectionFactory;
        }

        public Division GetByKey(int divisionKey)
        {
            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                return db.SingleById<Division>(divisionKey);
            }
        }

        public int UpsertByName(Division division)
        {
            if (division.CreatedDate == default(DateTime))
                division.CreatedDate = DateTime.UtcNow;
            division.ModifiedDate = DateTime.UtcNow;
            
            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                var existing = db.Single<Division>(c => c.DivisionName == division.DivisionName);
                if (existing != null)
                {
                    division.PopulateWith(existing.PopulateWithNonDefaultValues(division));
                }
                db.Save(division);
            }
            
            return division.Id;
        }

        public int UpsertByPrimaryKey(Division division)
        {
            if (division.CreatedDate == default(DateTime))
                division.CreatedDate = DateTime.UtcNow;
            division.ModifiedDate = DateTime.UtcNow;
            
            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                db.Save(division);
            }

            return division.Id;
        }
    }
}
