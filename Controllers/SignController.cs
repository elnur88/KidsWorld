using KidsWorld.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace KidsWorld.Controllers
{
    public class SignController : Controller
    {
        Context c = new Context();
        public bool IsUserNameExists(string UserName1)
        {
            var IsCheck = c.Users.Where(email => email.UserName == UserName1).FirstOrDefault();
            return IsCheck != null;
        }


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
        // GET: Sign
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(User k)
        {
            var IsExists = IsUserNameExists(k.UserName);
            if (IsExists)
            {
                ModelState.AddModelError("", "İstifadəçi adı artıq mövcuddur");
                
                return View();
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
            return RedirectToAction("EnterLogin", "Login",new { area = ""});
        }

    }
}