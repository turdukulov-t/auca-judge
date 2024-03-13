using AUCA.Domain.Entity;
using AUCA.Interface.Services.Problems;
using AUCA.Repository.Problems;
using BusinessBanking.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AUCA.Services.Problems
{
	public class ProblemService : IProblemService
	{
		private IBaseRepository<Problem> Repository { get; }

		public ProblemService(IBaseRepository<Problem> repository)
		{
			Repository = repository;
		}

		public async Task<List<Problem>> GetProblems()
		{
			return await Repository.GetAll().ToListAsync();
		}
	}
}
