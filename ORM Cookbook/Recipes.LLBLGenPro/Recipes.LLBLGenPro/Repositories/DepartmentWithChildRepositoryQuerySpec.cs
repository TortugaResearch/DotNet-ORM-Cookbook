using Recipes.Repositories;
using System.Collections.Generic;
using System.Linq;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.Adapter;
using LLBLGenPro.OrmCookbook.FactoryClasses;

namespace Recipes.LLBLGenPro.Repositories
{
    /// <summary>
    /// Repository implementation which uses the QuerySpec API for querying.
    /// </summary>
    internal class DepartmentWithChildRepositoryQuerySpec : DepartmentWithChildRepositoryBase
    {
        public override IList<DepartmentEntity> GetAll()
        {
            using(var adapter = new DataAccessAdapter())
            {
                var q = new QueryFactory().Department.WithPath(DepartmentEntity.PrefetchPathDivision);
                return (IList<DepartmentEntity>)adapter.FetchQuery(q);
            }
        }

        public override IList<DivisionEntity> GetAllDivisions()
        {
            using(var adapter = new DataAccessAdapter())
            {
                var q = new QueryFactory().Division;
                return (IList<DivisionEntity>)adapter.FetchQuery(q);
            }
        }

        public override DepartmentEntity GetByKey(int departmentKey)
        {
            using(var adapter = new DataAccessAdapter())
            {
                var q = new QueryFactory().Department
                                          .Where(DepartmentFields.DepartmentKey.Equal(departmentKey))
                                          .WithPath(DepartmentEntity.PrefetchPathDivision);
                return adapter.FetchSingle(q);
            }
        }
    }
}

