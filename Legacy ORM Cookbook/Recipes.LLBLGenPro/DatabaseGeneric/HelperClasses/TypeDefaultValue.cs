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
	/// <summary>
	/// Class for the returning of a default value when a type is given. These
	/// Default values are used for EntityFields which have a NULL value in the database.
	/// In Business Logic it's impractical to work with NULL values. If you want different values
	/// as default values for NULL values for a given type, alter the DefaultValue method below.
	/// If you want to keep your values when regenerating the code, make this file read-only, or bind a different
	/// template to the template ID: SD_TypeDefaultValueIncludeTemplate, or alter the template file currently 
	/// bound to that template ID.
	/// </summary>
	[Serializable]
	public partial class TypeDefaultValue : ITypeDefaultValue
	{
		/// <summary>
		/// Ctor
		/// </summary>
		public TypeDefaultValue()
		{
		}


		/// <summary>
		/// Returns a default value for the type specified
		/// </summary>
		/// <param name="defaultValueType">The type which default value should be returned.</param>
		/// <returns>The default value for the type specified.</returns>
		public object DefaultValue(System.Type defaultValueType)
		{
			return TypeDefaultValue.GetDefaultValue(defaultValueType);
		}


		/// <summary>
		/// Returns a default value for the type specified
		/// </summary>
		/// <param name="defaultValueType">The type which default value should be returned.</param>
		/// <returns>The default value for the type specified.</returns>
		public static object GetDefaultValue(System.Type defaultValueType)
		{
			object valueToReturn=null;

			switch(Type.GetTypeCode(defaultValueType))
			{
				case TypeCode.String:
					valueToReturn=string.Empty;
					break;
				case TypeCode.Boolean:
					valueToReturn = false;
					break;
				case TypeCode.Byte:
					valueToReturn = (byte)0;
					break;
				case TypeCode.DateTime:
					valueToReturn = DateTime.MinValue;
					break;
				case TypeCode.Decimal:
					valueToReturn = 0.0M;
					break;
				case TypeCode.Double:
					valueToReturn = 0.0;
					break;
				case TypeCode.Int16:
					valueToReturn = (short)0;
					break;
				case TypeCode.Int32:
					valueToReturn = (int)0;
					break;
				case TypeCode.Int64:
					valueToReturn = (long)0;
					break;
				case TypeCode.Object:
					switch(defaultValueType.UnderlyingSystemType.FullName)
					{
						case "System.Guid":
							valueToReturn = Guid.Empty;
							break;
						case "System.Byte[]":
							valueToReturn = new byte[0];
							break;
						case "System.DateTimeOffset":
							valueToReturn = DateTimeOffset.MinValue;
							break;
						case "System.TimeSpan":
							valueToReturn = TimeSpan.MinValue;
							break;
					}
					break;					
				case TypeCode.Single:
					valueToReturn = 0.0f;
					break;
				case TypeCode.UInt16:
					valueToReturn = (ushort)0;
					break;
				case TypeCode.UInt32:
					valueToReturn = (uint)0;
					break;
				case TypeCode.UInt64:
					valueToReturn = (ulong)0;
					break;
				case TypeCode.SByte:
					valueToReturn = (SByte)0;
					break;
				default:
					// do nothing, return null.
					break;
			}
			return valueToReturn;

		}
		
		#region Included Code

		#endregion
	}
}

