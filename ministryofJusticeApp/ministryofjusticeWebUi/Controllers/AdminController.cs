using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ministryofjusticeWebUi.Controllers
{
    [RoutePrefix("/Dashboard/Administration/")]
    [Authorize(Roles = "System Administrator")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult ManageAccounts()
        {
            return View();
        }
    }
}