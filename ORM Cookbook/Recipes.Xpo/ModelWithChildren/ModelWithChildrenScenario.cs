using Recipes.Xpo.Entities;
using Recipes.ModelWithChildren;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Recipes.Xpo.ModelWithChildren
{
    public class ModelWithChildrenScenario : IModelWithChildrenScenario<ProductLine, Product>
    {

        public int Create(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");
            productLine.Save();
            return productLine.ProductLineKey;
        }

        public void Delete(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            productLine.Delete();
        }

        public void DeleteByKey(int productLineKey)
        {
            Session.DefaultSession.GetObjectByKey<ProductLine>(productLineKey).Delete();
        }

        public IList<ProductLine> FindByName(string productLineName, bool includeProducts)
        {
            Assert.Inconclusive("XPO Objects provide deferred loading out of box, so you don't need to manually include or exclude linked objects and collections");
            return Session.DefaultSession.Query<ProductLine>().Where(x => x.ProductLineName == productLineName).ToList();
        }

        public IList<ProductLine> GetAll(bool includeProducts)
        {
            Assert.Inconclusive("XPO Objects provide deferred loading out of box, so you don't need to manually include or exclude linked objects and collections");

            // XPO does not load objects until you access them
            return Session.DefaultSession.Query<ProductLine>().ToList();
        }

        public ProductLine? GetByKey(int productLineKey, bool includeProducts)
        {
            Assert.Inconclusive("XPO Objects provide deferred loading out of box, so you don't need to manually include or exclude linked objects and collections");

            // XPO does not load objects until you access them
            return Session.DefaultSession.GetObjectByKey<ProductLine>(productLineKey);
        }

        public void Update(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), $"{nameof(product)} is null.");

            product.Save();
        }

        public void Update(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            productLine.Save();
        }

        public void UpdateGraph(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            productLine.Save();
        }

        public void UpdateGraphWithChildDeletes(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");
            // https://docs.devexpress.com/XPO/DevExpress.Xpo.AggregatedAttribute does all the job
            productLine.Save();
        }


        public void UpdateGraphWithDeletes(ProductLine productLine, IList<int> productKeysToRemove)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            if (productKeysToRemove != null)
                foreach (var key in productKeysToRemove)
                    Session.DefaultSession.GetObjectByKey<Product>(key).Delete();
            productLine.Save();
        }
    }
}
