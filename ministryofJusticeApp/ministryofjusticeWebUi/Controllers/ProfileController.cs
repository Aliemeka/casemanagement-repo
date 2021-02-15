using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using ministryofjusticeDomain.Interfaces;
using ministryofjusticeWebUi.Models;

namespace ministryofjusticeWebUi.Controllers
{
    public class ProfileController : Controller
    {
        private ApplicationUserManager _userManager;

        public ProfileController()
        {
        }

        public ProfileController(ApplicationUserManager userManager, ApplicationRoleManager roleManager, IUnitOfWork unitOfWork)
        {
            UserManager = userManager;
            RoleManager = roleManager;
            _unitOfWork = unitOfWork;
        }

        private readonly IUnitOfWork _unitOfWork;
        private ApplicationRoleManager _roleManager;

        public ApplicationUserManager UserManager
        {
            get { return _userManager; }
            private set
            {
                _userManager = value;
            }
        }


        public ApplicationRoleManager RoleManager
        {
            get { return _roleManager; }
            private set
            {
                _roleManager = value;
            }
        }

        // GET: Profile
        public ActionResult UpdateProfile()
        {
            return View();
        }

        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateProfile(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user != null)
            {
                user.EmailConfirmed = true;
                var result = UserManager.ChangePasswordAsync(user.Id, model.OldPassword, model.Password);
                
                if(result.Result.Succeeded) RedirectToAction("Index", "Dashboard");
            }
            return View();
        }
    }
}