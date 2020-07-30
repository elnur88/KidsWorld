using KidsWorld.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace KidsWorld.Controllers
{
    public class GoodsInfoController : Controller
    {
        // GET: GoodsInfo
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {


            var dgr = c.GoodsInfos.Where(x => x.Status == 0).ToList();
            return View(dgr);

        }
        [HttpGet]
        public ActionResult AddGoodsInfo()
        {
            List<SelectListItem> usercombo = (from x in c.Users.Where(x => x.Status == 0).ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.UserName,
                                                  Value = x.UserId.ToString()
                                              }).ToList();
            ViewBag.dgr1 = usercombo;

            List<SelectListItem> categorycombo = (from x in c.Categories.Where(x => x.Status == 0).ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.CategoryId.ToString()
                                              }).ToList();
            ViewBag.dgr2 = categorycombo;


            return View();
        }
        [HttpPost]
        public ActionResult AddGoodsInfo(GoodsInfo k)
        {
            
            k.RecordDate = DateTime.Now ;
            k.Status = 0;
            //k.GoodsPhoto.PhotoId = 1;
            c.GoodsInfos.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult FindGoodsInfo()
        {
            List<SelectListItem> usercombo = (from x in c.Users.Where(x => x.Status == 0).ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.UserName,
                                                  Value = x.UserId.ToString()
                                              }).ToList();
            ViewBag.dgr3 = usercombo;

            List<SelectListItem> categorycombo = (from x in c.Categories.Where(x => x.Status == 0).ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.dgr4 = categorycombo;


            return View();
        }
        public ActionResult FindGoodsInfo(int id)
        {
            var usr = c.GoodsInfos.Find(id);
            return View("FindGoodsInfo", usr);
        }

        public ActionResult DeleteGoodsInfo(int id)
        {
            var usr = c.GoodsInfos.Find(id);
            usr.Status = 1;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EditGoodsInfo(GoodsInfo k)
        {
            var usr = c.GoodsInfos.Find(k.GoodsInfoId);
            usr.Name = k.Name;
            usr.Description = k.Description;
            usr.Size = k.Size;
            usr.Color = k.Color;
            usr.Count = k.Count;
            usr.PurchasePrice = k.PurchasePrice;
            usr.SalePrice = k.SalePrice;
            usr.Barcode = k.Barcode;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}