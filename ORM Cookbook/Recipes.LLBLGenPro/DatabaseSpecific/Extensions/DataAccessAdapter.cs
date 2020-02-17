using System.Data.Common;

namespace LLBLGenPro.OrmCookbook.DatabaseSpecific
{
	/// <summary>
	/// Extension of the generated adapter class which allows customization of the active connection / transaction.
	/// </summary>
	public partial class DataAccessAdapter
	{
		private DbConnection _connectionToUse;
		private DbTransaction _transactionToUse;
		
		public void SetConnectionTransaction(DbConnection connectionToUse, DbTransaction transactionToUse=null)
		{
			_connectionToUse = connectionToUse;
			_transactionToUse = transactionToUse;
		}


		protected override void Dispose(bool isDisposing)
		{
			if(_connectionToUse != null || _transactionToUse != null)
			{
				// don't dispose, leave them alive
				return;
			}
			base.Dispose(isDisposing);
		}


		protected override DbConnection CreateNewPhysicalConnection(string connectionString)
		{
			return _connectionToUse ?? base.CreateNewPhysicalConnection(connectionString);
		}


		protected override DbTransaction CreateNewPhysicalTransaction()
		{
			return _transactionToUse ?? base.CreateNewPhysicalTransaction();
		}


		public DbConnection GetConnection()
		{
			return GetActiveConnection();
		}

		
		public DbTransaction GetTransaction()
		{
			return this.PhysicalTransaction;
		}
	}
}