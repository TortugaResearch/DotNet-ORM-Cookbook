using Microsoft.Data.SqlClient;
using Recipes.Ado.Models;
using Recipes.ModelWithChildren;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Ado.ModelWithChildren
{
    public class ModelWithChildrenScenario : SqlServerScenarioBase, IModelWithChildrenScenario<ProductLine, Product>
    {
        public ModelWithChildrenScenario(string connectionString) : base(connectionString)
        { }

        public int Create(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            const string sql = "INSERT INTO Production.ProductLine ( ProductLineName ) OUTPUT Inserted.ProductLineKey VALUES (@ProductLineName);";

            using (var con = OpenConnection())
            using (var trans = con.BeginTransaction())
            {
                using (var cmd = new SqlCommand(sql, con, trans))
                {
                    cmd.Parameters.AddWithValue("@ProductLineName", productLine.ProductLineName);
                    productLine.ProductLineKey = (int)cmd.ExecuteScalar();
                    productLine.ApplyKeys();
                }

                foreach (var item in productLine.Products)
                    InsertProduct(con, trans, item);

                trans.Commit();
            }
            return productLine.ProductLineKey;
        }

        public void Delete(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            const string sql = @"DELETE FROM Production.Product WHERE ProductLineKey = @ProductLineKey;
DELETE FROM Production.ProductLine WHERE ProductLineKey = @ProductLineKey";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ProductLineKey", productLine.ProductLineKey);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteByKey(int productLineKey)
        {
            const string sql = @"DELETE FROM Production.Product WHERE ProductLineKey = @ProductLineKey;
DELETE FROM Production.ProductLine WHERE ProductLineKey = @ProductLineKey";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ProductLineKey", productLineKey);
                cmd.ExecuteNonQuery();
            }
        }

        public IList<ProductLine> FindByName(string productLineName, bool includeProducts)
        {
            const string sqlA = @"SELECT pl.ProductLineKey, pl.ProductLineName FROM Production.ProductLine pl WHERE pl.ProductLineName = @ProductLineName;
SELECT p.ProductKey, p.ProductName, p.ProductLineKey, p.ShippingWeight, p.ProductWeight FROM Production.Product p INNER JOIN Production.ProductLine pl ON p.ProductLineKey = pl.ProductLineKey WHERE pl.ProductLineName = @ProductLineName;";

            const string sqlB = @"SELECT pl.ProductLineKey, pl.ProductLineName FROM Production.ProductLine pl WHERE pl.ProductLineName = @ProductLineName;";

            var sql = includeProducts ? sqlA : sqlB;
            var results = new List<ProductLine>();

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ProductLineName", productLineName);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new ProductLine(reader));
                    }

                    if (includeProducts)
                    {
                        var lookup = results.ToDictionary(x => x.ProductLineKey);
                        reader.NextResult();
                        while (reader.Read())
                        {
                            var product = new Product(reader);
                            lookup[product.ProductLineKey].Products.Add(product);
                        }
                    }
                }
            }

            return results;
        }

        public IList<ProductLine> GetAll(bool includeProducts)
        {
            const string sqlA = @"SELECT pl.ProductLineKey, pl.ProductLineName FROM Production.ProductLine pl;
SELECT p.ProductKey, p.ProductName, p.ProductLineKey, p.ShippingWeight, p.ProductWeight FROM Production.Product p INNER JOIN Production.ProductLine pl ON p.ProductLineKey = pl.ProductLineKey;";

            const string sqlB = @"SELECT pl.ProductLineKey, pl.ProductLineName FROM Production.ProductLine pl;";

            var sql = includeProducts ? sqlA : sqlB;
            var results = new List<ProductLine>();

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    results.Add(new ProductLine(reader));

                if (includeProducts)
                {
                    var lookup = results.ToDictionary(x => x.ProductLineKey);
                    reader.NextResult();
                    while (reader.Read())
                    {
                        var product = new Product(reader);
                        lookup[product.ProductLineKey].Products.Add(product);
                    }
                }
            }

            return results;
        }

        public ProductLine? GetByKey(int productLineKey, bool includeProducts)
        {
            const string sqlA = @"SELECT pl.ProductLineKey, pl.ProductLineName FROM Production.ProductLine pl WHERE pl.ProductLineKey = @ProductLineKey;
SELECT p.ProductKey, p.ProductName, p.ProductLineKey, p.ShippingWeight, p.ProductWeight FROM Production.Product p WHERE p.ProductLineKey = @ProductLineKey;";

            const string sqlB = @"SELECT pl.ProductLineKey, pl.ProductLineName FROM Production.ProductLine pl WHERE pl.ProductLineKey = @ProductLineKey;";

            var sql = includeProducts ? sqlA : sqlB;
            ProductLine result;

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ProductLineKey", productLineKey);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        result = new ProductLine(reader);
                    else
                        return null;

                    if (includeProducts)
                    {
                        reader.NextResult();
                        while (reader.Read())
                            result.Products.Add(new Product(reader));
                    }
                }
            }

            return result;
        }

        public void Update(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            using (var con = OpenConnection())
                UpdateProductLine(con, null, productLine);
        }

        public void Update(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), $"{nameof(product)} is null.");

            using (var con = OpenConnection())
                UpdateProduct(con, null, product);
        }

        public void UpdateGraph(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            productLine.ApplyKeys();

            using (var con = OpenConnection())
            using (var trans = con.BeginTransaction())
            {
                UpdateProductLine(con, trans, productLine);
                foreach (var item in productLine.Products)
                {
                    if (item.ProductKey == 0)
                        InsertProduct(con, trans, item);
                    else
                        UpdateProduct(con, trans, item);
                }

                trans.Commit();
            }
        }

        public void UpdateGraphWithChildDeletes(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            productLine.ApplyKeys();

            using (var con = OpenConnection())
            using (var trans = con.BeginTransaction())
            {
                //Find products to remove
                var originalProductKeys = GetProductKeys(con, trans, productLine.ProductLineKey);
                foreach (var item in productLine.Products)
                    originalProductKeys.Remove(item.ProductKey);

                UpdateProductLine(con, trans, productLine);
                foreach (var item in productLine.Products)
                {
                    if (item.ProductKey == 0)
                        InsertProduct(con, trans, item);
                    else
                        UpdateProduct(con, trans, item);
                }

                //Remove products
                foreach (var key in originalProductKeys)
                    DeleteProduct(con, trans, key);

                trans.Commit();
            }
        }

        public void UpdateGraphWithDeletes(ProductLine productLine, IList<int> productKeysToRemove)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            productLine.ApplyKeys();

            using (var con = OpenConnection())
            using (var trans = con.BeginTransaction())
            {
                UpdateProductLine(con, trans, productLine);

                foreach (var item in productLine.Products)
                {
                    if (item.ProductKey == 0)
                        InsertProduct(con, trans, item);
                    else
                        UpdateProduct(con, trans, item);
                }

                if (productKeysToRemove != null)
                    foreach (var key in productKeysToRemove)
                        DeleteProduct(con, trans, key);

                trans.Commit();
            }
        }

        static void DeleteProduct(SqlConnection con, SqlTransaction trans, int productKey)
        {
            const string sql = "DELETE Production.Product WHERE ProductKey = @ProductKey;";

            using (var cmd = new SqlCommand(sql, con, trans))
            {
                cmd.Parameters.AddWithValue("@ProductKey", productKey);
                cmd.ExecuteNonQuery();
            }
        }

        static HashSet<int> GetProductKeys(SqlConnection con, SqlTransaction trans, int productLineKey)
        {
            const string sql = "SELECT p.ProductKey FROM Production.Product p WHERE p.ProductLineKey = @ProductLineKey";

            var results = new HashSet<int>();
            using (var cmd = new SqlCommand(sql, con, trans))
            {
                cmd.Parameters.AddWithValue("@ProductLineKey", productLineKey);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        results.Add(reader.GetInt32(0));
            }
            return results;
        }

        static void InsertProduct(SqlConnection con, SqlTransaction trans, Product product)
        {
            const string sql = "INSERT INTO Production.Product ( ProductName, ProductLineKey, ShippingWeight, ProductWeight ) OUTPUT Inserted.ProductKey VALUES ( @ProductName, @ProductLineKey, @ShippingWeight, @ProductWeight )";

            using (var cmd = new SqlCommand(sql, con, trans))
            {
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductLineKey", product.ProductLineKey);
                cmd.Parameters.AddWithValue("@ShippingWeight", product.ShippingWeight);
                cmd.Parameters.AddWithValue("@ProductWeight", product.ProductWeight);
                product.ProductKey = (int)cmd.ExecuteScalar();
            }
        }

        static void UpdateProduct(SqlConnection con, SqlTransaction? trans, Product product)
        {
            const string sql = "UPDATE Production.Product SET ProductName = @ProductName, ProductLineKey = @ProductLineKey, ShippingWeight = @ShippingWeight, ProductWeight = @ProductWeight WHERE ProductKey = @ProductKey;";

            using (var cmd = new SqlCommand(sql, con, trans))
            {
                cmd.Parameters.AddWithValue("@ProductKey", product.ProductKey);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductLineKey", product.ProductLineKey);
                cmd.Parameters.AddWithValue("@ShippingWeight", product.ShippingWeight);
                cmd.Parameters.AddWithValue("@ProductWeight", product.ProductWeight);

                cmd.ExecuteNonQuery();
            }
        }

        static void UpdateProductLine(SqlConnection con, SqlTransaction? trans, ProductLine productLine)
        {
            const string sql = "UPDATE Production.ProductLine SET ProductLineName = @ProductLineName WHERE ProductLineKey = @ProductLineKey;";

            using (var cmd = new SqlCommand(sql, con, trans))
            {
                cmd.Parameters.AddWithValue("@ProductLineKey", productLine.ProductLineKey);
                cmd.Parameters.AddWithValue("@ProductLineName", productLine.ProductLineName);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
