///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 5.1
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace LLBLGenPro.OrmCookbook.HelperClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	/// <summary>Singleton implementation of the FieldInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the FieldInfoProviderBase class is threadsafe.</remarks>
	internal static class FieldInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IFieldInfoProvider _providerInstance = new FieldInfoProviderCore();
		#endregion

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static FieldInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the FieldInfoProviderCore</summary>
		/// <returns>Instance of the FieldInfoProvider.</returns>
		public static IFieldInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the FieldInfoProvider. Used by singleton wrapper.</summary>
	internal class FieldInfoProviderCore : FieldInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="FieldInfoProviderCore"/> class.</summary>
		internal FieldInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores.</summary>
		private void Init()
		{
			this.InitClass( (4 + 1));
			InitDepartmentEntityInfos();
			InitDivisionEntityInfos();
			InitEmployeeEntityInfos();
			InitEmployeeClassificationEntityInfos();
			InitDepartmentDetailTypedViewInfos();
			this.ConstructElementFieldStructures(InheritanceInfoProviderSingleton.GetInstance());
		}

		/// <summary>Inits DepartmentEntity's FieldInfo objects</summary>
		private void InitDepartmentEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(DepartmentFieldIndex), "DepartmentEntity");
			this.AddElementFieldInfo("DepartmentEntity", "DepartmentKey", typeof(System.Int32), true, false, true, false,  (int)DepartmentFieldIndex.DepartmentKey, 0, 0, 10);
			this.AddElementFieldInfo("DepartmentEntity", "DepartmentName", typeof(System.String), false, false, false, false,  (int)DepartmentFieldIndex.DepartmentName, 30, 0, 0);
			this.AddElementFieldInfo("DepartmentEntity", "DivisionKey", typeof(System.Int32), false, true, false, false,  (int)DepartmentFieldIndex.DivisionKey, 0, 0, 10);
		}
		/// <summary>Inits DivisionEntity's FieldInfo objects</summary>
		private void InitDivisionEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(DivisionFieldIndex), "DivisionEntity");
			this.AddElementFieldInfo("DivisionEntity", "DivisionKey", typeof(System.Int32), true, false, true, false,  (int)DivisionFieldIndex.DivisionKey, 0, 0, 10);
			this.AddElementFieldInfo("DivisionEntity", "DivisionName", typeof(System.String), false, false, false, false,  (int)DivisionFieldIndex.DivisionName, 30, 0, 0);
		}
		/// <summary>Inits EmployeeEntity's FieldInfo objects</summary>
		private void InitEmployeeEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(EmployeeFieldIndex), "EmployeeEntity");
			this.AddElementFieldInfo("EmployeeEntity", "CellPhone", typeof(System.String), false, false, false, true,  (int)EmployeeFieldIndex.CellPhone, 15, 0, 0);
			this.AddElementFieldInfo("EmployeeEntity", "EmployeeClassificationKey", typeof(Nullable<System.Int32>), false, true, false, true,  (int)EmployeeFieldIndex.EmployeeClassificationKey, 0, 0, 10);
			this.AddElementFieldInfo("EmployeeEntity", "EmployeeKey", typeof(System.Int32), true, false, true, false,  (int)EmployeeFieldIndex.EmployeeKey, 0, 0, 10);
			this.AddElementFieldInfo("EmployeeEntity", "FirstName", typeof(System.String), false, false, false, false,  (int)EmployeeFieldIndex.FirstName, 50, 0, 0);
			this.AddElementFieldInfo("EmployeeEntity", "LastName", typeof(System.String), false, false, false, false,  (int)EmployeeFieldIndex.LastName, 50, 0, 0);
			this.AddElementFieldInfo("EmployeeEntity", "MiddleName", typeof(System.String), false, false, false, true,  (int)EmployeeFieldIndex.MiddleName, 50, 0, 0);
			this.AddElementFieldInfo("EmployeeEntity", "OfficePhone", typeof(System.String), false, false, false, true,  (int)EmployeeFieldIndex.OfficePhone, 15, 0, 0);
			this.AddElementFieldInfo("EmployeeEntity", "Title", typeof(System.String), false, false, false, true,  (int)EmployeeFieldIndex.Title, 100, 0, 0);
		}
		/// <summary>Inits EmployeeClassificationEntity's FieldInfo objects</summary>
		private void InitEmployeeClassificationEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(EmployeeClassificationFieldIndex), "EmployeeClassificationEntity");
			this.AddElementFieldInfo("EmployeeClassificationEntity", "EmployeeClassificationKey", typeof(System.Int32), true, false, true, false,  (int)EmployeeClassificationFieldIndex.EmployeeClassificationKey, 0, 0, 10);
			this.AddElementFieldInfo("EmployeeClassificationEntity", "EmployeeClassificationName", typeof(System.String), false, false, false, true,  (int)EmployeeClassificationFieldIndex.EmployeeClassificationName, 30, 0, 0);
		}

		/// <summary>Inits View's FieldInfo objects</summary>
		private void InitDepartmentDetailTypedViewInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(DepartmentDetailFieldIndex), "DepartmentDetailTypedView");
			this.AddElementFieldInfo("DepartmentDetailTypedView", "DepartmentKey", typeof(System.Int32), false, false, true, false, (int)DepartmentDetailFieldIndex.DepartmentKey, 0, 0, 10);
			this.AddElementFieldInfo("DepartmentDetailTypedView", "DepartmentName", typeof(System.String), false, false, true, false, (int)DepartmentDetailFieldIndex.DepartmentName, 30, 0, 0);
			this.AddElementFieldInfo("DepartmentDetailTypedView", "DivisionKey", typeof(System.Int32), false, false, true, false, (int)DepartmentDetailFieldIndex.DivisionKey, 0, 0, 10);
			this.AddElementFieldInfo("DepartmentDetailTypedView", "DivisionName", typeof(System.String), false, false, true, false, (int)DepartmentDetailFieldIndex.DivisionName, 30, 0, 0);
		}		
	}
}




