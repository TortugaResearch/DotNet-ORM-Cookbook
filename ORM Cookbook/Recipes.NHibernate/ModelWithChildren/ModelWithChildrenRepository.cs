using NHibernate;
using NHibernate.Criterion;
using Recipes.ModelWithChildren;
using Recipes.NHibernate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.NHibernate.ModelWithChildren
{
    public class ModelWithChildrenRepository : IModelWithChildrenRepository<ProductLine, Product>
    {
        readonly ISessionFactory m_SessionFactory;

        public ModelWithChildrenRepository(ISessionFactory sessionFactory)
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
                var result = session
                    .CreateCriteria(typeof(ProductLine))
                    .Add(Restrictions.Eq("ProductLineName", productLineName))
                    .List<ProductLine>();

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
                var result = session
                    .CreateCriteria(typeof(ProductLine))
                    .List<ProductLine>();

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

        public void Update(ProductLine productLine)
        {
            if (productLine == null)
                throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

            productLine.ApplyKeys();

            //Deletes have to be handled in a separate session to avoid a NHibernate.NonUniqueObjectException
            using (var session = m_SessionFactory.OpenSession())
            {
                //Find the list of child keys to remove
                var rowsToDelete = session.CreateCriteria(typeof(Product))
                    .Add(Restrictions.Eq("ProductLine", productLine))
                    .List<Product>();

                //Remove the old records
                foreach (var row in rowsToDelete)
                {
                    if (!productLine.Products.Any(x => x.ProductKey == row.ProductKey))
                        session.Delete(row);
                }
                session.Flush();
            }

            using (var session = m_SessionFactory.OpenSession())
            {
                session.Update(productLine);
                session.Flush();
            }
        }

        public void Update(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), $"{nameof(product)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            {
                session.Update(product);
                session.Flush();
            }
        }
    }
}
