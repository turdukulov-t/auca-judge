using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUCA.Domain.Entity;
using BusinessBanking.Interface.Repositories;

namespace AUCA.Interface.Repositories;
public interface IProblemRepository : IBaseRepository<Problem>
{
	Task<List<Problem>> GetProblems();

	Task<Problem> GetProblemById(string id);

	Task<Problem> GetProblemByName(string name);
}
