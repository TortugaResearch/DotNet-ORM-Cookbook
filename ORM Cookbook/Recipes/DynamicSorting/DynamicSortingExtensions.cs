using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Recipes.DynamicSorting
{
    public static class DynamicSortingExtensions
    {
        //Inspired by https://stackoverflow.com/a/31959568/5274

        static readonly MethodInfo s_OrderBy = typeof(Queryable).GetMethods()
            .Where(m => m.Name == "OrderBy" && m.IsGenericMethodDefinition && m.GetParameters().Length == 2)
            .Single();

        static readonly MethodInfo s_OrderByDescending = typeof(Queryable).GetMethods()
            .Where(m => m.Name == "OrderByDescending" && m.IsGenericMethodDefinition && m.GetParameters().Length == 2)
            .Single();

        static readonly MethodInfo s_ThenBy = typeof(Queryable).GetMethods()
            .Where(m => m.Name == "ThenBy" && m.IsGenericMethodDefinition && m.GetParameters().Length == 2)
            .Single();

        static readonly MethodInfo s_ThenByDescending = typeof(Queryable).GetMethods()
            .Where(m => m.Name == "ThenByDescending" && m.IsGenericMethodDefinition && m.GetParameters().Length == 2)
            .Single();

        public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> query, string propertyName)
        {
            return BuildQuery(s_OrderBy, query, propertyName);
        }

        public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> query, string propertyName,
            bool isDescending)
        {
            if (isDescending)
                return BuildQuery(s_OrderByDescending, query, propertyName);
            else
                return BuildQuery(s_OrderBy, query, propertyName);
        }

        public static IOrderedQueryable<TSource> ThenBy<TSource>(this IQueryable<TSource> query, string propertyName,
            bool isDescending)
        {
            if (isDescending)
                return BuildQuery(s_ThenByDescending, query, propertyName);
            else
                return BuildQuery(s_ThenBy, query, propertyName);
        }

        public static IOrderedQueryable<TSource> OrderByDescending<TSource>(this IQueryable<TSource> query,
            string propertyName)
        {
            return BuildQuery(s_OrderByDescending, query, propertyName);
        }

        public static IOrderedQueryable<TSource> ThenBy<TSource>(this IQueryable<TSource> query, string propertyName)
        {
            return BuildQuery(s_ThenBy, query, propertyName);
        }

        public static IOrderedQueryable<TSource> ThenByDescending<TSource>(this IQueryable<TSource> query,
            string propertyName)
        {
            return BuildQuery(s_ThenByDescending, query, propertyName);
        }

        static IOrderedQueryable<TSource> BuildQuery<TSource>(MethodInfo method, IQueryable<TSource> query,
            string propertyName)
        {
            var entityType = typeof(TSource);

            var propertyInfo = entityType.GetProperty(propertyName);
            if (propertyInfo == null)
                throw new ArgumentOutOfRangeException(nameof(propertyName), "Unknown column " + propertyName);

            var arg = Expression.Parameter(entityType, "x");
            var property = Expression.Property(arg, propertyName);
            var selector = Expression.Lambda(property, new ParameterExpression[] { arg });

            var genericMethod = method.MakeGenericMethod(entityType, propertyInfo.PropertyType);

            return (IOrderedQueryable<TSource>)genericMethod.Invoke(genericMethod, new object[] { query, selector })!;
        }
    }
}
