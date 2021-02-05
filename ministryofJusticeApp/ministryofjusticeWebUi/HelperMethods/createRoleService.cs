using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ministryofjusticeWebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ministryofjusticeWebUi.HelperMethods
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
    }
}