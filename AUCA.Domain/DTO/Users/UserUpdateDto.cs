namespace AUCA.Domain.DTO.Users
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public int UniversityID { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }
}
