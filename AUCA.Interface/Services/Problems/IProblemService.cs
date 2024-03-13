using BusinessBanking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUCA.Domain.Entity;

namespace AUCA.Interface.Services.Problems;
public interface IProblemService
{
	Task<List<Problem>> GetProblems();
}
