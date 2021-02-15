using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ministryofjusticeDomain.Entities;
using ministryofjusticeDomain.IdentityEntities;

namespace ministryofjusticeDomain.Interfaces
{
    public interface IUserManagerRepo
    {
        IEnumerable<ApplicationUser> GetAllUsers();
        IdentityResult CreateUser(ApplicationUser user);
    }
}
