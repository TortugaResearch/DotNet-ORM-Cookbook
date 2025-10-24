namespace Recipes.ModelWithChildren;

public interface IModelWithChildrenScenario<TProductLine, TProduct>
   where TProductLine : class, IProductLine<TProduct>, new()
   where TProduct : class, IProduct, new()
{
    /// <summary>
    /// Create a new ProductLine row, returning the new primary key.
    /// </summary>
    /// <remarks>This MUST save any attached Product records.</remarks>
    int Create(TProductLine productLine);

    /// <summary>
    /// Delete a ProductLine row using an object.
    /// </summary>
    /// <remarks>Behavior when row doesn't exist is not defined. This MUST delete any orphaned Product records.</remarks>
    void Delete(TProductLine productLine);

    /// <summary>
    /// Delete a ProductLine row using a key.
    /// </summary>
    /// <remarks>Behavior when row doesn't exist is not defined. This MUST delete any orphaned Product records.</remarks>
    void DeleteByKey(int productLineKey);

    /// <summary>
    /// Get a list of product lines by name.
    /// </summary>
    /// <param name="productLineName">Name of the product line. This is not unique.</param>
    /// <param name="includeProducts">if set to <c>true</c> include Product records.</param>
    IList<TProductLine> FindByName(string productLineName, bool includeProducts);

    /// <summary>
    /// Gets all product lines.
    /// </summary>
    IList<TProductLine> GetAll(bool includeProducts);

    /// <summary>
    /// Gets an TProductLine row by its primary key.
    /// </summary>
    /// <param name="employeeKey">The employee key.</param>
    /// <param name="includeChildern">if set to <c>true</c> include Product records.</param>
    TProductLine? GetByKey(int productLineKey, bool includeProducts);

    /// <summary>
    /// Update a ProductLine row only.
    /// </summary>
    /// <remarks>Behavior when row doesn't exist is not defined. This MUST not save any attached Product records.</remarks>
    void Update(TProductLine productLine);

    /// <summary>
    /// Update a ProductLine row and all of its children rows. If any product rows were removed from the Products collection, they should be ignored.
    /// </summary>
    /// <remarks>Behavior when row doesn't exist is not defined. This MUST save any attached Product records. It MUST NOT delete any Product records that were removed from the collection.</remarks>
    void UpdateGraph(TProductLine productLine);

    /// <summary>
    /// Update a ProductLine row and all of its children rows. If any product rows were removed from the Products collection, they should be deleted.
    /// </summary>
    /// <remarks>Behavior when row doesn't exist is not defined. This MUST save any attached Product records. It MUST delete any Product records that were removed from the collection.</remarks>
    void UpdateGraphWithChildDeletes(TProductLine productLine);

    /// <summary>
    /// Update a ProductLine row and all of its children rows. If any product rows were removed from the Products collection, they should be ignored. Delete any product rows in the productKeysToRemove list.
    /// </summary>
    /// <remarks>Behavior when row doesn't exist is not defined. Behavior when a row in productKeysToRemove wasn't part of the original ProductLine is not defined.</remarks>
    void UpdateGraphWithDeletes(TProductLine productLine, IList<int> productKeysToRemove);

    /// <summary>
    /// Update a Product row.
    /// </summary>
    /// <param name="product">The product.</param>
    /// <remarks>Behavior when row doesn't exist is not defined.</remarks>
    void Update(TProduct product);
}