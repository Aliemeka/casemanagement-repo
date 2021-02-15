using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ministryofjusticeDomain.Entities;
using ministryofjusticeDomain.IdentityEntities;
using ministryofjusticeDomain.Interfaces;
using ministryofjusticeWebUi.Models;

namespace ministryofjusticeWebUi.Controllers
{
    [RoutePrefix("/Dashboard/Administration/")]
    [Authorize(Roles = "System Administrator")]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminController()
        {
        }

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Admin
        public ActionResult ManageAccounts()
        {
            var vm = new DashboardViewModel()
            {
                Department = _unitOfWork.DepartmentRepo.GetDepartments(),
                Users = _unitOfWork.UserManagerRepo.GetAllUsers(),
                Roles = _unitOfWork.RoleService.GetRoles()
            };
            return View(vm);
        }

        [HttpGet]
        public ActionResult CreateAccount()
        {
            var vm = new CreateAccountViewModel()
            {
                Department = _unitOfWork.DepartmentRepo.GetDepartments(),
                Roles =  _unitOfWork.RoleService.GetRoles()
            };

           return View(vm);
        }

        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(DepartmentViewModel model)
        {
            try
            {
               var department = Mapper.Map<DepartmentViewModel, Department>(model);
               _unitOfWork.DepartmentRepo.AddDepartment(department); 
               return View("AddDepartment");

            }
            catch (Exception e)
            {
                return View("AddDepartment");
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAccount(CreateAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DepartmentId = model.DepartmentId
                };
                var result = _unitOfWork.UserManagerRepo.CreateUser(user);
                if (result.Succeeded)
                {
                    var roleResult = await _unitOfWork.RoleService.AssignRoleAsync(user.Id, model.RoleId);
                    if (roleResult.Succeeded) return RedirectToAction("ManageAccounts");
                }
            }
            ModelState.AddModelError("", "Error creating account");
            return View(model);
        }
    }
}