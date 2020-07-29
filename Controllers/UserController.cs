﻿using KidsWorld.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace KidsWorld.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            
            var dgr = (from y in c.Users
                       join z in c.Users on y.UserId equals z.User_Id
                       where y.Status == 0 && z.Status==0
                       select new User1
                       {
                           UserId= z.UserId,
                           RecordDate= z.RecordDate,
                           User_Id= y.User_Id,
                           UserName1 = y.UserName,
                           FullName= z.FullName,
                           FullAdress= z.FullAdress,
                           Email= y.Email,
                           UserName = z.UserName,
                           Password= z.Password,
                           Status =z.Status
                       }).Where(y => y.Status == 0).ToList();
           // var dgr = c.Users.Where(x => x.Status == 0).ToList();
           
            return View(dgr);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            List<SelectListItem>  usercombo = (from x in c.Users.Where(x=>x.Status==0).ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UserName,
                                             Value = x.UserId.ToString()
                                         }).ToList();
            ViewBag.dgr1 = usercombo;
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User k)
        {
            if (!ModelState.IsValid)
            {
                return View("AddUser");
            }
            k.RecordDate = DateTime.Now;
            k.User_Id = 1;
            c.Users.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FindUser(int id)
        {
            var usr = c.Users.Find(id);
            return View("FindUser", usr);
        }


        public ActionResult DeleteUser(int id)
        {
            var usr = c.Users.Find(id);
            usr.Status = 1;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EditUser(User k)
        {
            if(!ModelState.IsValid)
            {
                return View("FindUser");
            }
            var usr = c.Users.Find(k.UserId);
            usr.FullName = k.FullName;
            usr.FullAdress = k.FullAdress;
            usr.Email = k.Email;
            usr.Password = k.Password;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}