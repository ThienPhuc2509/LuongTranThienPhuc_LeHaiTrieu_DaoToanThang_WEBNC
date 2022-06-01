using DOAN_THWEB_NC.Models;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAN_THWEB_NC.Controllers
{
    public class ProductDetailController : Controller
    {
        DB_Shop2Entities3 _db = new DB_Shop2Entities3();
        // GET: ProductDetail
        public ActionResult Index(int Id)
        {
            var obj=_db.Products.Where(s=>s.IDProduct==Id).FirstOrDefault();
            var node = SiteMaps.Current.CurrentNode;

            if (node != null && node.ParentNode != null)

            {

                node.ParentNode.Title = obj.NameProduct;

            }
            return View(obj);
            

        }
    }
}