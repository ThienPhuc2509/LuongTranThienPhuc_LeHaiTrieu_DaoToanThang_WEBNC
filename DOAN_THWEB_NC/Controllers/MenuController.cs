using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using DOAN_THWEB_NC.Models;

namespace DOAN_THWEB_NC.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            using (DB_Shop2Entities3 db = new DB_Shop2Entities3())
            {
                var Loaisp = db.Categories.ToList();
                Hashtable tenloaisp = new Hashtable();
                foreach (var item in Loaisp)
                {
                    tenloaisp.Add(item.IDCategories, item.ImagesCategory);    
                    //tenloaisp.Add(item.IDCategories, item.ImagesCategory);
                }
                ViewBag.TenLoaiSP = tenloaisp;
                return PartialView("Index");
            }

        }
    }
}