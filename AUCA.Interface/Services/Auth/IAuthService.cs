namespace BusinessBanking.Interface.Services.Auth
{
    public interface IAuthService
    {
        Task<string> GenerateToken(string login, string password);

        Task<bool> IsUserValid(string login, string password);
    }
}
