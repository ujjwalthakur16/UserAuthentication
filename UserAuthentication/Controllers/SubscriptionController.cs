using Microsoft.AspNet.Identity;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserAuthentication.Models;

namespace UserAuthentication.Controllers
{
    public class SubscriptionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Subscription
        public ActionResult Index()
        {
            return View();
        }

        // GET: Subscription/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Subscription/Create
        public ActionResult Create(int? id )
        {
            var uid = User.Identity.GetUserId();

            var model = db.Users.Where(x => x.Id == uid).SingleOrDefault();

            string to = model.Email, UserID, Password, SMTPPort, Host;
            var guid = Guid.NewGuid();
            //int portnumber = 44337;
            //Create URL with an above token
            var lnkHref = " Moolight Subscription" + Environment.NewLine + Url.Action("Success", "Subscription", new { id = model.Id }, "https");

            //HTML Template for Send email
            string subject = "Your Subscription Payment";
            string body = "CLick the link to complete your payment and become a member of the MOONLIGHT" + Environment.NewLine + lnkHref;

            EmailManager.AppSettings(out UserID, out Password, out SMTPPort, out Host);

            //Call send email methods.
            EmailManager.SendEmail(UserID, subject, body, to, UserID, Password, SMTPPort, Host);
            var u = User.Identity.GetUserId();
            var usr = db.Users.Where(x => x.Id == u).SingleOrDefault();
            var plan = db.Plans.Where(x => x.id == id).SingleOrDefault();
            Subscription sub = new Subscription();
            sub.UserId = User.Identity.GetUserId();
            sub.PlansId = id.ToString();
            sub.StartDate = DateTime.Now.ToString();
            sub.status = "Pending";
            sub.Subscriptions = "Pending";
            sub.SubscriptionType = plan.PlanName;
            sub.Prize = plan.PricePerMonth;

            if(sub.SubscriptionType== "Premium")
            {
                sub.EndDate = DateTime.Now.AddDays(365).ToString();
            }
            sub.EndDate = DateTime.Now.AddDays(30).ToString();

            db.Subscription.Add(sub);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
            //var uid = User.Identity.GetUserId();
            //var uzr = db.Users.Where(x => x.Id == uid).SingleOrDefault();
            //return View();
        }

        // POST: Subscription/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection, ApplicationUser model)
        //{
        //    string to = model.Email, UserID, Password, SMTPPort, Host;
        //     var guid = Guid.NewGuid();
        //    //int portnumber = 44337;
        //    //Create URL with an above token
        //    var lnkHref = "<a href='" + Url.Action("Success", "Subscription", new { id = model.Id }, "https") + "'>Reset Password</a>";

        //    //HTML Template for Send email
        //    string subject = "Your changed password";
        //    string body = "<b>Please find the Password Reset Link. </b><br/>" + lnkHref;

        //    EmailManager.AppSettings(out UserID, out Password, out SMTPPort, out Host);

        //    //Call send email methods.
        //    EmailManager.SendEmail(UserID, subject, body, to, UserID, Password, SMTPPort, Host);
        //    return RedirectToAction("Index", "Home");
        //}

        // GET: Subscription/Edit/5
        public ActionResult Success(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Home");
            }
            var user = db.Users.Where(x => x.Id == id).SingleOrDefault();
            var pl = db.Plans.Where(x => x.UserId == id).ToList();
            var sub = db.Subscription.Where(x => x.UserId==id).SingleOrDefault();
            if (sub.SubscriptionType == "Premium")
            {
                user.subscription = "Premium";
                foreach(var item in pl)
                {
                    item.status = "Active";
                }
                sub.Subscriptions = "PremiumSubscriber";
                sub.status = "Active";

            }
            else
            {
                user.subscription = "Pro";
                foreach (var item in pl)
                {
                    item.status = "Active";
                }
                sub.Subscriptions = "ProSubscriber";

                sub.status = "Active";
            }
            db.SaveChanges();
            return View();
        }

        // POST: Subscription/Edit/5
        //[HttpPost]
        //public ActionResult Success()
        //{
        //    return RedirectToAction("Index", "Home");
        //}

        // GET: Subscription/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Subscription/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
