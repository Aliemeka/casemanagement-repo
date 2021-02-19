using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ministryofjusticeDomain.Entities;
using ministryofjusticeDomain.Interfaces;
using ministryofjusticeWebUi.Models;

namespace ministryofjusticeWebUi.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentController()
        {
        }

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Department
        public ActionResult ManageDepartments()
        {
            var vm = _unitOfWork.DepartmentRepo.GetDepartments();
            return View(vm);
        }

        [HttpGet]
        public ActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDepartment(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = Mapper.Map<DepartmentViewModel, Department>(model);
                _unitOfWork.DepartmentRepo.AddDepartment(department);
                RedirectToAction("ManageDepartments");
            }
            return View();
        }
    }
}