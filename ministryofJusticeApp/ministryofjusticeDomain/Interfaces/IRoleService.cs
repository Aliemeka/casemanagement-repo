using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ministryofjusticeDomain.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<IdentityRole> GetRoles();
        void CreateRoles(string roleName);
        void DeleteRole(string roleName);
        Task<IdentityResult> CreateRoleAsync(string roleName);
        Task<IdentityResult> DeleteRoleAsync(string roleId);
        Task<IdentityResult> AssignRoleAsync(string userId, string roleId);
        Task<IdentityResult> RemoveRoleAsync(string userId, string roleId);
    }
}
