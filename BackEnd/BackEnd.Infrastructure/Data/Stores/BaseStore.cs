using BackEnd.Shared.Extensions;
using BackEnd.Shared.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace BackEnd.Infrastructure.Data.Stores
{
    public abstract class BaseStore<T> : IBaseStore<T> where T : class
    {
        private readonly PostDbContext _context;

        public BaseStore(PostDbContext context)
        {
            _context = context.ThrowIfNull(nameof(context));
        }

        public async Task<T> Add(T entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
            await SaveChangesAsync(cancellationToken);

            return entity;
        }

        private async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
