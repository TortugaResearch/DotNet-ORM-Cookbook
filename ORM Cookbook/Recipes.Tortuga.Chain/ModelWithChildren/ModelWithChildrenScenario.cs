using Recipes.ModelWithChildren;
using System;
using System.Collections.Generic;
using System.Linq;
using Tortuga.Chain;

namespace Recipes.Chain.ModelWithChildren
{
    public class ModelWithChildrenScenario : IModelWithChildrenScenario<ProductLine, Product>
    {
        readonly SqlServerDataSource m_DataSource;
        readonly string ProductLineTable = "Production.ProductLine";
        readonly string ProductTable = "Production.Product";

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
                trans.DeleteWithFilter(ProductTable, new { productLine.ProductLineKey }).Execute();
                trans.Delete(productLine).Execute();
                trans.Commit();
            }
        }

        public void DeleteByKey(int productLineKey)
        {
            using (var trans = m_DataSource.BeginTransaction())
            {
                trans.DeleteWithFilter(ProductTable, new { productLineKey }).Execute();
                trans.DeleteByKey(ProductLineTable, productLineKey).Execute();
                trans.Commit();
            }
        }

        public IList<ProductLine> FindByName(string productLineName, bool includeProducts)
        {
            var results = m_DataSource.From(ProductLineTable, new { productLineName }).ToCollection<ProductLine>().Execute();
            if (results.Count > 0 && includeProducts)
            {
                var children = m_DataSource.GetByKeyList(ProductTable, "ProductLineKey", results.Select(pl => pl.ProductLineKey)).ToCollection<Product>().Execute();
                foreach (var line in results)
                    line.Products.AddRange(children.Where(x => x.ProductLineKey == line.ProductLineKey));
            }
            return results;
        }

        public IList<ProductLine> GetAll(bool includeProducts)
        {
            var results = m_DataSource.From(ProductLineTable).ToCollection<ProductLine>().Execute();
            if (includeProducts)
            {
                var children = m_DataSource.From(ProductTable).ToCollection<Product>().Execute();
                foreach (var line in results)
                    line.Products.AddRange(children.Where(x => x.ProductLineKey == line.ProductLineKey));
            }
            return results;
        }

        public ProductLine? GetByKey(int productLineKey, bool includeProducts)
        {
            var result = m_DataSource.GetByKey(ProductLineTable, productLineKey).ToObject<ProductLine>(RowOptions.AllowEmptyResults).Execute();
            if (result != null && includeProducts)
            {
                var children = m_DataSource.From(ProductTable, new { result.ProductLineKey }).ToCollection<Product>().Execute();
                result.Products.AddRange(children);
            }
            return result;
        }

        public void Update(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            using (var trans = m_DataSource.BeginTransaction())
            {
                //Update parent row
                trans.Update(productLine).Execute();

                //Find the list of child keys to remove
                var oldKeys = trans.From(ProductTable, new { productLine.ProductLineKey }).ToInt32List("ProductKey").Execute().ToHashSet();
                foreach (var key in productLine.Products.Select(x => x.ProductKey))
                    oldKeys.Remove(key);

                //Remove the old records
                foreach (var key in oldKeys)
                    trans.DeleteByKey(ProductTable, key).Execute();

                //Ensure new child rows have their parent's key
                productLine.ApplyKeys();

                //Insert/update the remaining child rows
                foreach (var row in productLine.Products)
                    trans.Upsert(row).Execute();

                trans.Commit();
            }
        }

        public void Update(Product product)
        {
            m_DataSource.Update(product).Execute();
        }
    }
}
