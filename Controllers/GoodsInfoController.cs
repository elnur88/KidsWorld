using KidsWorld.Models.Class;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;
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
            k.GoodsPhoto.PhotoId = 1;
            c.GoodsInfos.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
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
            usr.PurchasePrice = k.PurchasePrice;
            usr.SalePrice = k.SalePrice;
            usr.Size = k.Size;
            usr.Color = k.Color;
            usr.Count = k.Count;
            usr.Barcode = k.Barcode;
            usr.Description = k.Description;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}