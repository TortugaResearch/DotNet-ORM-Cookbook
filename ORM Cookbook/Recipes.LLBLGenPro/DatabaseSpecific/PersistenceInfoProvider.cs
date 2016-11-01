///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 5.1
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Data;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace LLBLGenPro.OrmCookbook.DatabaseSpecific
{
	/// <summary>Singleton implementation of the PersistenceInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the PersistenceInfoProviderBase class is threadsafe.</remarks>
	internal static class PersistenceInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IPersistenceInfoProvider _providerInstance = new PersistenceInfoProviderCore();
		#endregion

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static PersistenceInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the PersistenceInfoProviderCore</summary>
		/// <returns>Instance of the PersistenceInfoProvider.</returns>
		public static IPersistenceInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the PersistenceInfoProvider. Used by singleton wrapper.</summary>
	internal class PersistenceInfoProviderCore : PersistenceInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="PersistenceInfoProviderCore"/> class.</summary>
		internal PersistenceInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores with the structure of hierarchical types.</summary>
		private void Init()
		{
			this.InitClass(5);
			InitDepartmentEntityMappings();
			InitDivisionEntityMappings();
			InitEmployeeEntityMappings();
			InitEmployeeClassificationEntityMappings();
			InitDepartmentDetailTypedViewMappings();
		}

		/// <summary>Inits DepartmentEntity's mappings</summary>
		private void InitDepartmentEntityMappings()
		{
			this.AddElementMapping("DepartmentEntity", @"OrmCookbook", @"HR", "Department", 3, 0);
			this.AddElementFieldMapping("DepartmentEntity", "DepartmentKey", "DepartmentKey", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("DepartmentEntity", "DepartmentName", "DepartmentName", false, "NVarChar", 30, 0, 0, false, "", null, typeof(System.String), 1);
			this.AddElementFieldMapping("DepartmentEntity", "DivisionKey", "DivisionKey", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 2);
		}

		/// <summary>Inits DivisionEntity's mappings</summary>
		private void InitDivisionEntityMappings()
		{
			this.AddElementMapping("DivisionEntity", @"OrmCookbook", @"HR", "Division", 2, 0);
			this.AddElementFieldMapping("DivisionEntity", "DivisionKey", "DivisionKey", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("DivisionEntity", "DivisionName", "DivisionName", false, "NVarChar", 30, 0, 0, false, "", null, typeof(System.String), 1);
		}

		/// <summary>Inits EmployeeEntity's mappings</summary>
		private void InitEmployeeEntityMappings()
		{
			this.AddElementMapping("EmployeeEntity", @"OrmCookbook", @"HR", "Employee", 8, 0);
			this.AddElementFieldMapping("EmployeeEntity", "CellPhone", "CellPhone", true, "VarChar", 15, 0, 0, false, "", null, typeof(System.String), 0);
			this.AddElementFieldMapping("EmployeeEntity", "EmployeeClassificationKey", "EmployeeClassificationKey", true, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
			this.AddElementFieldMapping("EmployeeEntity", "EmployeeKey", "EmployeeKey", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 2);
			this.AddElementFieldMapping("EmployeeEntity", "FirstName", "FirstName", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 3);
			this.AddElementFieldMapping("EmployeeEntity", "LastName", "LastName", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 4);
			this.AddElementFieldMapping("EmployeeEntity", "MiddleName", "MiddleName", true, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 5);
			this.AddElementFieldMapping("EmployeeEntity", "OfficePhone", "OfficePhone", true, "VarChar", 15, 0, 0, false, "", null, typeof(System.String), 6);
			this.AddElementFieldMapping("EmployeeEntity", "Title", "Title", true, "NVarChar", 100, 0, 0, false, "", null, typeof(System.String), 7);
		}

		/// <summary>Inits EmployeeClassificationEntity's mappings</summary>
		private void InitEmployeeClassificationEntityMappings()
		{
			this.AddElementMapping("EmployeeClassificationEntity", @"OrmCookbook", @"HR", "EmployeeClassification", 2, 0);
			this.AddElementFieldMapping("EmployeeClassificationEntity", "EmployeeClassificationKey", "EmployeeClassificationKey", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("EmployeeClassificationEntity", "EmployeeClassificationName", "EmployeeClassificationName", true, "VarChar", 30, 0, 0, false, "", null, typeof(System.String), 1);
		}


		/// <summary>Inits DepartmentDetailView's mappings</summary>
		private void InitDepartmentDetailTypedViewMappings()
		{
			this.AddElementMapping("DepartmentDetailTypedView", @"OrmCookbook", @"HR", "DepartmentDetail", 4);
			this.AddElementFieldMapping("DepartmentDetailTypedView", "DepartmentKey", "DepartmentKey", false, "Int", 0, 10, 0, false, string.Empty, null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("DepartmentDetailTypedView", "DepartmentName", "DepartmentName", false, "NVarChar", 30, 0, 0, false, string.Empty, null, typeof(System.String), 1);
			this.AddElementFieldMapping("DepartmentDetailTypedView", "DivisionKey", "DivisionKey", false, "Int", 0, 10, 0, false, string.Empty, null, typeof(System.Int32), 2);
			this.AddElementFieldMapping("DepartmentDetailTypedView", "DivisionName", "DivisionName", false, "NVarChar", 30, 0, 0, false, string.Empty, null, typeof(System.String), 3);
		}

	}
}
