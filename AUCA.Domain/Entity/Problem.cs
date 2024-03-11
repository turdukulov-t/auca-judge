using System.ComponentModel.DataAnnotations;

namespace AUCA.Domain.Entity;
public class Problem
{
	public string Id { get; set; }

	[MaxLength(256)]
	public string Name { get; set; }

	[MaxLength(Int32.MaxValue)]
	public string Description { get; set; }

	public int DifficultyId { get; set; }

	public Difficulty Difficulty { get; set; }

	public int CategoryId { get; set; }

	public Category Category { get; set; }

	public ICollection<Submission> Submissions { get; set; } = new List<Submission>();
}