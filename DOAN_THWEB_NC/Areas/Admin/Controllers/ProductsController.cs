using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using DOAN_THWEB_NC.DesignPattern.ProxyPattern;
using System.Web.Mvc;
using DOAN_THWEB_NC.Models;

namespace DOAN_THWEB_NC.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private DB_Shop2Entities3 db = new DB_Shop2Entities3();

        // GET: Admin/Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            Product product = new Product();
            ViewBag.IDCategory = new SelectList(db.Categories, "IDCategories", "NameCategory");

            return View(product);

        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (product.ImageUpload != null)
                    {
                        string filename = Path.GetFileNameWithoutExtension(product.ImageUpload.FileName);
                        string extension = Path.GetExtension(product.ImageUpload.FileName);
                        filename = filename + extension;
                        product.Images = "~/Public/img/Product/" + filename;
                        product.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/img/Product/"), filename));

                    }
                    SanPham sanPham = new SanPhamProxyPattern(product);
                    sanPham.AddSanPham();
                    return RedirectToAction("Index");

                }

             
              
            }
            catch
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");

            }
          
            ViewBag.IDCategory = new SelectList(db.Categories, "IDCategories", "NameCategory", product.IDCategory);
            return View(product);

        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCategory = new SelectList(db.Categories, "IDCategories", "NameCategory", product.IDCategory);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ImageUpload != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(product.ImageUpload.FileName);
                    string extension = Path.GetExtension(product.ImageUpload.FileName);
                    filename = filename + extension;
                    product.Images = "~/Public/img/Product/" + filename;
                    product.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/img/Product/"), filename));

                }
                SanPham sanPham = new SanPhamProxyPattern(product);
                sanPham.EditSanPham();
                return RedirectToAction("Index");
            }
            ViewBag.IDCategory = new SelectList(db.Categories, "IDCategories", "NameCategory", product.IDCategory);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                SanPham sanPham = new SanPhamProxyPattern(id);
                sanPham.RemoveSanPham();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
