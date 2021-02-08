using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ministryofjusticeDomain.Entities;

namespace ministryofjusticeDomain.Services
{
    public class CreateRoleService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateRoleService(ApplicationDbContext context)
        {
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
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
                _roleManager.Create(role);
            }
        }

        // Method to delete roles
        public async Task DeleteRole(string roleName)
        {
            var del=_roleManager.FindByName(roleName);
            await _roleManager.DeleteAsync(del);
        }
    }
}