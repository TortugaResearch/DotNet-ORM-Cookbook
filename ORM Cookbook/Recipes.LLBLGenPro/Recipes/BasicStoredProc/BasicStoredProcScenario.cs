using Recipes.BasicStoredProc;
using System;
using System.Collections.Generic;
using System.Linq;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.FactoryClasses;
using LLBLGenPro.OrmCookbook.TypedViewClasses;

namespace Recipes.LLBLGenPro.BasicStoredProc
{
	public class BasicStoredProcScenario : IBasicStoredProcScenario<GetEmployeeClassificationsResultRow, CountEmployeesByClassificationResultRow>
	{
		public IList<CountEmployeesByClassificationResultRow> CountEmployeesByClassification()
		{
			// Use the generated calls to the procedure and pass in a generated projection to a poco to project the resultset
			// to a set of poco instances. The Fetch... method creates a new adapter instance. We could also pass one in.
			return RetrievalProcedures.FetchCountEmployeesByClassificationResultTypedView(
											new QueryFactory().GetCountEmployeesByClassificationResultTypedViewProjection());
		}


		public int CreateEmployeeClassification(GetEmployeeClassificationsResultRow employeeClassification)
		{
			if(employeeClassification == null)
				throw new ArgumentNullException(nameof(employeeClassification), $"{nameof(employeeClassification)} is null.");

			// The stored procedure in question returns the created PK value as a resultset and not as an output parameter. 
			// We therefore have to call the procedure as if it's returning a resultset. 
			var result = RetrievalProcedures.FetchCreateEmployeeClassificationResultTypedView(
													  new QueryFactory().GetCreateEmployeeClassificationResultTypedViewProjection(),
													  employeeClassification.EmployeeClassificationName, employeeClassification.IsExempt,
													  employeeClassification.IsEmployee)
											.FirstOrDefault();
			return result?.EmployeeClassificationKey ?? 0;
		}


		public IList<GetEmployeeClassificationsResultRow> GetEmployeeClassifications()
		{
			return RetrievalProcedures.FetchGetEmployeeClassificationsResultTypedView(
													new QueryFactory().GetGetEmployeeClassificationsResultTypedViewProjection(), 
													null);
		}


		public GetEmployeeClassificationsResultRow? GetEmployeeClassifications(int employeeClassificationKey)
		{
			return RetrievalProcedures.FetchGetEmployeeClassificationsResultTypedView(
													new QueryFactory().GetGetEmployeeClassificationsResultTypedViewProjection(), 
													employeeClassificationKey).FirstOrDefault();
		}
	}
}