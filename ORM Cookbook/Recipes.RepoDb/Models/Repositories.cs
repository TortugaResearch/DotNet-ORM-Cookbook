using Microsoft.Data.SqlClient;
using Recipes.RepoDb.Models;
using RepoDb;
using RepoDb.Enumerations;

namespace Recipes.RepoDB.Models;

public class EmployeeSimpleRepository(string connectionString, ConnectionPersistency connectionPersistency) : BaseRepository<EmployeeSimple, SqlConnection>(connectionString, connectionPersistency) { }

public class ProductRepository(string connectionString, ConnectionPersistency connectionPersistency) : BaseRepository<Product, SqlConnection>(connectionString, connectionPersistency) { }

public class DivisionRepository(string connectionString, ConnectionPersistency connectionPersistency) : BaseRepository<Division, SqlConnection>(connectionString, connectionPersistency) { }

public class EmployeeClassificationRepository(string connectionString, ConnectionPersistency connectionPersistency) : BaseRepository<EmployeeClassification, SqlConnection>(connectionString, connectionPersistency) { }

public class EmployeeClassificationWithCountRepository(string connectionString, ConnectionPersistency connectionPersistency) : BaseRepository<EmployeeClassificationWithCount, SqlConnection>(connectionString, connectionPersistency) { }

public class EmployeeComplexRepository(string connectionString, ConnectionPersistency connectionPersistency) : BaseRepository<EmployeeComplex, SqlConnection>(connectionString, connectionPersistency) { }

public class ReadOnlyEmployeeClassificationRepository(string connectionString, ConnectionPersistency connectionPersistency) : BaseRepository<ReadOnlyEmployeeClassification, SqlConnection>(connectionString, connectionPersistency) { }

public class EmployeeDetailRepository(string connectionString, ConnectionPersistency connectionPersistency) : BaseRepository<EmployeeDetail, SqlConnection>(connectionString, connectionPersistency) { }

public class ProductLineRepository(string connectionString, ConnectionPersistency connectionPersistency) : BaseRepository<ProductLine, SqlConnection>(connectionString, connectionPersistency) { }