using Microsoft.Data.SqlClient;
using Recipes.ConnectionSharing;
using System;
using System.Data;
using System.Data.Common;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;

namespace Recipes.LLBLGenPro.ConnectionSharing
{
	public class ConnectionSharingScenario
		: IConnectionSharingScenario<EmployeeClassificationEntity,
			DbConnection, DbTransaction, DataAccessAdapter>
	{
		public void CloseConnection(DataAccessAdapter adapter)
		{
			if(adapter == null)
				throw new ArgumentNullException(nameof(adapter), $"{nameof(adapter)} is null.");

			adapter.CloseConnection();
			adapter.Dispose();
		}


		public void CloseConnectionAndTransaction(DataAccessAdapter adapter)
		{
			if(adapter == null)
				throw new ArgumentNullException(nameof(adapter), $"{nameof(adapter)} is null.");

			adapter.Commit();
			adapter.Dispose();
		}


		public string GetConnectionString()
		{
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.ConnectionString;
			}
		}


		public ConnectionResult<DbConnection, DataAccessAdapter> OpenConnection()
		{
			var adapter = new DataAccessAdapter();
			adapter.OpenConnection();
			var connection = adapter.GetConnection();
			adapter.KeepConnectionOpen = true;
			return (connection, adapter);
		}


		public ConnectionTransactionResult<DbConnection, DbTransaction, DataAccessAdapter>
			OpenConnectionAndTransaction()
		{
			var adapter = new DataAccessAdapter();
			adapter.OpenConnection();
			adapter.StartTransaction(IsolationLevel.ReadCommitted, "OpenConTrans");
			adapter.KeepConnectionOpen = true;
			return (adapter.GetConnection(), adapter.GetTransaction(), adapter);
		}


		public EmployeeClassificationEntity UseOpenConnection(DbConnection connection, DbTransaction? transaction,
															  int employeeClassificationKey)
		{
			using(var adapter = new DataAccessAdapter())
			{
				adapter.SetConnectionTransaction(connection, transaction);
				adapter.StartTransaction(IsolationLevel.ReadCommitted, "OpenConnection");
				adapter.KeepConnectionOpen = true;
				return adapter.FetchNewEntity<EmployeeClassificationEntity>(
									new RelationPredicateBucket(EmployeeClassificationFields.EmployeeClassificationKey
												.Equal(employeeClassificationKey)));
			}
		}
	}
}