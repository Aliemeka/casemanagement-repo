using System;
using System.Collections.Generic;
using System.Text;
using ministryofjusticeDomain.Entities;

namespace ministryofjusticeDomain.Interfaces
{
    public interface IUserManagerRepo
    {
        IEnumerable<ApplicationUser> GetAllUsers();
        void AssignRole(ApplicationUser user, string roleName);
    }
}
