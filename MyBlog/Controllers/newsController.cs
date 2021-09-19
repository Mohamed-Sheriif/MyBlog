using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class newsController : Controller
    {
        BlogContext DB = new BlogContext();
        public ActionResult add()
        {
            if (Session["userId"] == null) return RedirectToAction("Login", "user");
            SelectList n = new SelectList(DB.catalogs.ToList(), "ID", "name");
            ViewBag.cat = n;
            return View();
        }
        [HttpPost]
        public ActionResult add(news n ,  HttpPostedFileBase img)
        {
            img.SaveAs(Server.MapPath($"~/attach/newsphoto/{img.FileName}"));
            n.photo = img.FileName;
            n.date = DateTime.Now;
            n.user_id = (int)Session["userId"];

            DB.news.Add(n);
            DB.SaveChanges();

            return RedirectToAction("MyNews");
        }

        public ActionResult MyNews()
        {
            if (Session["userId"] == null) return RedirectToAction("Login", "user");
            int userId =(int)Session["userId"];
            List<news> ne = DB.news.Where(n => n.user_id == userId).ToList();

            return View(ne);
        }
        public ActionResult details(int id)
        {
            if (Session["userId"] == null) return RedirectToAction("LogIn");
            news n = DB.news.Where(o => o.user_id == id).FirstOrDefault();

            return View(n);  
        }
        public ActionResult AllNews()
        {
            if (Session["userID"] == null) return RedirectToAction("Login" , "user");
            return View(DB.news.ToList());
        }
    }
}