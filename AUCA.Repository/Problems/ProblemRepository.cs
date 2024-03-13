using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUCA.Domain.Entity;
using AUCA.Interface.Repositories;
using AUCA.Repository.Base;
using BusinessBanking.DAL.DataContexts;

namespace AUCA.Repository.Problems;
public class ProblemRepository : BaseRepository<Problem>, IProblemRepository
{
	public ProblemRepository(DataContext context) : base(context)
	{
	}
}
