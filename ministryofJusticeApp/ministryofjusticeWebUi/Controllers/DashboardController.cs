using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ministryofjusticeDomain.Interfaces;

namespace ministryofjusticeWebUi.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Dashboard/Index
        public async Task<ActionResult> Index()
        {
            var user = await _unitOfWork.UserManagerRepo.GetUser(User.Identity.Name);
            ViewBag.fullname = user.FullName;
            return View();
        }
    }
}