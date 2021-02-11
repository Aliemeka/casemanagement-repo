using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ministryofjusticeDomain.Entities;
using ministryofjusticeDomain.Interfaces;
using ministryofjusticeWebUi.Models;

namespace ministryofjusticeWebUi.Controllers
{
    [RoutePrefix("/Dashboard/Administration/")]
    [Authorize(Roles = "System Administrator")]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Admin
        public ActionResult ManageAccounts()
        {
            var model = _unitOfWork.UserManagerRepo.GetAllUsers();
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAccount(CreateAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
                var result = _unitOfWork.UserManagerRepo.CreateUser(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ManageAccounts");
                }
            }
            ModelState.AddModelError("", "Error creating account");
            return View(model);
        }
    }
}