using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BackEnd.Shared.Interfaces
{
    public interface IBaseStore<T> where T : class
    {
        /// <summary>
        /// Adds an entity in the database.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the <typeparamref name="T" />.
        /// </returns>
        Task<T> Add(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns all entities in the database
        /// A task that represents the asynchronous operation.
        /// The task result contains the list of entities />.
        /// </returns>
        Task<IReadOnlyCollection<T>> Get(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an entity from the database.
        /// </summary>
        /// <param name="id">The id of the entity we query.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the <typeparamref name="T" />.
        /// </returns>
        Task<T> GetById(int id, CancellationToken cancellationToken = default);
    }
}
