using Shared.Entities;
using System.Linq.Expressions;

namespace Shared.Repository
{
    public interface IGenericRepositoryAsync<T>
        where T : class, IEntity, new()
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>>[]? includes = null, Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default);
        public Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[]? includes = null);
    }
}
