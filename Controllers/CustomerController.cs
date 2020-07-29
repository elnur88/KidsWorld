using KidsWorld.Models.Class;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsWorld.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var dgr = c.Customers.Where(x => x.Status == 0).ToList();
            return View(dgr);
        }
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer k)
        {
            k.RecordDate = DateTime.Now;
            c.Customers.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FindCustomer(int id)
        {
            var usr = c.Customers.Find(id);
            return View("FindCustomer", usr);
        }

        public ActionResult DeleteCustomer(int id)
        {
            var usr = c.Customers.Find(id);
            usr.Status = 1;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditCustomer(Customer k)
        {
            var usr = c.Customers.Find(k.CustomerId);
            usr.FullName = k.FullName;
            usr.City = k.City;
            usr.ZipCode = k.ZipCode;
            usr.Phone = k.Phone;
            usr.Adress = k.Adress;
            usr.Email = k.Email;
            usr.Password = k.Password;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}