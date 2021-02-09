using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ministryofjusticeDomain.Entities;
using ministryofjusticeDomain.Interfaces;

namespace ministryofjusticeDomain.Repositories
{
    class UserManagerRepo : IUserManagerRepo
    {
        private readonly ApplicationDbContext _context;

        public UserManagerRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public ApplicationUser CreateUser(ApplicationUser user)
        {
            _context.Users.Add(user);
            return user;
        }

        public ApplicationUser DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            return user;
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _context.Users;
        }

        public void AssignRole(ApplicationUser user, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
