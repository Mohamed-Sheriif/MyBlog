using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models;
namespace MyBlog.Controllers
{
    public class userController : Controller
    {
        BlogContext db = new BlogContext();
        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register(user s , HttpPostedFileBase img)
        {
            user ur = db.users.Where(n => n.email == s.email).FirstOrDefault();
            if(ur != null)
            {
                ViewBag.status = "email exist";
                return View();
            }
            //upload photo
            img.SaveAs(Server.MapPath($"~/attach/{img.FileName}"));

            //modify user photo
            s.photo = img.FileName;

            //save
            if(ModelState.IsValid)
            {
                db.users.Add(s);
                db.SaveChanges();

                return RedirectToAction("Login");
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(user s)
        {
            user ur = db.users.Where(n => n.email == s.email && n.password == s.password).FirstOrDefault();
            if(ur != null)
            {
                //login
                Session.Add("userId", ur.id);
                return RedirectToAction("profile");
            }
            else
            {
                //not login
                ViewBag.status = "incorrect email or password";
                return View();
            }
            
        }
        public ActionResult profile()
        {
            if (Session["userId"] == null) return RedirectToAction("Login");
            
            int id = (int)Session["userId"];
            user u = db.users.Where(n => n.id == id).FirstOrDefault();
            return View(u);
        }
        public ActionResult Logout()
        {
            Session["userId"] = null;
            return RedirectToAction("Login");
        }
        public ActionResult Fprofile(int id)
        {
            user u = db.users.Where(o => o.id == id).FirstOrDefault();
            return View(u);
        }
    }
}