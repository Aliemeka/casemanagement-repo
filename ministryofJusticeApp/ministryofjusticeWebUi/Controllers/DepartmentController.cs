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
        [ValidateAntiForgeryToken]
        public ActionResult CreateDepartment(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = Mapper.Map<DepartmentViewModel, Department>(model);
                _unitOfWork.DepartmentRepo.AddDepartment(department);
                return RedirectToAction("ManageDepartments");
            }

            return View();
        }

        [HttpGet]
        public ActionResult UpdateDepartment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateDepartment(DepartmentViewModel model)
        {
            var departmentInDb = _unitOfWork.DepartmentRepo.GetDepartment(model.Id);
            if (departmentInDb == null)
                return HttpNotFound("There is no department found");
            var department = Mapper.Map(model, departmentInDb);
            _unitOfWork.DepartmentRepo.UpdateDepartment(department);
            return View("UpdateDepartment");
        }
    }
}