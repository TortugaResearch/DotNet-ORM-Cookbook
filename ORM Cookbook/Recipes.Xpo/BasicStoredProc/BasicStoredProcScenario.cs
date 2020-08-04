using DevExpress.Xpo;
using Recipes.BasicStoredProc;
using Recipes.Xpo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Xpo.BasicStoredProc
{
    public class BasicStoredProcScenario :
        IBasicStoredProcScenario<GetEmployeeClassificationsResult, CountEmployeesByClassificationResult>
    {

        public IList<CountEmployeesByClassificationResult> CountEmployeesByClassification()
        {
            return SprocHelper.ExecHR_CountEmployeesByClassificationIntoObjects(Session.DefaultSession).ToList();
        }

        public int CreateEmployeeClassification(GetEmployeeClassificationsResult employeeClassification)
        {
            if (employeeClassification == null)
                throw new ArgumentNullException(nameof(employeeClassification),
                    $"{nameof(employeeClassification)} is null.");

            using (var uow = new UnitOfWork())
            {
                var temp = SprocHelper.ExecHR_CreateEmployeeClassificationIntoObjects(
                        uow,
                        employeeClassification.EmployeeClassificationName,
                        employeeClassification.IsExempt,
                        employeeClassification.IsEmployee
                    );
                return temp.Single().EmployeeClassificationKey;
            }
        }

        public IList<GetEmployeeClassificationsResult> GetEmployeeClassifications()
        {
            return SprocHelper.ExecHR_GetEmployeeClassificationsIntoObjects(Session.DefaultSession, null).ToList();
        }

        public GetEmployeeClassificationsResult? GetEmployeeClassifications(int employeeClassificationKey)
        {
            return SprocHelper.ExecHR_GetEmployeeClassificationsIntoObjects(Session.DefaultSession, employeeClassificationKey).SingleOrDefault();
        }

    }
}
