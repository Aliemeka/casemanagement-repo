using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public UserManagerRepo()
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
            //var existUser = _userManager.FindByEmail(user.Email);
            //if (existUser != null)
            //{
              //  string[] errors = new[] {"Email is already registered!"};
                //return IdentityResult.Failed(errors);

            //}
            user.UserName = user.Email;

            //generating user password
            var password = user.FirstName.ToLower()+"123@MOJ"; 

            //create user
            var result = _userManager.Create(user, password);
            if (!result.Succeeded)
            {
                string[] errors = new[] { $"Email '{user.Email}' is already registered!"};
                return IdentityResult.Failed(errors);
            }
            return result;
        }

        public async Task<ApplicationUser> GetUser(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> ChangePassword(string email, string oldPassword, string newPassword)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user.Id, oldPassword, newPassword);
                return result;
            }
            return IdentityResult.Failed();
        }
    }
}
