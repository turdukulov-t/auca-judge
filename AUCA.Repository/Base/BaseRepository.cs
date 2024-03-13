using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AUCA.Domain.Exceptions;
using BusinessBanking.DAL.DataContexts;
using BusinessBanking.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace AUCA.Repository.Base;
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
	protected DbSet<TEntity> DbSet { get; }
	private DataContext Context { get; set; }

	public BaseRepository(DataContext context)
	{
		Context = context;
		DbSet = Context.Set<TEntity>();
	}

	public IQueryable<TEntity> GetAll()
	{
		throw new NotImplementedException();
	}

	public async Task<IQueryable<TEntity>> GetAll<TEntity>(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
	{
		IQueryable<TEntity> query = DbSet.AsQueryable() as IQueryable<TEntity>;
		
		if (include is not null)
		{
			query = include(query);
		}

		return query;
	}

	public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
	{
		IQueryable<TEntity> query = DbSet.AsQueryable();

		query = query.Where(predicate);

		if (include != null)
		{
			query = include(query);
		}

		return query;
	}

	public async Task<TEntity> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate)
	{
		IQueryable<TEntity> query = DbSet.AsQueryable();

		query = query.Where(predicate);

		return await query.FirstOrDefaultAsync();
	}

	public async Task<TEntity> CreateAsync(TEntity entity)
	{
		await Context.Set<TEntity>().AddAsync(entity);
		await Context.SaveChangesAsync();

		return entity;
	}

	public async Task<TEntity> UpdateAsync(TEntity entity)
	{
		Context.Set<TEntity>().Update(entity);
		await Context.SaveChangesAsync();

		return entity;
	}

	public async Task DeleteAsync(TEntity entity)
	{
		Context.Set<TEntity>().Remove(entity);
		await Context.SaveChangesAsync();
	}
}
