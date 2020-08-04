using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using Microsoft.Extensions.Configuration;
using DevExpress.Xpo.DB;
using System.Data;
using System.Data.SqlClient;

namespace Recipes.Xpo.Entities
{

    public static class ConnectionHelper
    {
        static Type[] persistentTypes = new Type[] {
            typeof(Department),
            typeof(Division),
            typeof(Employee),
            typeof(EmployeeClassification),
            typeof(Product),
            typeof(ProductLine),
            typeof(EmployeeDetail)
        };
        public static Type[] GetPersistentTypes()
        {
            Type[] copy = new Type[persistentTypes.Length];
            Array.Copy(persistentTypes, copy, persistentTypes.Length);
            return copy;
        }
        static Type[] nonPersistentTypes = new Type[] {
            typeof(CountEmployeesByClassificationResult),
            typeof(CreateEmployeeClassificationResult),
            typeof(GetEmployeeClassificationsResult),
            typeof(DepartmentDetail)
        };
        public static Type[] GetNonPersistentTypes()
        {
            Type[] copy = new Type[nonPersistentTypes.Length];
            Array.Copy(nonPersistentTypes, copy, nonPersistentTypes.Length);
            return copy;
        }
        public const string ConnectionStringName = "SqlServerTestDatabase";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<Pending>")]
        public static void Connect(IConfiguration configuration, DevExpress.Xpo.DB.AutoCreateOption autoCreateOption, bool threadSafe = false)
        {
            if (threadSafe)
            {
                var provider = GetConnectionProvider(configuration, autoCreateOption);
                var dictionary = new DevExpress.Xpo.Metadata.ReflectionDictionary();
                dictionary.GetDataStoreSchema(persistentTypes);
                dictionary.CollectClassInfos(nonPersistentTypes);
                XpoDefault.DataLayer = new ThreadSafeDataLayer(dictionary, provider);
            } else
            {
                var provider = new OrmCookbookProvider(new SqlConnection(configuration.GetConnectionString(ConnectionStringName)), autoCreateOption);
                XpoDefault.DataLayer = new SimpleDataLayer(provider);
            }
        }
        public static DevExpress.Xpo.DB.IDataStore GetConnectionProvider(IConfiguration configuration, DevExpress.Xpo.DB.AutoCreateOption autoCreateOption)
        {
            return XpoDefault.GetConnectionProvider(configuration.GetConnectionString(ConnectionStringName), autoCreateOption);
        }
        public static DevExpress.Xpo.DB.IDataStore GetConnectionProvider(IConfiguration configuration, DevExpress.Xpo.DB.AutoCreateOption autoCreateOption, out IDisposable[] objectsToDisposeOnDisconnect)
        {
            return XpoDefault.GetConnectionProvider(configuration.GetConnectionString(ConnectionStringName), autoCreateOption, out objectsToDisposeOnDisconnect);
        }
        public static IDataLayer GetDataLayer(IConfiguration configuration, DevExpress.Xpo.DB.AutoCreateOption autoCreateOption)
        {
            return XpoDefault.GetDataLayer(configuration.GetConnectionString(ConnectionStringName), autoCreateOption);
        }
    }

    public class OrmCookbookProvider : MSSqlConnectionProvider
    {
        public OrmCookbookProvider(IDbConnection connection, AutoCreateOption autoCreateOption) : base(connection, autoCreateOption) { }

        protected override object ReformatReadValue(object value, ReformatReadValueArgs args)
        {
            // This implementation deactivates the default behavior of the base 
            // class logic, because the conversion step is not necessary for the type
            // DateTimeOffset, and because the attempt at conversion
            // results in exceptions since there is no automatic conversion mechanism.
            if (value != null)
            {
                Type valueType = value.GetType();
                if (valueType == typeof(DateTimeOffset))
                    return value;
                if (valueType == typeof(TimeSpan))
                    return value;
            }
            return base.ReformatReadValue(value, args);
        }
    }
    public class DateTimeOffsetConverter : ValueConverter
    {
        public override object ConvertFromStorageType(object value)
        {
            // We're ignoring the request to convert here, knowing that the loaded
            // object is already the correct type because SqlClient returns it 
            // that way.
            return value;
        }

        public override object ConvertToStorageType(object value)
        {
            if (value is DateTimeOffset)
            {
                var dto = (DateTimeOffset)value;
                return dto.ToString();
            } else
                return value;
        }

        public override Type StorageType
        {
            get { return typeof(string); }
        }
    }
    public class Time7Converter : ValueConverter
    {
        public override object ConvertFromStorageType(object value)
        {
            return value;
        }

        public override object ConvertToStorageType(object value)
        {
            if (value is TimeSpan)
            {
                var dto = (TimeSpan)value;
                return dto.ToString();
            } else
                return value;
        }

        public override Type StorageType
        {
            get { return typeof(string); }
        }
    }

}

