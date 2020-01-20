using LinqToDB.Data;
using Recipes.BasicStoredProc;
using Recipes.LinqToDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.LinqToDB.BasicStoredProc
{
    public class BasicStoredProcScenario : IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount>
    {
        public IList<EmployeeClassificationWithCount> CountEmployeesByClassification()
        {
            using (var db = new OrmCookbook())
                return db.QueryProc<EmployeeClassificationWithCount>("HR.CountEmployeesByClassification").ToList();
            //.EmployeeClassificationWithCount.FromSqlRaw("EXEC HR.CountEmployeesByClassification;").ToList();
        }

        public int CreateEmployeeClassification(EmployeeClassification employeeClassification)
        {
            if (employeeClassification == null)
                throw new ArgumentNullException(nameof(employeeClassification), $"{nameof(employeeClassification)} is null.");

            //Notes:
            //LINQ to DB cannot return scalar values from stored procedures. A holder class is needed to receive the results.
            using (var db = new OrmCookbook())
                return db.QueryProc<EmployeeClassificationKeyHolder>("HR.HR.CreateEmployeeClassification",
                      new DataParameter("@EmployeeClassificationName", employeeClassification.EmployeeClassificationName),
                      new DataParameter("@IsExempt", employeeClassification.IsExempt),
                      new DataParameter("@IsEmployee", employeeClassification.IsEmployee)
                    ).Single().EmployeeClassificationKey;

            //Single isn't allowed for stored procedures. Thus ToList must be called first.
            //Named parameters are not supported, so parameter order is important.
        }

        public IList<EmployeeClassification> GetEmployeeClassifications()
        {
            using (var db = new OrmCookbook())
                return db.QueryProc<EmployeeClassification>("HR.GetEmployeeClassifications").ToList();
        }

        public EmployeeClassification? GetEmployeeClassifications(int employeeClassificationKey)
        {
            //Note that SingleOrDefault isn't allowed for stored procedures. Thus ToList must be called first.
            using (var db = new OrmCookbook())
            {
                return db.QueryProc<EmployeeClassification>("HR.GetEmployeeClassifications",
                    new DataParameter("@EmployeeClassificationKey", employeeClassificationKey)
                    ).SingleOrDefault();
            }
        }
    }
}
