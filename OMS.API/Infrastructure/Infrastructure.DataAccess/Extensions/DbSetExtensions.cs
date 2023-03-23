using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Extensions;

public static class DbSetExtensions
{
    public static async Task<T> GetByIdAsync<T, TKey>(
        this DbSet<T> dbSet,
        TKey id,
        CancellationToken cancellationToken = default)
        where T : class
        where TKey : IEquatable<TKey>
    {
        var entity = await dbSet.FindAsync(new object[] { id }, cancellationToken);

        return entity ?? throw new EntityNotFoundException($"Entity of type {typeof(T).Name} with id {id} not found");
    }
}