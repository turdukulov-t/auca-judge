using BusinessBanking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AUCA.Domain.DTO.Problems;
using AUCA.Domain.Entity;

namespace AUCA.Interface.Services.Problems;
public interface IProblemService
{
	Task<List<Problem>> GetProblems();

	Task<Problem> GetByIdAsync(string id);

	Task<Problem> GetByNameAsync(string name);

	Task<Problem> CreateAsync(ProblemDto.Add dto);

	Task<Problem> UpdateAsync(ProblemDto.Edit dto);

	Task<HttpStatusCode> DeleteAsync(ProblemDto.Delete id);
}
