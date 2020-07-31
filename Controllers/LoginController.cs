using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidsWorld.Models.Class;
using System.Web.Security;


namespace KidsWorld.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        // GET: Login
        public ActionResult EnterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EnterLogin(User u)
        {
            var _Password = KidsWorld.Models.Class.encryptPassword.textToEncrypt(u.Password);

            var dgr = c.Users.Where(x => x.UserName == u.UserName && x.Password == _Password).FirstOrDefault();
            if(dgr!=null)
            {
                FormsAuthentication.SetAuthCookie(dgr.UserId.ToString(), false);
                Session["Email"] = dgr.Email.ToString();
                TempData["FullName"] = dgr.FullName.ToString();
                return RedirectToAction("Index", "User");
            }
            else
            {
                return View();
            }
          
        }


        public ActionResult Info()
        {
            var userid1 = (string)Session["UserId"];
            var dgr = c.Users.Where(x => x.UserName == userid1).FirstOrDefault();
            return View(dgr);
        }
    }
}