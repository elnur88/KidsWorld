using KidsWorld.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsWorld.Controllers
{
    public class SignController : Controller
    {
        Context c = new Context();
        // GET: Sign
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(User k)
        {
            DateTime today = DateTime.Today;
            k.RecordDate = today;
            k.User_Id = 1;
            c.Users.Add(k);
            c.SaveChanges();
            return RedirectToAction("EnterLogin", "Login",new { area = ""});
        }

    }
}