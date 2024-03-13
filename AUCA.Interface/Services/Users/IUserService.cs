using AUCA.Domain.DTO.Users;
using BusinessBanking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Interface.Services.Users
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserByLogin(string login);
        Task<User> CreateAsync(UserCreateDto dto);
        Task<User> UpdateAsync(UserUpdateDto dto);
        Task<HttpStatusCode> DeleteAsync(int id);
    }
}
