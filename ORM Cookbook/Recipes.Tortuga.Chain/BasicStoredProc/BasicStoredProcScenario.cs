using Recipes.BasicStoredProc;
using Recipes.Chain.Models;
using System;
using System.Collections.Generic;
using Tortuga.Chain;

namespace Recipes.Chain.BasicStoredProc
{
    public class BasicStoredProcScenario :
        IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount>
    {
        readonly SqlServerDataSource m_DataSource;

        public BasicStoredProcScenario(SqlServerDataSource dataSource)
        {
            m_DataSource = dataSource;
        }

        public IList<EmployeeClassificationWithCount> CountEmployeesByClassification()
        {
            return m_DataSource.Procedure("HR.CountEmployeesByClassification")
                .ToCollection<EmployeeClassificationWithCount>().Execute();
        }

        public int CreateEmployeeClassification(EmployeeClassification employeeClassification)
        {
            if (employeeClassification == null)
                throw new ArgumentNullException(nameof(employeeClassification),
                    $"{nameof(employeeClassification)} is null.");

            //Chain will ask the database which parameters it needs from the object. Other properties on the object will
            //be ignored, so there's no need to manually map it to an anonymous type.

            return m_DataSource.Procedure("HR.CreateEmployeeClassification", employeeClassification).ToInt32().Execute();
        }

        public IList<EmployeeClassification> GetEmployeeClassifications()
        {
            return m_DataSource.Procedure("HR.GetEmployeeClassifications")
                .ToCollection<EmployeeClassification>().Execute();
        }

        public EmployeeClassification? GetEmployeeClassifications(int employeeClassificationKey)
        {
            return m_DataSource.Procedure("HR.GetEmployeeClassifications", new { employeeClassificationKey })
                .ToObjectOrNull<EmployeeClassification>().Execute();
        }
    }
}
