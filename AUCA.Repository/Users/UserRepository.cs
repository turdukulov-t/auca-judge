using AUCA.Interface.Repositories;
using AUCA.Repository.Base;
using BusinessBanking.DAL.DataContexts;
using BusinessBanking.Domain.Entity;

namespace BusinessBanking.Repository.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }
    }
}
