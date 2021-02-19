using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ministryofjusticeDomain.Interfaces;

namespace ministryofjusticeWebUi.Controllers
{
   [Authorize]
    public class DashboardController : Controller
    {
        // GET: Dashboard/Index
        public ActionResult Index()
        {
            return View();
        }
    }
}