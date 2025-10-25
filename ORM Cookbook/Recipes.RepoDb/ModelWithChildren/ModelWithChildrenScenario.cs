using Microsoft.Data.SqlClient;
using Recipes.ModelWithChildren;
using Recipes.RepoDB.Models;
using RepoDb;
using RepoDb.Extensions;
using RepoDb.Enumerations;

namespace Recipes.RepoDB.ModelWithChildren;

public class ModelWithChildrenScenario : IModelWithChildrenScenario<ProductLine, Product>
{
    readonly string m_ConnectionString;

    public ModelWithChildrenScenario(string connectionString)
    {
        m_ConnectionString = connectionString;
    }

    public int Create(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        {
            var key = repository.Insert<ProductLine, int>(productLine);
            productLine.ApplyKeys();
            repository.InsertAll(productLine.Products);
            return key;
        }
    }

    private void ExecuteDelete(int productLineKey)
    {
        var sql = @"DELETE FROM Production.Product WHERE ProductLineKey = @ProductLineKey;
                DELETE FROM Production.ProductLine WHERE ProductLineKey = @ProductLineKey;";

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
            repository.ExecuteNonQuery(sql, new { productLineKey });
    }

    public void Delete(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        ExecuteDelete(productLine.ProductLineKey);
    }

    public void DeleteByKey(int productLineKey)
    {
        ExecuteDelete(productLineKey);
    }

    private void FetchProducts(IEnumerable<ProductLine> productLines)
    {
        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        {
            var keys = productLines.Select(e => e.ProductLineKey).AsList();
            repository.Query<Product>(e => keys.Contains(e.ProductLineKey))
                .AsList()
                .ForEach(p =>
                    productLines.First(e => e.ProductLineKey == p.ProductLineKey).Products.Add(p));
        }
    }

    public IList<ProductLine> FindByName(string productLineName, bool includeProducts)
    {
        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        {
            var lines = repository.Query<ProductLine>(e => e.ProductLineName == productLineName);
            if (includeProducts)
                FetchProducts(lines);
            return lines.AsList();
        }
    }

    public IList<ProductLine> GetAll(bool includeProducts)
    {
        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        {
            var lines = repository.QueryAll<ProductLine>();
            if (includeProducts)
                FetchProducts(lines);
            return lines.AsList();
        }
    }

    public ProductLine? GetByKey(int productLineKey, bool includeProducts)
    {
        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        {
            var line = repository.Query<ProductLine>(productLineKey).FirstOrDefault();
            if (includeProducts && null != line)
                line.Products.AddRange(
                    repository.Query<Product>(e => e.ProductLineKey == line.ProductLineKey));
            return line;
        }
    }

    public void Update(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
            repository.Update(productLine);
    }

    public void Update(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product), $"{nameof(product)} is null.");

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
            repository.Update(product);
    }

    public void UpdateGraph(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        {
            productLine.ApplyKeys();

            repository.Update(productLine);
            repository.MergeAll(productLine.Products);
        }
    }

    public void UpdateGraphWithChildDeletes(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        {
            productLine.ApplyKeys();

            var products = repository.Query<Product>(p => p.ProductLineKey == productLine.ProductLineKey);
            var originalProductKeys = products
                .Select(p => p.ProductKey);
            var currentProductKeys = productLine
                .Products
                .Select(e => e.ProductKey);
            var productKeysToRemove = originalProductKeys
                .Except(currentProductKeys)
                .AsList();

            UpdateGraphWithDeletes(productLine, productKeysToRemove);
        }
    }

    public void UpdateGraphWithDeletes(ProductLine productLine, IList<int> productKeysToRemove)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        {
            productLine.ApplyKeys();

            repository.Update(productLine);

            if (productKeysToRemove?.Any() == true)
                repository.Delete<Product>(e => productKeysToRemove.Contains(e.ProductKey));

            if (productLine.Products?.Any() == true)
                repository.MergeAll(productLine.Products);
        }
    }
}