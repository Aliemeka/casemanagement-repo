using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ministryofjusticeWebUi.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            if (User.IsInRole("System Administrator") 
                || User.IsInRole("Attorney General")
                || User.IsInRole("Director of Department")
                || User.IsInRole("Lawyer"))
                return RedirectToAction("Index", "Dashboard");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}