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

        public async Task Delete(int id, CancellationToken cancellationToken = default)
        {
            var entity = _dbSet.AsNoTracking().Where(en => en.Id == id).FirstOrDefault();
            _dbSet.Remove(entity);

            await SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyCollection<T>> Get(int skip, int take, CancellationToken cancellationToken = default)
        {
            var query = _dbSet.AsQueryable();

            if (take != default)
            {
                query = query.OrderBy(en => en.Id).Skip(skip).Take(take);
            }

            var entities = await query.ToListAsync(cancellationToken);

            return entities.ToArray();
        }

        public async Task<T> GetById(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbSet
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            return entity;
        }

        public async Task<T> Update(T entity, CancellationToken cancellationToken = default)
        {
            var existingEntity = _dbSet.AsNoTracking().Where(en => en.Id == entity.Id).FirstOrDefault();
            existingEntity = entity;

            _dbSet.Update(existingEntity);

            await SaveChangesAsync(cancellationToken);

            return existingEntity;
        }

        private async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
