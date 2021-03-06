﻿using KidsWorld.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Context = KidsWorld.Models.Class.Context;

namespace KidsWorld.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var dgr = c.Orders.Where(x => x.Status == 0).ToList();
            return View(dgr);
        }

        public ActionResult TesdiqIndex()
        {
            var dgr = c.Orders.Where(x => x.Status == 2).ToList();
            return View(dgr);
        }
        public ActionResult RemoveIndex()
        {
            var dgr = c.Orders.Where(x => x.Status == 1).ToList();
            return View(dgr);
        }

        public ActionResult SaleOrderIndex()
        {
            var dgr = c.Orders.Where(x => x.Status == 3).ToList();
            return View(dgr);
        }
        [HttpGet]
        public ActionResult AddOrder()
        {
            List<SelectListItem> usercombo = (from x in c.Users.Where(x => x.Status == 0).ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.UserName,
                                                  Value = x.UserId.ToString()
                                              }).ToList();
            ViewBag.dgr1 = usercombo;
            return View();
        }
        [HttpPost]
        public ActionResult AddOrder(Order k)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("AddOrder");
            //}
            k.RecordDate = DateTime.Now;
            k.Status = 0;
            c.Orders.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FindOrder(int id)
        {
            var usr = c.Orders.Find(id);
            return View("FindOrder", usr);
        }

        public ActionResult DeleteOrder(int id)
        {
            var usr = c.Orders.Find(id);
            usr.RecordDate = DateTime.Now;
            usr.Status = 1;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TesdiqOrder(int id)
        {
            var usr = c.Orders.Find(id);
            usr.RecordDate = DateTime.Now;
            usr.Status = 2;
            c.SaveChanges();
            return RedirectToAction("TesdiqIndex");
        }

        public ActionResult SaleOrder(int id)
        {
            var usr = c.Orders.Find(id);
            usr.RecordDate = DateTime.Now;
            usr.Status = 3;
            c.SaveChanges();
            return RedirectToAction("SaleOrderIndex");
        }

        public ActionResult EditOrder(Order k)
        {
            if (!ModelState.IsValid)
            {
                return View("FindOrder");
            }
            var usr = c.Orders.Find(k.OrderId);
            usr.RecordDate = DateTime.Now;
            usr.Count = k.Count;
            usr.SalePrice = k.SalePrice;
            usr.TotalPrice = k.TotalPrice;
            usr.City = k.City;
            usr.ZipCode = k.ZipCode;
            usr.Phone = k.Phone;
            usr.Adress = k.Adress;
            usr.Email = k.Email;
            usr.Barcode = k.Barcode;
            usr.State = 1;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}