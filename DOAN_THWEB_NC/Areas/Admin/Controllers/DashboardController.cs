using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAN_THWEB_NC.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }
         public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", new { controller = "Home", area = string.Empty });

        }
    }
}