using System.Net;
using AUCA.Domain.DTO.Problems;
using AUCA.Domain.DTO.Users;
using AUCA.Domain.Entity;
using AUCA.Utils;
using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Repositories;
using BusinessBanking.Interface.Services.Users;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BusinessBanking.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;

        public UserService(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByLogin(string login)
        {
            return await _userRepository.GetByPredicateAsync(x => x.Login == login);
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _userRepository.GetAll<User>();

            return users.ToList();
        }

        public async Task<User> CreateAsync(UserCreateDto dto)
        {
            var checkLogin = await IsDataValid(dto.Login, dto.UniversityID, dto.Email);

            if (!checkLogin)
            {
                return null;
            }

            var user = new User()
            {
                UniversityID = dto.UniversityID,
                Login = dto.Login,
                Password = Encryption.Encrypt(dto.Password),
                CreatedDate = DateTime.Now,
                Email = dto.Email,
                IsEnabled = true
            };

            return await _userRepository.CreateAsync(user);
        }

        public async Task<User> UpdateAsync(UserUpdateDto dto)
        {
            var checkData = await IsDataValidUpdate(dto.Id, dto.Login, dto.UniversityID, dto.Email);

            if (!checkData)
            {
                return null;
            }

            var user = await _userRepository.GetByPredicateAsync(x => x.ID == dto.Id);

            user.UniversityID = dto.UniversityID;
            user.Login = dto.Login;
            user.Email = dto.Email;

            return await _userRepository.UpdateAsync(user);
        }

        public async Task<HttpStatusCode> DeleteAsync(int id)
        {
            var user = await _userRepository.GetByPredicateAsync(x => x.ID == id);

            user.IsEnabled = false;

            await _userRepository.UpdateAsync(user);

            return HttpStatusCode.OK;
        }

        private async Task<bool> IsDataValid(string login, int UniversityID, string email)
        {
            var user = await _userRepository.GetByPredicateAsync(x => x.Login == login
            || x.UniversityID == UniversityID || x.Email == email);

            if (user == null)
            {
                return true;
            }

            return false;
        }

        private async Task<bool> IsDataValidUpdate(int id, string login, int UniversityID, string email)
        {
            var user = await _userRepository.GetByPredicateAsync(x => x.Login == login
            || x.UniversityID == UniversityID || x.Email == email);

            if (user == null || user.ID == id)
            {
                return true;
            }

            return false;
        }
    }
}
