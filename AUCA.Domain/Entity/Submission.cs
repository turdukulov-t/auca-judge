using BusinessBanking.Domain.Entity;

namespace AUCA.Domain.Entity;
public class Submission
{
	public string Id { get; set; }

	public int UserId { get; set; }

	public User User { get; set; }

	public string Path { get; set; }
}