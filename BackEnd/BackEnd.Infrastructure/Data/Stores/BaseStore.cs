using BackEnd.Shared.Extensions;
using BackEnd.Shared.Interfaces;
using BackEnd.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackEnd.Infrastructure.Data.Stores
{
    public abstract class BaseStore<T> : IBaseStore<T> where T : BaseEntity
    {
        private readonly PostDbContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseStore(PostDbContext context)
        {
            _context = context.ThrowIfNull(nameof(context));
            _dbSet = context.Set<T>();
        }

        public async Task<T> Add(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            await SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<IReadOnlyCollection<T>> Get(CancellationToken cancellationToken = default)
        {
            var entities = await _dbSet.ToListAsync(cancellationToken);

            return entities.ToArray();
        }

        public async Task<T> GetById(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbSet
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            return entity;
        }

        private async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
