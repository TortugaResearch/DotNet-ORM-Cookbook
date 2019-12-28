///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 5.1
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;

namespace LLBLGenPro.OrmCookbook.TypedViewClasses
{
	/// <summary>Class which represents a row in the typed view 'DepartmentDetail'.</summary>
	/// <remarks>This class is a result class for a query, which is produced with the method <see cref="LLBLGenPro.OrmCookbook.Linq.LinqMetaData.GetDepartmentDetailTypedView"/>.
	/// Custom Properties: <br/>
	/// </remarks>
	[Serializable]
	public partial class DepartmentDetailRow 
	{
		#region Extensibility Method Definitions
		partial void OnCreated();
		#endregion
		
		/// <summary>Initializes a new instance of the <see cref="DepartmentDetailRow"/> class.</summary>
		public DepartmentDetailRow()
		{
			OnCreated();
		}

		#region Class Property Declarations
		/// <summary>Gets or sets the DepartmentKey field.</summary>
		public System.Int32 DepartmentKey { get; set; }
		/// <summary>Gets or sets the DepartmentName field.</summary>
		public System.String DepartmentName { get; set; }
		/// <summary>Gets or sets the DivisionKey field.</summary>
		public System.Int32 DivisionKey { get; set; }
		/// <summary>Gets or sets the DivisionName field.</summary>
		public System.String DivisionName { get; set; }
		#endregion
	}
}

