using Microsoft.Data.SqlClient;
using Recipes.ModelWithChildren;
using Recipes.PetaPoco.Models;

namespace Recipes.PetaPoco.ModelWithChildren;

public class ModelWithChildrenScenario : ScenarioBase, IModelWithChildrenScenario<ProductLine, Product>
{
    public ModelWithChildrenScenario(string connectionString) : base(connectionString)
    {
    }

    public int Create(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        throw new NotImplementedException();
    }

    public void Delete(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        throw new NotImplementedException();
    }

    public void DeleteByKey(int productLineKey)
    {
        throw new NotImplementedException();
    }

    public IList<ProductLine> FindByName(string productLineName, bool includeProducts)
    {
        throw new NotImplementedException();
    }

    public IList<ProductLine> GetAll(bool includeProducts)
    {
        throw new NotImplementedException();
    }

    public ProductLine? GetByKey(int productLineKey, bool includeProducts)
    {
        throw new NotImplementedException();
    }

    public void Update(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        throw new NotImplementedException();
    }

    public void Update(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product), $"{nameof(product)} is null.");

        throw new NotImplementedException();
    }

    public void UpdateGraph(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        throw new NotImplementedException();
    }

    public void UpdateGraphWithChildDeletes(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        throw new NotImplementedException();
    }

    public void UpdateGraphWithDeletes(ProductLine productLine, IList<int> productKeysToRemove)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        throw new NotImplementedException();
    }

    static void DeleteProduct(SqlConnection con, SqlTransaction trans, int productKey)
    {
        throw new NotImplementedException();
    }

    static HashSet<int> GetProductKeys(SqlConnection con, SqlTransaction trans, int productLineKey)
    {
        throw new NotImplementedException();
    }

    static void InsertProduct(SqlConnection con, SqlTransaction trans, Product product)
    {
        throw new NotImplementedException();
    }

    static void UpdateProduct(SqlConnection con, SqlTransaction? trans, Product product)
    {
        throw new NotImplementedException();
    }

    static void UpdateProductLine(SqlConnection con, SqlTransaction? trans, ProductLine productLine)
    {
        throw new NotImplementedException();
    }
}