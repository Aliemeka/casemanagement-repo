using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ministryofjusticeDomain.Entities;
using ministryofjusticeDomain.IdentityEntities;
using ministryofjusticeDomain.Interfaces;
using ministryofjusticeWebUi.Models;

namespace ministryofjusticeWebUi.Controllers
{
    [Authorize]
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
        public async Task<ActionResult> UpdateProfile()
        {
            var user = await _unitOfWork.UserManagerRepo.GetUser(User.Identity.Name);
            var vm = Mapper.Map<ApplicationUser, ProfileViewModel>(user);
            return View(vm);
        }

        // POST: /Account/ResetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateProfile(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result =
                await _unitOfWork.UserManagerRepo.ChangePassword(model.Email, model.OldPassword, model.Password);

            if (result.Succeeded)
            {
                var user = Mapper.Map<ProfileViewModel, ApplicationUser>(model);
                if (User.IsInRole("Lawyer"))
                {
                    var lawyer = Mapper.Map<ProfileViewModel, Lawyer>(model);
                    _unitOfWork.ProfileRepo.UpdateProfile(user, lawyer);
                } 
                else if (User.IsInRole("Attorney General"))
                {
                    var ag = new AttorneyGeneral();
                    _unitOfWork.ProfileRepo.UpdateProfile(user, null, ag);
                }
                else if (User.IsInRole("Director of Department"))
                {
                    var hod = new DepartmentHead();
                    _unitOfWork.ProfileRepo.UpdateProfile(user, null, null, hod);
                }
                else 
                    _unitOfWork.ProfileRepo.UpdateProfile(user);
                return RedirectToAction("Index", "Dashboard");
            };

            result.Errors.ForEach(error => ModelState.AddModelError("", error));
            return View(model);
        }
    }
}