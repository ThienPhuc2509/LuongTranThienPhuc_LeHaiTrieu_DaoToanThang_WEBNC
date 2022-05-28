using DOAN_THWEB_NC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAN_THWEB_NC.Controllers
{
    public class AdminController : Controller
    {
        DB_Shop2Entities3 _db = new DB_Shop2Entities3();
        // GET: Admin
        public ActionResult Index()
        {
            return View(_db.Products.ToList());
        }
    }
}