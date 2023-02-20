using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserAuthentication.Models;

namespace UserAuthentication.Controllers
{
    public class PlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Plans
        public ActionResult Index()
        {
            return View();
        }

        // GET: Plans/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Plans/Create
        [Authorize]
        public ActionResult ProPlan()
        {
            var uid = User.Identity.GetUserId();
            var u = db.Users.Where(x => x.Id == uid).SingleOrDefault();
            Plans pp = new Plans();
            pp.PlanName = "Pro";
            pp.PricePerMonth = "$15";
            pp.UserId = User.Identity.GetUserId();
            pp.UserName = u.FirstName +" "+ u.LastName;
            pp.BidsPerMonth = "5";
            pp.status ="Pending";
            db.Plans.Add(pp);
            db.SaveChanges();
            return RedirectToAction("Create", "Subscription",new {id=pp.id});
        }
        [Authorize]
        public ActionResult PremiumPlan()
        {

            var uid = User.Identity.GetUserId();
            var u = db.Users.Where(x => x.Id == uid).SingleOrDefault();
            Plans pp = new Plans();
            pp.PlanName = "Premium";
            pp.PricePerMonth = "$100";
            pp.UserId = User.Identity.GetUserId();
            pp.UserName = u.FirstName + " " + u.LastName;
            pp.BidsPerMonth = "Umlimited";
            pp.status = "Pending";
            db.Plans.Add(pp);
            db.SaveChanges();
            return RedirectToAction("Create", "Subscription" ,new { id = pp.id });
        }

        // POST: Plans/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Plans/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Plans/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Plans/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Plans/Delete/5
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
