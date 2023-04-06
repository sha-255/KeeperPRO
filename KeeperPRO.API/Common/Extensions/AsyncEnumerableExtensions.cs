namespace KeeperPRO.Api.Common.Extensions
{
    public static class AsyncEnumerableExtensions
    {
        public static async Task<List<T>> ToListAsync<T>(
            this IAsyncEnumerable<T> items,
            CancellationToken cancellationToken = default)
        {
            List<T> results = new();
            await foreach (var item in items
                .WithCancellation(cancellationToken)
                .ConfigureAwait(false))
                results.Add(item);
            return results;
        }

        public static async Task<IEnumerable<T>> ToIEnumerableAsync<T>(
            this IAsyncEnumerable<T> items,
            CancellationToken cancellationToken = default)
            => await items.ToListAsync(cancellationToken);
    }
}