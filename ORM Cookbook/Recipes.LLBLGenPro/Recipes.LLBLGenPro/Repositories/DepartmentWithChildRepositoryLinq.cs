using System.Collections.Generic;
using System.Linq;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Recipes.LLBLGenPro.Repositories
{
    /// <summary>
    /// Repository implementation which uses the Linq API for querying.
    /// </summary>
    internal class DepartmentWithChildRepositoryLinq : DepartmentWithChildRepositoryBase
    {
        public override IList<DepartmentEntity> GetAll()
        {
            using(var adapter = new DataAccessAdapter())
            {
                var metaData = new LinqMetaData(adapter);
                return metaData.Department.WithPath(a=>a.Prefetch(d=>d.Division)).ToList();
            }
        }

        public override IList<DivisionEntity> GetAllDivisions()
        {
            using(var adapter = new DataAccessAdapter())
            {
                var metaData = new LinqMetaData(adapter);
                return metaData.Division.ToList();
            }
        }

        public override DepartmentEntity GetByKey(int departmentKey)
        {
            using(var adapter = new DataAccessAdapter())
            {
                var metaData = new LinqMetaData(adapter);
                return metaData.Department.Where(d=>d.DepartmentKey==departmentKey).WithPath(a => a.Prefetch(d => d.Division)).SingleOrDefault();
            }
        }
    }
}

