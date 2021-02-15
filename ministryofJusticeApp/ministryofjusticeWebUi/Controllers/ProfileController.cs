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
        private readonly IUnitOfWork _unitOfWork;

        public ProfileController()
        {
            
        }

        public ProfileController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

            var result =
                await _unitOfWork.UserManagerRepo.ChangePassword(model.Email, model.OldPassword, model.Password);

            if (result.Succeeded) return RedirectToAction("Index", "Dashboard");

            return View();
        }
    }
}