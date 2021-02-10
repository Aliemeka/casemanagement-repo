using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ministryofjusticeDomain.Interfaces;

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
    }
}