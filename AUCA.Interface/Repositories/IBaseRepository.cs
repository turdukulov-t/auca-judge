using BusinessBanking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace BusinessBanking.Interface.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        Task<IQueryable<TEntity>> GetAll<TEntity>(
	        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

		IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> predicate,
	        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

		Task<TEntity> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate);

		Task<TEntity> CreateAsync(TEntity entity);

		Task<TEntity> UpdateAsync(TEntity entity);

		Task DeleteAsync(TEntity entity);
    }
}
