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
            var dgr = c.Customers.ToList();
            return View(dgr);
        }
    }
}