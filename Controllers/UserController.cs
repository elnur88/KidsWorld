using KidsWorld.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        public void SendEmailToUser(string emailId, string activationCode)
        {
            MailMessage mail = new MailMessage();
            var GenarateUserVerificationLink = "/User/UserVerification/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, GenarateUserVerificationLink);
            mail.To.Add(emailId);
            mail.From = new MailAddress("eliyevelnur88@gmail.com");
            mail.Subject = "Registration Completed-Demo";
            string Body = "<br/> Your registration completed succesfully." +
                           "<br/> please click on the below link for account verification" +
                           "<br/><br/><a href=" + link + ">" + link + "</a>";
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.mail.ru";
            smtp.Port = 465;

            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential("elnur_muh@mail.ru", "Elnur12345"); // Enter seders User name and password  
            smtp.EnableSsl = true;
            smtp.Send(mail);

            
        }
        #region Check Email Exists or not in DB  
        public bool IsUserNameExists(string UserName1)
        {
            var IsCheck = c.Users.Where(email => email.UserName == UserName1).FirstOrDefault();
            return IsCheck != null;
        }
        #endregion
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
            var IsExists = IsUserNameExists(k.UserName);
            if (IsExists)
            {
                ModelState.AddModelError("UserNameExist","İstifadəçi adı artıq mövcuddur");
                List<SelectListItem> usercombo = (from x in c.Users.Where(x => x.Status == 0).ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.UserName,
                                                      Value = x.UserId.ToString()
                                                  }).ToList();
                ViewBag.dgr1 = usercombo;
                return View("AddUser");
            }
            
            k.RecordDate = DateTime.Now;
            k.EmailVerification = false;
            Guid guid = Guid.NewGuid();
            k.ActivetionCode = guid.ToString();
            k.Password = KidsWorld.Models.Class.encryptPassword.textToEncrypt(k.Password);
            k.User_Id = 1;
            c.Users.Add(k);
            c.SaveChanges();
            //SendEmailToUser(k.Email,k.ActivetionCode);
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

        public ActionResult UserVerification(string id)
        {
            bool Status = false;

            c.Configuration.ValidateOnSaveEnabled = false; // Ignor to password confirmation   
            var IsVerify = c.Users.Where(u => u.ActivetionCode == new Guid(id).ToString()).FirstOrDefault();

            if (IsVerify != null)
            {
                IsVerify.EmailVerification = true;
                c.SaveChanges();
                ViewBag.Message = "Email Verification completed";
                Status = true;
            }
            else
            {
                ViewBag.Message = "Invalid Request...Email not verify";
                ViewBag.Status = false;
            }

            return View();
        }


    }
}