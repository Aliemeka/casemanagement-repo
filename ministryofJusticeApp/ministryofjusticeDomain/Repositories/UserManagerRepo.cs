using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using static System.Web.HttpContext;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using ministryofjusticeDomain.IdentityEntities;
using ministryofjusticeDomain.Interfaces;
namespace ministryofjusticeDomain.Repositories
{
    public class UserManagerRepo : IUserManagerRepo
    {
       
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManagerRepo(ApplicationDbContext context)
        {
            _userManager = Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
      
        /// <summary>
        /// Returns the list of all the users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _userManager.Users.Include(d => d.Department).ToList();
        }


        public IdentityResult CreateUser(ApplicationUser user)
        {
            //generating user email address
            var email = user.FirstName.ToLower() + user.LastName.ToLower() + "@ministryofjustice.com";
            user.Email = email;
            user.UserName = email;

            //generating user password
            var password = user.FirstName.ToLower()+"123@MOJ"; 

            //create user
            var result = _userManager.Create(user, password);
            return result;
        }
    }
}
