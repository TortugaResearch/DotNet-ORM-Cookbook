using Microsoft.EntityFrameworkCore;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.ModelWithChildren;

namespace Recipes.EntityFrameworkCore.ModelWithChildren;

public class ModelWithChildrenScenario : IModelWithChildrenScenario<ProductLine, Product>
{
    private Func<OrmCookbookContext> CreateDbContext;

    public ModelWithChildrenScenario(Func<OrmCookbookContext> dBContextFactory)
    {
        CreateDbContext = dBContextFactory;
    }

    public int Create(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        //A transaction is automatically created when `SaveChanges()` is called.
        using (var context = CreateDbContext())
        {
            context.ProductLines.Add(productLine);
            context.SaveChanges();
            return productLine.ProductLineKey;
        }
    }

    public void Delete(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        using (var context = CreateDbContext())
        {
            context.ProductLines.Remove(productLine);
            context.SaveChanges();
        }
    }

    public void DeleteByKey(int productLineKey)
    {
        using (var context = CreateDbContext())
        {
            //Need to explicitly fetch child records in order to delete them.
            var temp = context.ProductLines.Where(x => x.ProductLineKey == productLineKey).Include(x => x.Products).Single();
            context.ProductLines.Remove(temp);
            context.SaveChanges();
        }
    }

    public IList<ProductLine> FindByName(string productLineName, bool includeProducts)
    {
        using (var context = CreateDbContext())
        {
            if (includeProducts)
                return context.ProductLines.Where(x => x.ProductLineName == productLineName).Include(x => x.Products).ToList();
            else
                return context.ProductLines.Where(x => x.ProductLineName == productLineName).ToList();
        }
    }

    public IList<ProductLine> GetAll(bool includeProducts)
    {
        using (var context = CreateDbContext())
        {
            if (includeProducts)
                return context.ProductLines.Include(x => x.Products).ToList();
            else
                return context.ProductLines.ToList();
        }
    }

    public ProductLine? GetByKey(int productLineKey, bool includeProducts)
    {
        using (var context = CreateDbContext())
        {
            if (includeProducts)
                return context.ProductLines.Where(x => x.ProductLineKey == productLineKey).Include(x => x.Products).SingleOrDefault();
            else
                return context.ProductLines.Find(productLineKey);
        }
    }

    public void Update(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product), $"{nameof(product)} is null.");

        using (var context = CreateDbContext())
        {
            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
        }
    }

    public void Update(ProductLine productLine)
    {
        using (var context = CreateDbContext())
        {
            context.Entry(productLine).State = EntityState.Modified;
            context.SaveChanges();
        }
    }

    public void UpdateGraph(ProductLine productLine)
    {
        //A transaction is automatically created when `SaveChanges()` is called.
        using (var context = CreateDbContext())
        {
            context.Entry(productLine).State = EntityState.Modified;

            foreach (var item in productLine.Products)
                if (item.ProductKey == 0)
                    context.Entry(item).State = EntityState.Added;
                else
                    context.Entry(item).State = EntityState.Modified;

            context.SaveChanges();
        }
    }

    public void UpdateGraphWithChildDeletes(ProductLine productLine)
    {
        if (productLine == null)
            throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

        //An explicit transaction is needed reading the rows to delete happens outside of the `SaveChanges` call.
        using (var context = CreateDbContext())
        using (var transaction = context.Database.BeginTransaction())
        {
            var validKeys = productLine.Products.Select(x => x.ProductKey).ToList();

            //get rows to delete
            var oldRows = context.Products.Where(x => x.ProductLineKey == productLine.ProductLineKey && !validKeys.Contains(x.ProductKey)).ToList();

            //Remove the old records
            foreach (var row in oldRows)
                context.Products.Remove(row);

            context.Entry(productLine).State = EntityState.Modified;
            foreach (var item in productLine.Products)
                if (item.ProductKey == 0)
                    context.Entry(item).State = EntityState.Added;
                else
                    context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();

            transaction.Commit();
        }
    }

    public void UpdateGraphWithDeletes(ProductLine productLine, IList<int> productKeysToRemove)
    {
        //A transaction is automatically created when `SaveChanges()` is called.
        using (var context = CreateDbContext())
        {
            context.Entry(productLine).State = EntityState.Modified;
            foreach (var item in productLine.Products)
                if (item.ProductKey == 0)
                    context.Entry(item).State = EntityState.Added;
                else
                    context.Entry(item).State = EntityState.Modified;

            if (productKeysToRemove != null)
                foreach (var key in productKeysToRemove)
                    context.Entry(new Product() { ProductKey = key }).State = EntityState.Deleted;

            context.SaveChanges();
        }
    }
}