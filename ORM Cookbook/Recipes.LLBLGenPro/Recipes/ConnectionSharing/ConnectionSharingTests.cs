using System.Data.Common;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ConnectionSharing;

namespace Recipes.LLBLGenPro.ConnectionSharing
{
	[TestClass]
	public class ConnectionSharingTests
		: ConnectionSharingTests<EmployeeClassificationEntity,
			SqlClientFactory, DbConnection, DbTransaction, DataAccessAdapter>
	{
		protected override SqlClientFactory CreateFactory()
		{
			return SqlClientFactory.Instance;
		}


		protected override IConnectionSharingScenario<EmployeeClassificationEntity, DbConnection, DbTransaction,
			DataAccessAdapter> GetScenario()
		{
			return new ConnectionSharingScenario();
		}
	}
}