using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ministryofjusticeWebUi.Controllers
{
   [Authorize(Roles = "System Administrator, Attorney General, Director of Department, Lawyer")]
    public class DashboardController : Controller
    {
        // GET: Dashboard/Index
        public ActionResult Index()
        {
            return View();
        }
    }
}