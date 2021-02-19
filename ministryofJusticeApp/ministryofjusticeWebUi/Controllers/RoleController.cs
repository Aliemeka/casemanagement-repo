using System.Web.Mvc;
using ministryofjusticeDomain.Interfaces;

namespace ministryofjusticeWebUi.Controllers
{
    public class RoleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleController()
        {
        }

        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Role
        public ActionResult ManageRoles()
        {
            var roles = _unitOfWork.RoleService.GetRoles();
            return View(roles);
        }

        public ActionResult CreateRole()
        {
            return View();
        }
    }
}