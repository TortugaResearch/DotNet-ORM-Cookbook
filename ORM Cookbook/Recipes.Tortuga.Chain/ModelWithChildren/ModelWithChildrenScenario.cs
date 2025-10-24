using Recipes.Chain.Models;
using Recipes.ModelWithChildren;
using Tortuga.Chain;

namespace Recipes.Chain.ModelWithChildren;

public class ModelWithChildrenScenario : IModelWithChildrenScenario<ProductLine, Product>
{
    readonly SqlServerDataSource m_DataSource;

    public ModelWithChildrenScenario(SqlServerDataSource dataSource)
    {
        m_DataSource = dataSource;
    }

    public int Create(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        using (var trans = m_DataSource.BeginTransaction())
        {
            productLine.ProductLineKey = trans.Insert(productLine).ToInt32().Execute();
            productLine.ApplyKeys();
            trans.InsertBatch(productLine.Products).Execute();
            trans.Commit();
        }

        return productLine.ProductLineKey;
    }

    public void Delete(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        using (var trans = m_DataSource.BeginTransaction())
        {
            trans.DeleteSet<Product>(new { productLine.ProductLineKey }).Execute();
            trans.Delete(productLine).Execute();
            trans.Commit();
        }
    }

    public void DeleteByKey(int productLineKey)
    {
        using (var trans = m_DataSource.BeginTransaction())
        {
            trans.DeleteSet<Product>(new { productLineKey }).Execute();
            trans.DeleteByKey<ProductLine>(productLineKey).Execute();
            trans.Commit();
        }
    }

    public IList<ProductLine> FindByName(string productLineName, bool includeProducts)
    {
        var results = m_DataSource.From<ProductLine>(new { productLineName }).ToCollection().Execute();
        if (results.Count > 0 && includeProducts)
        {
            var children = m_DataSource.GetByColumnList<Product>("ProductLineKey",
                results.Select(pl => pl.ProductLineKey)).ToCollection().Execute();
            foreach (var line in results)
                line.Products.AddRange(children.Where(x => x.ProductLineKey == line.ProductLineKey));
        }
        return results;
    }

    public IList<ProductLine> GetAll(bool includeProducts)
    {
        var results = m_DataSource.From<ProductLine>().ToCollection().Execute();
        if (includeProducts)
        {
            var children = m_DataSource.From<Product>().ToCollection().Execute();
            foreach (var line in results)
                line.Products.AddRange(children.Where(x => x.ProductLineKey == line.ProductLineKey));
        }
        return results;
    }

    public ProductLine? GetByKey(int productLineKey, bool includeProducts)
    {
        var result = m_DataSource.GetByKey<ProductLine>(productLineKey).ToObjectOrNull().Execute();
        if (result != null && includeProducts)
        {
            var children = m_DataSource.From<Product>(new { result.ProductLineKey }).ToCollection().Execute();
            result.Products.AddRange(children);
        }
        return result;
    }

    public void Update(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product), $"{nameof(product)} is null.");

        m_DataSource.Update(product).Execute();
    }

    public void Update(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        m_DataSource.Update(productLine).Execute();
    }

    public void UpdateGraph(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        using (var trans = m_DataSource.BeginTransaction())
        {
            //Update parent row
            trans.Update(productLine).Execute();

            //Ensure new child rows have their parent's key
            productLine.ApplyKeys();

            //Insert/update the remaining child rows
            foreach (var row in productLine.Products)
                trans.Upsert(row).Execute();

            trans.Commit();
        }
    }

    public void UpdateGraphWithChildDeletes(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        using (var trans = m_DataSource.BeginTransaction())
        {
            //Update parent row
            trans.Update(productLine).Execute();

            //Find the list of child keys to remove
            var oldKeys = trans.From<Product>(new { productLine.ProductLineKey }).ToInt32List("ProductKey")
                .Execute().ToHashSet();

            foreach (var key in productLine.Products.Select(x => x.ProductKey))
                oldKeys.Remove(key);

            //Remove the old records
            foreach (var key in oldKeys)
                trans.DeleteByKey<Product>(key).Execute();

            //Ensure new child rows have their parent's key
            productLine.ApplyKeys();

            //Insert/update the child rows
            foreach (var row in productLine.Products)
                trans.Upsert(row).Execute();

            trans.Commit();
        }
    }

    public void UpdateGraphWithDeletes(ProductLine productLine, IList<int> productKeysToRemove)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        using (var trans = m_DataSource.BeginTransaction())
        {
            //Update parent row
            trans.Update(productLine).Execute();

            //Ensure new child rows have their parent's key
            productLine.ApplyKeys();

            //Insert/update the child rows
            foreach (var row in productLine.Products)
                trans.Upsert(row).Execute();

            if (productKeysToRemove?.Count > 0)
                trans.DeleteByKeyList<Product>(productKeysToRemove).Execute();

            trans.Commit();
        }
    }
}