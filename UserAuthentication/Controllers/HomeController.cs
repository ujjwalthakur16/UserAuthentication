using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserAuthentication.Models;

namespace UserAuthentication.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                var u = User.Identity.GetUserId();
                var usr = db.Users.Where(x => x.Id == u).SingleOrDefault();
                return View(usr);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(FormCollection form)
        {

            if(form!=null)
            {
                //var uid = User.Identity.GetUserId();
                //var model = db.Users.Where(x => x.Id == uid).SingleOrDefault();

                string to = form["Email"], UserID, Password, SMTPPort, Host;
                var guid = Guid.NewGuid();
                //int portnumber = 44337;
                //Create URL with an above token
                //var lnkHref = 

                //HTML Template for Send email+
                string subject = "Your Message has delivered";
                string body = "Thanks, for letting us know with your comment. We will check all your querries and we'll get back to you within 24 hours.";

                EmailManager.AppSettings(out UserID, out Password, out SMTPPort, out Host);

                //Call send email methods.
                EmailManager.SendEmail(UserID, subject, body, to, UserID, Password, SMTPPort, Host);
            }

            if (form != null)
            {
                var uid = User.Identity.GetUserId();

                var model = db.Users.Where(x => x.Id == "f1f0b787-b10c-49ff-b10f-2023312ee51a").SingleOrDefault();

                string to = model.Email, UserID, Password, SMTPPort, Host;
                var guid = Guid.NewGuid();
                //int portnumber = 44337;
                //Create URL with an above token
                var lnkHref = Environment.NewLine + Environment.NewLine + form["Comment"];

                //HTML Template for Send email
                string subject = "Someone sent a message.";
                string body = "we recieved a message from our user. check it!"+lnkHref;

                EmailManager.AppSettings(out UserID, out Password, out SMTPPort, out Host);

                //Call send email methods.
                EmailManager.SendEmail(UserID, subject, body, to, UserID, Password, SMTPPort, Host);

            }
            Contact usr = new Contact();
            usr.Name = form["Name"];
            usr.Email = form["Email"];
            usr.Message = form["Comment"];
            db.Contact.Add(usr);
            db.SaveChanges();
            ViewBag.Message = String.Format("Hello {0}.\\nYour message has delivered.", form["Name"]);
            return RedirectToAction("Index", "Home");
        }
    }
}