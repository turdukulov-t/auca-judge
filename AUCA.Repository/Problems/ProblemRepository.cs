using AUCA.Domain.Entity;
using AUCA.Domain.Exceptions;
using AUCA.Interface.Repositories;
using BusinessBanking.DAL.DataContexts;
using BusinessBanking.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AUCA.Repository.Problems;
public class ProblemRepository : IBaseRepository<Problem>
{
	private DataContext Context { get; set; }

	public ProblemRepository(DataContext context)
	{
		Context = context;
	}

	public IQueryable<Problem> GetAll()
	{
		return Context.Set<Problem>().AsQueryable();
	}

	public async Task<Problem> GetProblemById(string id)
	{
		var problem = await Context.Set<Problem>().FirstOrDefaultAsync(x => x.Id == id);
		
		if (problem == null)
		{
			throw new InnerException("No problem found by this Id", 1);
		}

		return problem;
	}

	public async Task<Problem> GetProblemByName(string name)
	{
		var problem = await Context.Set<Problem>().FirstOrDefaultAsync(x => x.Name == name);

		if (problem == null)
		{
			throw new InnerException("No problem found by this name", 2);
		}

		return problem;
	}
}
