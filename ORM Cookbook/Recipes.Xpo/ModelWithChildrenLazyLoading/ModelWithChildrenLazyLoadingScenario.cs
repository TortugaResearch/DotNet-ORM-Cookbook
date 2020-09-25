using DevExpress.Xpo;
using Recipes.ModelWithChildrenLazyLoading;
using Recipes.Xpo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Xpo.ModelWithChildrenLazyLoading
{
    public class ModelWithChildrenLazyLoadingScenario : IModelWithChildrenLazyLoadingScenario<ProductLine, Product>
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
            return Session.DefaultSession.Query<ProductLine>().Where(x => x.ProductLineName == productLineName).ToList();
        }

        public IList<ProductLine> GetAll(bool includeProducts)
        {
            // XPO does not load objects until you access them
            return Session.DefaultSession.Query<ProductLine>().ToList();
        }

        public ProductLine? GetByKey(int productLineKey)
        {
            // XPO does not load objects until you access them
            return Session.DefaultSession.GetObjectByKey<ProductLine>(productLineKey);
        }

        public void Update(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), $"{nameof(product)} is null.");

            product.Save();
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
