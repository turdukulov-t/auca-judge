﻿using BusinessBanking.DAL.DataContexts;
using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Repository.Users
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly DataContext _db;

        public UserRepository(DataContext dataContext)
        {
            _db = dataContext;
        }

        public IQueryable<User> GetAll()
        {
            return _db.Users;
        }
    }
}
