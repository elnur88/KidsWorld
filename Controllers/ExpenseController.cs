using KidsWorld.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsWorld.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var dgr = c.Expenses.Where(x => x.Status == 0).ToList();
            return View(dgr);
        }

        [HttpGet]
        public ActionResult AddExpense()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExpense(Expense k)
        {
            
            k.RecordDate = DateTime.Now;
            k.Status = 0;
            //k.User.UserId = 5;
            c.Expenses.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FindExpense(int id)
        {
            var usr = c.Expenses.Find(id);
            return View("FindExpense", usr);
        }


        public ActionResult DeleteExpense(int id)
        {
            var usr = c.Expenses.Find(id);
            usr.Status = 1;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EditExpense(Expense k)
        {
            var usr = c.Expenses.Find(k.ExpenseId);
            usr.Description = k.Description;
            usr.Amount = k.Amount;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }

   
}