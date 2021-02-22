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
            var vm = _unitOfWork.DepartmentRepo.GetAll();
            return View(vm);
        }

        [HttpGet]
        public ActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDepartment(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = Mapper.Map<DepartmentViewModel, Department>(model);
                _unitOfWork.DepartmentRepo.Insert(department);
                _unitOfWork.DepartmentRepo.Save();
                TempData["Message"] = "Department Created Successfully";
                return View("CreateDepartment");
            }

            return View();
        }

        [HttpGet]
        public ActionResult UpdateDepartment(int id)
        {
            Department department = _unitOfWork.DepartmentRepo.GetById(id);
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateDepartment(DepartmentViewModel model)
        {
            var departmentInDb = _unitOfWork.DepartmentRepo.GetById(model.Id);
            if (departmentInDb == null)
                return HttpNotFound("There is no department found");
            var department = Mapper.Map(model, departmentInDb);
            _unitOfWork.DepartmentRepo.Update(department);
            _unitOfWork.DepartmentRepo.Save();
            TempData["Message"] = "Department Updated Successfully";
            return View("UpdateDepartment");
        }
    }
}