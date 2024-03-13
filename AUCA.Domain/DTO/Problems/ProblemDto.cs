using System.ComponentModel.DataAnnotations;

namespace AUCA.Domain.DTO.Problems;

public record ProblemDto
{
	public abstract record Base
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public int DifficultyId { get; set; }

		[Required]
		public int CategoryId { get; set; }
	}

	public record Add : Base
	{
	}

	public record Edit : Base
	{
		public string Id { get; set; }
	}

	public record Get : Base
	{
		public string Id { get; set; }
	}

	public record Delete
	{
		public string Id { get; set; }
	}
}



