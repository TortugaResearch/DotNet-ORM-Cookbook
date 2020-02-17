using System;
using System.Collections;
using System.Collections.Generic;
using LLBLGenPro.OrmCookbook.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Injectables
{
	/// <summary>
	/// Auditor class which is used for auditing on the DepartmentEntity.
	/// It's injected into the DepartmentEntity instances using the built-in
	/// DI feature of LLBLGen Pro.
	/// </summary>
	[DependencyInjectionInfo(typeof(DepartmentEntity), "AuditorToUse")]
	public class DepartmentAuditor : AuditorBase
	{
		private List<DepartmentEntity> _toUpdate;

		public DepartmentAuditor()
		{
			_toUpdate = new List<DepartmentEntity>();
		}


		public override void AuditInsertOfNewEntity(IEntityCore entity)
		{
			var auditedAsDepartment = entity as DepartmentEntity;
			if(auditedAsDepartment == null)
			{
				return;
			}

			var createdDate = DateTime.Now;
			auditedAsDepartment.CreatedDate = createdDate;
			auditedAsDepartment.ModifiedDate = createdDate;
			auditedAsDepartment.CreatedByEmployeeKey = ActiveEmployee;
			auditedAsDepartment.ModifiedByEmployeeKey = ActiveEmployee;
			_toUpdate.Add(auditedAsDepartment);
		}


		public override void AuditUpdateOfExistingEntity(IEntityCore entity)
		{
			var auditedAsDepartment = entity as DepartmentEntity;
			if(auditedAsDepartment == null)
			{
				return;
			}

			auditedAsDepartment.ModifiedDate = DateTime.Now;
			auditedAsDepartment.ModifiedByEmployeeKey = ActiveEmployee;
			// as we've modified the department entity we have to pass it back 
			// as an entity to the caller so it can be saved again. Typically
			// a separated audit entity should be created here but for the 
			// scenario here the information is updated inside the entity itself. 
			_toUpdate.Add(auditedAsDepartment);
		}


		public override bool RequiresTransactionForAuditEntities(SingleStatementQueryAction actionToStart)
		{
			// if we have entities of our own, we have to tell the caller that so it can create a transaction 
			return _toUpdate.Count > 0 && 
				   (actionToStart == SingleStatementQueryAction.ExistingEntityUpdate ||
					actionToStart == SingleStatementQueryAction.NewEntityInsert);
		}


		public override void TransactionCommitted()
		{
			_toUpdate.Clear();
		}


		public override IList GetAuditEntitiesToSave()
		{
			// if we've modified entities (or created entities of our own), we have to pass them back
			// so they can be included in the transaction. 
			return _toUpdate;
		}


		/// <summary>
		/// The pk of the employee entity to assign to any department audited by this auditor.
		/// </summary>
		public int ActiveEmployee { get; set; }
	}
}