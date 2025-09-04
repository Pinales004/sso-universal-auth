

using API_BASE.Domain.Entities.Usuario.Solicitud;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace API_BASE.Application.Interfaces
{
    public interface IRepository<TEntity, TId>
    {
        Task<TEntity?> GetByIdAsync(TId id, CancellationToken ct = default);
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);
        Task<List<TEntity>> GetAllAsync(CancellationToken ct = default);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);
        IQueryable<TEntity> Query(bool asNoTracking = true);
        Task AddAsync(TEntity entity, CancellationToken ct = default);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        Task<int> SaveChangesAsync(CancellationToken ct = default);
        Task<(List<TEntity> Items, int TotalCount)> GetPagedAsync(
            Expression<Func<TEntity, bool>>? predicate, int page, int pageSize, CancellationToken ct = default);
    }

}
