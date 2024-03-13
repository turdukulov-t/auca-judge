namespace AUCA.Domain.DTO.Users
{
    public class UserCreateDto
    {
        public int UniversityID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
