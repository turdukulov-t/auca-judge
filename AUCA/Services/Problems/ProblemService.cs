using System.Net;
using AUCA.Domain.DTO.Problems;
using AUCA.Domain.Entity;
using AUCA.Interface.Services.Problems;
using BusinessBanking.Interface.Repositories;
using Mapster;

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
			var problems = await Repository.GetAll<Problem>();

			return problems.ToList();
		}

		public async Task<Problem> GetByIdAsync(string id)
		{
			return await Repository.GetByPredicateAsync(x => x.Id == id);
		}

		public async Task<Problem> GetByNameAsync(string name)
		{
			return await Repository.GetByPredicateAsync(x => x.Name == name);
		}

		public async Task<Problem> CreateAsync(ProblemDto.Add dto)
		{
			var entity = dto.Adapt<Problem>();

			return await Repository.CreateAsync(entity);
		}

		public async Task<Problem> UpdateAsync(ProblemDto.Edit dto)
		{
			var entity = dto.Adapt<Problem>();

			return await Repository.UpdateAsync(entity);
		}

		public async Task<HttpStatusCode> DeleteAsync(ProblemDto.Delete dto)
		{
			var entity = await GetByIdAsync(dto.Id);
			await Repository.DeleteAsync(entity);

			return HttpStatusCode.OK;
		}
	}
}
