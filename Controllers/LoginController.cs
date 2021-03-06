﻿using System;
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
        public bool IsEmailVerifications(string _username)
        {
            var IsCheck = c.Users.Where(u => u.UserName == _username && u.EmailVerification==true).FirstOrDefault();
            return IsCheck != null;
        }
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
                var IsExists = IsEmailVerifications(u.UserName);
                if (!IsExists)
                {
                    ModelState.AddModelError("", "Email aktiv edilmiyib zəhmət olmasa mail ə daxil olub aktiv edilmə əməliyatın tamamlayın");
                    return View();
                }
                int timeout = u.Rememberme ? 60 : 5;
                var ticket = new FormsAuthenticationTicket(dgr.UserId.ToString(), false, timeout);
                //FormsAuthentication.SetAuthCookie(dgr.UserId.ToString(), false);
                string encrypted = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                cookie.Expires = System.DateTime.Now.AddMinutes(timeout);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);
                Session["Email"] = dgr.Email.ToString();
                TempData["FullName"] = dgr.FullName.ToString();
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("", "İstifadəçi adı və ya şifrə yalnışdır");
                return View();
            }
          
        }


        public ActionResult Info()
        {
            var userid1 = (string)Session["UserId"];
            var dgr = c.Users.Where(x => x.UserName == userid1).FirstOrDefault();
            return View(dgr);
        }

        public ActionResult RestPassword()
        {
            var userid1 = (string)Session["UserId"];
            var dgr = c.Users.Where(x => x.UserName == userid1).FirstOrDefault();
            return View(dgr);
        }


      



        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("EnterLogin", "Login");
        }
    }
}