using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using Recipes.ModelWithChildren;
using Recipes.NHibernate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

#pragma warning disable CA1806 // Do not ignore method results. We are intentionally ignoring results in some cases.

namespace Recipes.NHibernate.ModelWithChildren
{
    public class ModelWithChildrenScenario : IModelWithChildrenScenario<ProductLine, Product>
    {
        readonly ISessionFactory m_SessionFactory;

        public ModelWithChildrenScenario(ISessionFactory sessionFactory)
        {
            m_SessionFactory = sessionFactory;
        }

        public int Create(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            productLine.ApplyKeys();

            using (var session = m_SessionFactory.OpenSession())
            {
                session.Save(productLine);
                session.Flush();
                return productLine.ProductLineKey;
            }
        }

        public void Delete(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            {
                session.Delete(productLine);
                session.Flush();
            }
        }

        public void DeleteByKey(int productLineKey)
        {
            using (var session = m_SessionFactory.OpenSession())
            {
                var temp = session.Get<ProductLine>(productLineKey);

                session.Delete(temp);
                session.Flush();
            }
        }

        public IList<ProductLine> FindByName(string productLineName, bool includeProducts)
        {
            using (var session = m_SessionFactory.OpenSession())
            {
                var result = session.QueryOver<ProductLine>().Where(pl => pl.ProductLineName == productLineName).List();

                if (includeProducts)
                    result.SelectMany(x => x.Products).All(x => true); //force lazy-load
                else
                    foreach (var line in result)
                        line.Products = new List<Product>();//disable lazy-loading

                return result;
            }
        }

        public IList<ProductLine> GetAll(bool includeProducts)
        {
            using (var session = m_SessionFactory.OpenSession())
            {
                var result = session.QueryOver<ProductLine>().List();

                if (includeProducts)
                    result.SelectMany(x => x.Products).All(x => true); //force lazy-load
                else
                    foreach (var line in result)
                        line.Products = new List<Product>();//disable lazy-loading

                return result;
            }
        }

        public ProductLine? GetByKey(int productLineKey, bool includeProducts)
        {
            using (var session = m_SessionFactory.OpenSession())
            {
                var result = session.Get<ProductLine>(productLineKey);
                if (result != null)
                {
                    if (includeProducts)
                        result.Products.All(x => true); //force lazy-load
                    else
                        result.Products = new List<Product>(); //disable lazy-loading
                }
                return result;
            }
        }

        public void UpdateGraphWithChildDeletes(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            productLine.ApplyKeys();

            using (var session = m_SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                session.Update(productLine);
                session.Flush();
                trans.Commit();
            }
        }

        public void Update(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), $"{nameof(product)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                session.Merge(product);
                session.Flush();
                trans.Commit();
            }
        }

        public void Update(ProductLine productLine)
        {
            throw new AssertInconclusiveException();
        }

        public void UpdateGraph(ProductLine productLine)
        {
            throw new AssertInconclusiveException();
        }

        public void UpdateGraphWithDeletes(ProductLine productLine, IList<int> productKeysToRemove)
        {
            throw new AssertInconclusiveException();
        }
    }
}
