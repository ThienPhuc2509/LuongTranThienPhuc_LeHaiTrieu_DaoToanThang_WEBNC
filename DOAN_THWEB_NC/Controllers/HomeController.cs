using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOAN_THWEB_NC.Models;

namespace DOAN_THWEB_NC.Controllers
{
    public class HomeController : Controller
    {

        DB_Shop2Entities3 _db =new DB_Shop2Entities3();

        // GET: Home

        public ActionResult Index(int IDCategories = 0, string SearchString="")
        {
            if (SearchString != "")
            {
                return View(_db.Products.Where(x => x.NameProduct.ToUpper().Contains(SearchString.ToUpper())));
            }
            else /*if (IDCategories == 0)*/
            {
                return View(_db.Products.ToList());
            }
            //else
            //{
            //    return View(_db.Products.Where(s => s.Category.IDCategories == IDCategories).ToList());
            //}
        }
        [HttpGet]
        public ActionResult Sginup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Sginup(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = _db.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.Users.Add(_user);
                    _db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Email đã tồn tại!";
                    return View();
                }
                
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult Login(User _user)
        {
                var obj = _db.Users.Where(s => s.Email.Equals(_user.Email)
                  && s.Password.Equals(_user.Password)).FirstOrDefault(); 
                if (obj == null)
                {
                ViewBag.error = "Email hoặc mật khẩu không đúng";
                return View("Login");
                }
                else
                {
                var test = _db.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (test.Email != "admin@gmail.com")
                {
                    
                    Session["IDUser"] = _user.IDUser;
                    Session["Email"] = _user.Email;
                    return RedirectToAction("Index");
                }
                else
                {
                    Session["IDUser"] = _user.IDUser;
                    Session["Email"] = _user.Email;
                    return RedirectToAction("Dashboard", "Admin");
                }
                
                }  
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
        public ActionResult ProductCategory(int Id)
        {
            var list = _db.Products.Where(n => n.IDCategory == Id).ToList();
            return View(list);
        }
    }
}