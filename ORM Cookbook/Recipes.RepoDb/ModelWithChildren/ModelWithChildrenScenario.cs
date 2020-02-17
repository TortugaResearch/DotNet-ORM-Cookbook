using Microsoft.Data.SqlClient;
using Recipes.ModelWithChildren;
using Recipes.RepoDb.Models;
using RDB = RepoDb;
using RepoDb;
using RepoDb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.RepoDb.ModelWithChildren
{
    public class ModelWithChildrenScenario : DbRepository<SqlConnection>,
        IModelWithChildrenScenario<ProductLine, Product>
    {
        public ModelWithChildrenScenario(string connectionString)
            : base(connectionString, RDB.Enumerations.ConnectionPersistency.Instance)
        { }

        public int Create(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            var key = Insert<ProductLine, int>(productLine);
            productLine.ApplyKeys();
            InsertAll(productLine.Products);
            return key;
        }

        private void ExecuteDelete(int productLineKey)
        {
            var sql = @"DELETE FROM Production.Product WHERE ProductLineKey = @ProductLineKey;
                DELETE FROM Production.ProductLine WHERE ProductLineKey = @ProductLineKey;";

            using (var con = CreateConnection(true))
            {
                con.ExecuteNonQuery(sql, new { productLineKey });
            }
        }

        public void Delete(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            //base.Delete(productLine);
            ExecuteDelete(productLine.ProductLineKey);
        }

        public void DeleteByKey(int productLineKey)
        {
            //base.Delete<ProductLine>(productLineKey);
            ExecuteDelete(productLineKey);
        }

        private void FetchProducts(IEnumerable<ProductLine> productLines)
        {
            var keys = productLines.Select(e => e.ProductLineKey).AsList();
            Query<Product>(e => keys.Contains(e.ProductLineKey))
                .AsList()
                .ForEach(p =>
                    productLines.First(e => e.ProductLineKey == p.ProductLineKey).Products.Add(p));
        }

        public IList<ProductLine> FindByName(string productLineName, bool includeProducts)
        {
            var lines = Query<ProductLine>(e => e.ProductLineName == productLineName);
            if (includeProducts)
                FetchProducts(lines);
            return lines.AsList();
        }

        public IList<ProductLine> GetAll(bool includeProducts)
        {
            var lines = QueryAll<ProductLine>();
            if (includeProducts)
                FetchProducts(lines);
            return lines.AsList();
        }

        public ProductLine? GetByKey(int productLineKey, bool includeProducts)
        {
            var line = Query<ProductLine>(productLineKey).FirstOrDefault();
            if (includeProducts && null != line)
                line.Products.AddRange(
                    Query<Product>(e => e.ProductLineKey == line.ProductLineKey));
            return line;
        }

        public void Update(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            base.Update(productLine);
        }

        public void Update(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), $"{nameof(product)} is null.");

            base.Update(product);
        }

        public void UpdateGraph(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            productLine.ApplyKeys();

            Update(productLine);
            MergeAll(productLine.Products);
        }

        public void UpdateGraphWithChildDeletes(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            productLine.ApplyKeys();

            var products = Query<Product>(p => p.ProductLineKey == productLine.ProductLineKey);
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

        public void UpdateGraphWithDeletes(ProductLine productLine, IList<int> productKeysToRemove)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            productLine.ApplyKeys();

            Update(productLine);

            if (productKeysToRemove?.Any() == true)
                Delete<Product>(e => productKeysToRemove.Contains(e.ProductKey));

            if (productLine.Products?.Any() == true)
                MergeAll<Product>(productLine.Products);
        }
    }
}
