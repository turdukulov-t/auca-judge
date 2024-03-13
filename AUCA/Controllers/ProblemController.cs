using System.Net;
using AUCA.Domain.DTO.Problems;
using AUCA.Domain.Entity;
using AUCA.Interface.Services.Problems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AUCA.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ProblemController : ControllerBase
	{
		public IProblemService Service { get; }

		public ProblemController(IProblemService service)
		{
			Service = service;
		}

		[HttpGet("problems/{problemId}", Name = "GetById")]
		public async Task<Problem> GetById(string problemId)
		{
			return await Service.GetByIdAsync(problemId);
		}

		[HttpGet("problems/getbyname/{problemName}", Name = "GetByName")]
		public async Task<Problem> GetByName(string problemName)
		{
			return await Service.GetByNameAsync(problemName);
		}

		[HttpPost("problems/add", Name = "AddProblem")]
		public async Task<Problem> AddProblem(ProblemDto.Add dto)
		{
			return await Service.CreateAsync(dto);
		}

		[HttpPut("problems/update", Name = "UpdateProblem")]
		public async Task<Problem> UpdateProblem(ProblemDto.Edit dto)
		{
			return await Service.UpdateAsync(dto);
		}

		[HttpDelete("problems/delete/", Name = "DeleteProblem")]
		public async Task<HttpStatusCode> DeleteProblem(ProblemDto.Delete dto)
		{
			return await Service.DeleteAsync(dto);
		}
	}
}
