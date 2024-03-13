using BusinessBanking.DAL.DataContexts;
using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace BusinessBanking.Repository.Users
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly DataContext _db;

        public UserRepository(DataContext dataContext)
        {
            _db = dataContext;
        }

        public IQueryable<User> GetAll()
        {
            return _db.Users;
        }

        public Task<IQueryable<TEntity>> GetAll<TEntity>(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
	        throw new NotImplementedException();
        }

        public IQueryable<User> FindByCondition(Expression<Func<User, bool>> predicate, Func<IQueryable<User>, IIncludableQueryable<User, object>> include = null)
        {
	        throw new NotImplementedException();
        }

        public Task<User> GetByPredicateAsync(Expression<Func<User, bool>> predicate)
        {
	        throw new NotImplementedException();
        }

        public Task<User> CreateAsync(User entity)
        {
	        throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User entity)
        {
	        throw new NotImplementedException();
        }

        public Task DeleteAsync(User entity)
        {
	        throw new NotImplementedException();
        }
    }
}
