using AUCA.Utils;
using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Services.Auth;
using BusinessBanking.Interface.Services.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BusinessBanking.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthService(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public async Task<string> GenerateToken(string login, string password)
        {
            var isValid = await IsUserValid(login, password);

            if (isValid)
            {
                var user = await _userService.GetUserByLogin(login);

                var universityID = user.UniversityID;

                List<Claim> claims = new List<Claim>
                {
                    new Claim("universityID", universityID.ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:SecretKey").Value!));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var header = new JwtHeader(signingCredentials: creds);
                var payload = new JwtPayload(
                    "example.com", 
                    "example.com", 
                    claims, 
                    null, 
                    expires: DateTime.Now.AddMinutes(20),
                    issuedAt: DateTime.Now
                );

                var token = new JwtSecurityToken(header, payload);

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> IsUserValid(string login, string password)
        {
            var user = await _userService.GetUserByLogin(login);

            if (user == null || !user.IsEnabled)
            {
                return false;
            }

            var encrypted = Encryption.Encrypt(password);
            return user.Password == encrypted;
        }
    }
}
