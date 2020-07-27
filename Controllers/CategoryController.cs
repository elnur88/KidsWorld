﻿using KidsWorld.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsWorld.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();
        public ActionResult Index()
        {

            User1 usr = new User1();
            var dgr = (from y in c.Categories
                       join z in c.Categories on y.CategoryId equals z.SubId
                       where y.Status == 0 && z.Status == 0
                       select new User1
                       {
                           UserId = y.UserId,
                           RecordDate = y.RecordDate,
                           User_Id = y.User_Id,
                           UserName1 = y.UserName,
                           FullName = y.FullName,
                           FullAdress = y.FullAdress,
                           UserName = z.UserName,
                           Password = y.Password,
                           Status = y.Status
                       }).Where(y => y.Status == 0).ToList();



            // var dgr = c.Categories.Where(x => x.Status == 0).ToList();
            return View(dgr);

        }


        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category k)
        {
            DateTime today = DateTime.Today;
            k.RecordDate = today;
            k.Status = 0;
            k.SubId = 0;
            //k.User.UserId = 5;
            c.Categories.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FindCategory(int id)
        {
            var usr = c.Categories.Find(id);
            return View("FindCategory", usr);
        }


        public ActionResult DeleteCategory(int id)
        {
            var usr = c.Categories.Find(id);
            usr.Status = 1;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EditCategory(Category k)
        {
            var usr = c.Categories.Find(k.CategoryId);
            usr.Name = k.Name;
            usr.SubId = k.SubId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}