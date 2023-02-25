using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implement
{
    public class UserRepository : IUserRepository
    {
        private DbSet<User> _dbSet;

        public UserRepository(EStoreDBContext eStoreDBContext)
        {
            _dbSet = eStoreDBContext.users;
        }
        public User Login(string username, string password)
        {
            var result = _dbSet.Include(user => user.UserRole).ThenInclude(role => role.Pemissions).FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));

            return result;
        }
    }
}
