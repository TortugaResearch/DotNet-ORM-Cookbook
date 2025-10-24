namespace Recipes.LargeBatch;

public static class Utilities
{
    public static IEnumerable<List<T>> BatchAsLists<T>(this IEnumerable<T> source, int batchSize)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source), $"{nameof(source)} is null.");
        if (batchSize <= 0)
            throw new ArgumentOutOfRangeException(nameof(batchSize), batchSize, $"{batchSize} must be greater than 0");

        return BatchAsListsCore();

        IEnumerable<List<T>> BatchAsListsCore()
        {
            int count = 0;
            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    var chunk = new List<T>(batchSize);
                    count = 1;
                    chunk.Add(iter.Current);
                    for (int i = 1; i < batchSize && iter.MoveNext(); i++)
                    {
                        chunk.Add(iter.Current);
                        count++;
                    }
                    yield return chunk;
                }
            }
        }
    }
}