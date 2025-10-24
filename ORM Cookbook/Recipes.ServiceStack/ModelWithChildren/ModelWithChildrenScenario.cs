using Recipes.ModelWithChildren;
using Recipes.ServiceStack.Entities;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Recipes.ServiceStack.ModelWithChildren;

public class ModelWithChildrenScenario : IModelWithChildrenScenario<ProductLine, Product>
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public ModelWithChildrenScenario(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public int Create(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
            db.Save(productLine, true);

        return productLine.Id;
    }

    public void Delete(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            db.Delete<Product>(r => r.ProductLineId == productLine.Id);
            db.Delete(productLine);
        }
    }

    public void DeleteByKey(int productLineKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            db.Delete<Product>(r => r.ProductLineId == productLineKey);
            db.DeleteById<ProductLine>(productLineKey);
        }
    }

    public IList<ProductLine> FindByName(string productLineName, bool includeProducts)
    {
        if (string.IsNullOrWhiteSpace(productLineName))
            throw new ArgumentNullException(nameof(productLineName), $"{nameof(productLineName)} is null or empty.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return includeProducts
                ? db.LoadSelect<ProductLine>(e => e.ProductLineName == productLineName)
                : db.Select<ProductLine>(e => e.ProductLineName == productLineName);
        }
    }

    public IList<ProductLine> GetAll(bool includeProducts)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return includeProducts
                ? db.LoadSelect<ProductLine>()
                : db.Select<ProductLine>();
        }
    }

    public ProductLine? GetByKey(int productLineKey, bool includeProducts)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            var products = includeProducts
                ? db.LoadSingleById<ProductLine>(productLineKey)
                : db.SingleById<ProductLine>(productLineKey);
            return products;
        }
    }

    public void Update(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
            db.Update(productLine);
    }

    public void UpdateGraph(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
            db.Save(productLine, true);
    }

    public void UpdateGraphWithChildDeletes(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            db.Save(productLine, true);

            var productIdsToKeep = productLine.Products.Select(p => p.Id).ToList();

            db.Delete<Product>(p =>
                p.ProductLineId == productLine.Id && !Sql.In(p.Id, productIdsToKeep));
        }
    }

    public void UpdateGraphWithDeletes(ProductLine productLine, IList<int> productKeysToRemove)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            db.Save(productLine, true);

            db.Delete<Product>(p =>
                p.ProductLineId == productLine.Id && Sql.In(p.Id, productKeysToRemove));
        }
    }

    public void Update(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product), $"{nameof(product)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
            db.Update(product);
    }
}