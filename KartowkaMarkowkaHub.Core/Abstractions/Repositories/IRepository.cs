using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Core.Abstractions.Repositories
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task<IEnumerable<T>> GetRangeByIdsAsync(List<Guid> ids);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        IQueryable<T> GetAllQueryableAsync();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    }
}
