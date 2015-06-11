using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using DotWalkersFinal.Models;
using System.Text;

namespace DotWalkers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Why we're here:";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "How to contact us:";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModels c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msg = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    MailAddress from = new MailAddress(c.Email.ToString());
                    StringBuilder sb = new StringBuilder();
                    msg.To.Add("youremail@email.com");
                    msg.Subject = "Contact Us";
                    msg.IsBodyHtml = false;
                    smtp.Host = "mail.yourdomain.com";
                    smtp.Port = 25;
                    sb.Append("First name: " + c.FirstName);
                    sb.Append(Environment.NewLine);
                    sb.Append("Last name: " + c.LastName);
                    sb.Append(Environment.NewLine);
                    sb.Append("Email: " + c.Email);
                    sb.Append(Environment.NewLine);
                    sb.Append("Comments: " + c.Comment);
                    msg.Body = sb.ToString();
                    smtp.Send(msg);
                    msg.Dispose();
                    return View("Success");
                }
                catch (Exception)
                {
                    return View("Error");
                }
            }
            return View();
        }

        public ActionResult Bios()
        {
            ViewBag.Message = "Hello, my name is:";

            return View();
        }
    }
}