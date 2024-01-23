using System.Linq.Expressions;

namespace BolsaEmpleo.Application.Common.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T entity);

        Task DeleteAsync(T entity);

        Task<T> FindAsync(int id, params Expression<Func<T, object>>[] includes);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        Task<T> FindOneAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        Task UpdateAsync(T entity);

        Task RemoveAsync(T entity);
    }
}