using DbConnector.Core;
using Microsoft.Data.SqlClient;
using Recipes.DbConnector.Models;
using Recipes.ModelWithChildren;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace Recipes.DbConnector.ModelWithChildren
{
    public class ModelWithChildrenScenario : ScenarioBase, IModelWithChildrenScenario<ProductLine, Product>
    {
        public ModelWithChildrenScenario(string connectionString) : base(connectionString)
        {
        }

        public int Create(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            const string sql = "INSERT INTO Production.ProductLine ( ProductLineName ) OUTPUT Inserted.ProductLineKey VALUES (@ProductLineName);";

            IDbJob<int> jobProductLine = DbConnector
                .Scalar<int>(sql, productLine)
                .OnExecuted((int result, IDbExecutedModel im) =>
                {
                    productLine.ProductLineKey = result;
                    productLine.ApplyKeys();
                    return result;
                });

            if (productLine.Products.Count == 0)
            {
                return jobProductLine.Execute();
            }
            else
            {
                //Leverage DbConnector's Job Batching feature
                List<IDbJob<int>> jobs = new List<IDbJob<int>>
                {
                    jobProductLine
                };

                foreach (var item in productLine.Products)
                    jobs.Add(BuildInsertProduct(item));

                DbJob.ExecuteAll(jobs);//Execute all jobs

                return productLine.ProductLineKey;
            }
        }

        public void Delete(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            const string sql = @"DELETE FROM Production.Product WHERE ProductLineKey = @ProductLineKey;
            DELETE FROM Production.ProductLine WHERE ProductLineKey = @ProductLineKey";

            DbConnector.NonQuery(sql, productLine).Execute();
        }

        public void DeleteByKey(int productLineKey)
        {
            const string sql = @"DELETE FROM Production.Product WHERE ProductLineKey = @ProductLineKey;
            DELETE FROM Production.ProductLine WHERE ProductLineKey = @ProductLineKey";

            DbConnector.NonQuery(sql, new { productLineKey }).Execute();
        }

        public IList<ProductLine> FindByName(string productLineName, bool includeProducts)
        {
            if (includeProducts)
            {
                const string sqlA = @"
                SELECT 
                    pl.ProductLineKey, 
                    pl.ProductLineName 
                FROM Production.ProductLine pl 
                WHERE pl.ProductLineName = @ProductLineName;
                SELECT 
                    p.ProductKey, 
                    p.ProductName, 
                    p.ProductLineKey, 
                    p.ShippingWeight, 
                    p.ProductWeight 
                FROM Production.Product p 
                INNER JOIN Production.ProductLine pl ON p.ProductLineKey = pl.ProductLineKey 
                WHERE pl.ProductLineName = @ProductLineName;";

                var tupleResult = DbConnector.ReadToList<ProductLine, Product>(sqlA, new { productLineName }).Execute();

                List<ProductLine> productLines = tupleResult.Item1;
                List<Product> products = tupleResult.Item2;

                productLines.ForEach(pl => pl.Products.AddRange(products.Where(p => p.ProductLineKey == pl.ProductLineKey)));

                return productLines;
            }
            else
            {
                const string sqlB = @"
                SELECT 
                    pl.ProductLineKey, 
                    pl.ProductLineName 
                FROM Production.ProductLine pl 
                WHERE pl.ProductLineName = @ProductLineName;";

                return DbConnector.ReadToList<ProductLine>(sqlB, new { productLineName }).Execute();
            }
        }

        public IList<ProductLine> GetAll(bool includeProducts)
        {
            if (includeProducts)
            {
                const string sqlA = @"
                SELECT 
                    pl.ProductLineKey, 
                    pl.ProductLineName 
                FROM Production.ProductLine pl;
                SELECT 
                    p.ProductKey, 
                    p.ProductName, 
                    p.ProductLineKey, 
                    p.ShippingWeight, 
                    p.ProductWeight 
                FROM Production.Product p 
                INNER JOIN Production.ProductLine pl ON p.ProductLineKey = pl.ProductLineKey;";

                var tupleResult = DbConnector.ReadToList<ProductLine, Product>(sqlA).Execute();

                List<ProductLine> productLines = tupleResult.Item1;
                List<Product> products = tupleResult.Item2;

                productLines.ForEach(pl => pl.Products.AddRange(products.Where(p => p.ProductLineKey == pl.ProductLineKey)));

                return productLines;
            }
            else
            {
                const string sqlB = @"
                SELECT 
                    pl.ProductLineKey, 
                    pl.ProductLineName 
                FROM Production.ProductLine pl;";

                return DbConnector.ReadToList<ProductLine>(sqlB).Execute();
            }
        }

        public ProductLine? GetByKey(int productLineKey, bool includeProducts)
        {
            if (includeProducts)
            {
                const string sqlA = @"
                SELECT 
                    pl.ProductLineKey, 
                    pl.ProductLineName 
                FROM Production.ProductLine pl
                WHERE pl.ProductLineKey = @ProductLineKey;
                SELECT 
                    p.ProductKey, 
                    p.ProductName, 
                    p.ProductLineKey, 
                    p.ShippingWeight, 
                    p.ProductWeight 
                FROM Production.Product p 
                INNER JOIN Production.ProductLine pl ON p.ProductLineKey = pl.ProductLineKey
                WHERE p.ProductLineKey = @productLineKey;";

                var tupleResult = DbConnector.ReadToList<ProductLine, Product>(sqlA, new { productLineKey }).Execute();

                ProductLine productLine = tupleResult.Item1.FirstOrDefault();

                if (productLine != null)
                {
                    productLine.Products.AddRange(tupleResult.Item2);
                }

                return productLine;
            }
            else
            {
                const string sqlB = @"
                SELECT 
                    pl.ProductLineKey, 
                    pl.ProductLineName 
                FROM Production.ProductLine pl
                WHERE pl.ProductLineKey = @productLineKey;";

                return DbConnector.ReadFirstOrDefault<ProductLine>(sqlB, new { productLineKey }).Execute();
            }
        }

        public void Update(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            BuildUpdateProductLine(productLine).Execute();
        }

        public void Update(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), $"{nameof(product)} is null.");

            BuildUpdateProduct(product).Execute();
        }

        public void UpdateGraph(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            productLine.ApplyKeys();

            //Leverage DbConnector's Job Batching feature
            List<IDbJob> jobs = new List<IDbJob>
            {
                BuildUpdateProductLine(productLine)
            };

            foreach (var item in productLine.Products)
            {
                if (item.ProductKey == 0)
                {
                    jobs.Add(BuildInsertProduct(item));
                }
                else
                {
                    jobs.Add(BuildUpdateProduct(item));
                }
            }

            DbJob.ExecuteAll(jobs);//Execute all jobs
        }

        public void UpdateGraphWithChildDeletes(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            productLine.ApplyKeys();

            //TODO: Maybe do everything in a single query
            using (var con = OpenConnection())
            using (var trans = con.BeginTransaction())
            {                
                //Find products
                var originalProductKeys = BuildGetProductKeys(productLine.ProductLineKey).Execute(trans);

                foreach (var item in productLine.Products)
                    originalProductKeys.Remove(item.ProductKey);

                BuildUpdateProductLine(productLine).Execute(trans);

                foreach (var item in productLine.Products)
                {
                    if (item.ProductKey == 0)
                        BuildInsertProduct(item).Execute(trans);
                    else
                        BuildUpdateProduct(item).Execute(trans);
                }

                //Remove products
                if (originalProductKeys.Count > 0)
                    BuildDeleteProducts(originalProductKeys).Execute(trans);

                trans.Commit();
            }
        }

        public void UpdateGraphWithDeletes(ProductLine productLine, IList<int> productKeysToRemove)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            productLine.ApplyKeys();

            //Leverage DbConnector's Job Batching feature
            List<IDbJob> jobs = new List<IDbJob>
            {
                BuildUpdateProductLine(productLine)
            };

            foreach (var item in productLine.Products)
            {
                if (item.ProductKey == 0)
                {
                    jobs.Add(BuildInsertProduct(item));
                }
                else
                {
                    jobs.Add(BuildUpdateProduct(item));
                }
            }

            if (productKeysToRemove != null && productKeysToRemove.Count > 0)
                jobs.Add(BuildDeleteProducts(productKeysToRemove));

            DbJob.ExecuteAll(jobs);//Execute all jobs
        }

        protected IDbJob<int?> BuildDeleteProduct(int productKey)
        {
            const string sql = "DELETE Production.Product WHERE ProductKey = @productKey;";

            return DbConnector.NonQuery(sql, new { productKey });
        }

        protected IDbJob<int?> BuildDeleteProducts(IEnumerable<int> productKeys)
        {
            if (productKeys == null || !productKeys.Any())
                throw new ArgumentException($"{nameof(productKeys)} is null or empty.", nameof(productKeys));

            var keyList = string.Join(", ", productKeys);
            var sql = $"DELETE Production.Product WHERE ProductKey IN ({keyList});";

            return DbConnector.NonQuery(sql);
        }

        protected IDbJob<HashSet<int>> BuildGetProductKeys(int productLineKey)
        {
            const string sql = "SELECT p.ProductKey FROM Production.Product p WHERE p.ProductLineKey = @productLineKey";

            return DbConnector.ReadToHashSet<int>(sql, new { productLineKey });
        }

        protected IDbJob<int> BuildInsertProduct(Product product)
        {
            const string sql = "INSERT INTO Production.Product ( ProductName, ProductLineKey, ShippingWeight, ProductWeight ) OUTPUT Inserted.ProductKey VALUES ( @ProductName, @ProductLineKey, @ShippingWeight, @ProductWeight )";

            return DbConnector.Scalar<int>(sql, product).OnCompleted(result => { product.ProductKey = result; return result; });
        }

        protected IDbJob<int?> BuildUpdateProduct(Product product)
        {
            const string sql = "UPDATE Production.Product SET ProductName = @ProductName, ProductLineKey = @ProductLineKey, ShippingWeight = @ShippingWeight, ProductWeight = @ProductWeight WHERE ProductKey = @ProductKey;";

            return DbConnector.NonQuery(sql, product);
        }

        protected IDbJob<int?> BuildUpdateProductLine(ProductLine productLine)
        {
            const string sql = "UPDATE Production.ProductLine SET ProductLineName = @ProductLineName WHERE ProductLineKey = @ProductLineKey;";

            return DbConnector.NonQuery(sql, productLine);
        }
    }
}
