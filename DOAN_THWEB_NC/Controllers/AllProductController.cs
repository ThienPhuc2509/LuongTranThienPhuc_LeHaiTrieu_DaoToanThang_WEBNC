using DOAN_THWEB_NC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAN_THWEB_NC.Controllers
{
    public class AllProductController : Controller
    {
        DB_Shop2Entities3 _db = new DB_Shop2Entities3();
        // GET: AllProduct
        public ActionResult Index(int IDCategories = 0, string SearchString = "")
        {
            if (SearchString != "")
            {
                return View(_db.Products.Where(x => x.NameProduct.ToUpper().Contains(SearchString.ToUpper())));
            }
            else if (IDCategories == 0)
            {
                return View(_db.Products.ToList());
            }
            else
            {
                return View(_db.Products.Where(s => s.Category.IDCategories == IDCategories).ToList());
            }
        }
    }
}