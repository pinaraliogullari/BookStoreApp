using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Data.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task HardDeleteAsync(TEntity entity);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
            params Expression<Func<TEntity, object>>[] includeProperties);
        Task<List<TEntity>>GetAllAsync(Expression<Func<TEntity, bool>> predicate = null,
            params Expression<Func<TEntity, object>>[] includeProperties);


    }
}
