using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ministryofjusticeDomain.Entities;

namespace ministryofjusticeDomain.Interfaces
{
    public interface IUserManagerRepo
    {
        IEnumerable<ApplicationUser> GetAllUsers();
        IEnumerable<IdentityRole> GetRoles();
        Task<IdentityResult> CreateRoleAsync(string roleName);
        Task<IdentityResult> DeleteRoleAsync(string roleId);
        Task<IdentityResult> AssignRoleAsync(string userId, string roleId);
        Task<IdentityResult> RemoveRoleAsync(string userId, string roleId);
    }
}
