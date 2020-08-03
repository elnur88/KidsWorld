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

        public void SendEmailToUser(string emailId, string activationCode, string otpp, bool tipp)
        {
            var GenarateUserVerificationLink = "";
            string Body = "";
            int port = 587;
            if (tipp)
            {
                GenarateUserVerificationLink = "/User/UserVerification/" + activationCode;
            }
            else
            {
                GenarateUserVerificationLink = "/User/ChangePassword/" + activationCode;
            }
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, GenarateUserVerificationLink);
            if (tipp)
            {
                Body = "<br/> Qeydiyatınız uğurla tamamlandı." +
                               "<br/> Zəhmət olmasa təsdiqliyin" +
                               "<br/><br/><a href=" + link + ">" + link + "</a>";
            }
            else
            {
                Body = "<br/> Your registration completed succesfully." +
                              "<br/> please click on the below link for account verification" +
                              "<br/><br/><a href=" + link + ">" + link + "</a>";
            }
            string host = "smtp.gmail.com";
            string username = "kingsworld41@gmail.com";
            string password = "Kings@123";
            string mailFrom = "kingsworld41@gmail.com";
            string mailTo = emailId;
            string mailTitle = "Info";

            using (SmtpClient client = new SmtpClient())
            {
                MailAddress from = new MailAddress(mailFrom);
                MailMessage message = new MailMessage
                {
                    From = from
                };
                message.To.Add(mailTo);
                message.Subject = mailTitle;
                message.Body = Body;
                message.IsBodyHtml = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = null;
                client.UseDefaultCredentials = false;
                client.Host = host;
                client.Port = port;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential
                {
                    UserName = username,
                    Password = password
                };
                client.Send(message);
            }


        }
        #region Check Email Exists or not in DB  
        public bool IsUserNameExists(string UserName1)
        {
            var IsCheck = c.Users.Where(email => email.UserName == UserName1).FirstOrDefault();
            return IsCheck != null;
        }
        #endregion
        public bool IsEmailExists(string Email1)
        {
            var IsCheck = c.Users.Where(email => email.Email == Email1).FirstOrDefault();
            return IsCheck != null;
        }
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
            //if (!ModelState.IsValid)
            //{
            //    return View("AddUser");
            //}
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
            SendEmailToUser(k.Email, k.ActivetionCode, "", true);
            return View("SendMail");
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
                ViewBag.Message = "Email təsdiqləmə başa çatdı";
                Status = true;
            }
            else
            {
                ViewBag.Message = "Səhv...Email təsdiqləmə xəta";
                ViewBag.Status = false;
            }

            return View();
        }

        public ActionResult SendMail(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult RestPassword(User k)
        {
            var IsExists = IsEmailExists(k.Email);
            if (!IsExists)
            {
                ModelState.AddModelError("EmailNotExists", "This email is not exists");
                return View();
            }
            var objUsr = c.Users.Where(x => x.Email == k.Email).FirstOrDefault();

            // Genrate OTP   
            string OTP = KidsWorld.Models.Class.GenerateOtp.GeneratePassword();


            objUsr.ActivetionCode = Guid.NewGuid().ToString();
            objUsr.OTP = OTP;
            c.Entry(objUsr).State = System.Data.Entity.EntityState.Modified;
            c.SaveChanges();

            SendEmailToUser(objUsr.Email, objUsr.ActivetionCode.ToString(), objUsr.OTP,false);
            return View();
        }

    }



}




