using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ministryofjusticeDomain.Entities;
using System.Threading.Tasks;

namespace ministryofjusticeDomain.Services
{
    /// <summary>
    /// Service reponsible for adding roles, deleting roles and assigning roles
    /// </summary>
    public class RoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(ApplicationDbContext context)
        {
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }

        /// <summary>
        /// Method to create roles
        /// </summary>
        /// <param name="roleName"></param>
        public void CreateRoles(string roleName)
        {
            if (!_roleManager.RoleExists(roleName))
            {
                var role = new IdentityRole();
                role.Name = roleName;
                _roleManager.CreateAsync(role);
            }
        }

        /// <summary>
        /// Method to delete roles
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public async Task DeleteRole(string roleName)
        {
            if (_roleManager.RoleExists(roleName))
            {
                var del=_roleManager.FindByName(roleName);
                await _roleManager.DeleteAsync(del);
            }
        }
    }
}