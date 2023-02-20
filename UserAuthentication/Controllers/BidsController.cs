using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserAuthentication.Models;

namespace UserAuthentication.Controllers
{
    public class BidsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bids
        public ActionResult Index()
        {
            return View(db.Bids.ToList());
        }

        // GET: Bids/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = db.Bids.Find(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            return View(bid);
        }

        [Authorize(Roles = "Job Seeker")]
        // GET: Bids/Create
        public ActionResult Create(int? id)
        {
            string ID = Convert.ToString(id);

            var dt = db.Projects.Where(x => x.Id == id).SingleOrDefault();
            //var b = db.Bids.Where(x => x.userId == uid).SingleOrDefault();
            var u = User.Identity.GetUserId();
            var b = db.Bids.Where(y => y.userId == u && y.projecId == ID).FirstOrDefault();
            if(b==null && dt.Status!="Accepted")
            {
                return View();
            }
            else if (dt.Status != "Accepted")
            {
                return RedirectToAction("Edit", new {id = b.Id });
            }
            else
            {
                ModelState.AddModelError("", "Sorry this Project is already Accepted.");
                //ViewBag.Message = "Sorry this Project is already Accepted.";
                return RedirectToAction("Index", "Projects");
            }
        }

        // POST: Bids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int? id, Bid bid, HttpPostedFileBase CV)
        {
            if(CV!=null)
            {
                var FileName = Path.GetFileName(CV.FileName);
                var ImagePath = Path.Combine(Server.MapPath("~/CV/"), FileName);
                CV.SaveAs(ImagePath);
                Bid b = new Bid();
                var pId = db.Projects.Where(x => x.Id == id).SingleOrDefault();
                b.Id = bid.Id;
                b.userId = User.Identity.GetUserId();
                b.userName = User.Identity.GetUserName();
                b.projecId = pId.Id.ToString();
                b.setBid = bid.setBid;
                b.Date = DateTime.Now.ToString();
                b.Skills = bid.Skills;
                b.projectName = pId.Title;
                b.Status = "Pending";
                b.CV = FileName;
                db.Bids.Add(b);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Projects");
        }
        //[HttpGet]
        [AllowAnonymous]
        public ActionResult Checkbids(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var p = User.Identity.GetUserId();
            //var img = db.Users.Where(x => x.Id == p).SingleOrDefault();
            var b = db.Bids.Where(x => x.projecId == id.ToString()).ToList();
            return View(b);
        }
   

        public ActionResult Checkbid(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var b = db.Bids.Where(x => x.projecId == id.ToString());
            return View(b.ToList());
        }

        // GET: Bids/Edit/5
        public ActionResult Accept(string projectid, int? id)
        {
            
            int pi = Convert.ToInt32(projectid);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bid = db.Bids.Where(x => x.Id == id).SingleOrDefault();
            var p = db.Projects.Where(x => x.Id == pi).SingleOrDefault();
            p.Status = "Accepted";
            bid.Status = "Accepted";
            p.BidAcceptedof = bid.userName;
            db.SaveChanges();
            var ckb = db.Bids.Where(x => x.Id != id && x.projecId == projectid).ToList();
            foreach(var item in ckb)
            {
                item.Status = "Rejected";
                db.SaveChanges();
            }
            if (bid == null)
            {
                return HttpNotFound();
            }
            var uid = User.Identity.GetUserId();
            var model = db.Users.Where(x => x.Id == uid).SingleOrDefault();
            var proj = db.Projects.Where(x => x.UserId == uid).ToList();
            foreach(var item in proj)
            {
                var b = db.Bids.Where(x => x.projecId == item.Id.ToString()).ToList();
            }
            string to = model.Email, UserID, Password, SMTPPort, Host;
            var guid = Guid.NewGuid();
            //int portnumber = 44337;
            //Create URL with an above token
            //var lnkHref = Environment.NewLine + Environment.NewLine +"";

            //HTML Template for Send email
            string subject = "It's a Message from MOONLIGHT STUDIO.";
            string body = "You've accepted bid of "+ p.BidAcceptedof+ " and   money detucted from your wallet.";

            EmailManager.AppSettings(out UserID, out Password, out SMTPPort, out Host);

            //Call send email methods.
            EmailManager.SendEmail(UserID, subject, body, to, UserID, Password, SMTPPort, Host);
            return RedirectToAction("Index","Projects");
        }
        public ActionResult Edit(int? id)
        {
            var b = db.Bids.Where(x => x.Id == id).SingleOrDefault();
            return View(b);
        }

        // POST: Bids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Bid bid,HttpPostedFileBase CV)
        {
            var FileName = Path.GetFileName(CV.FileName);
            var ImagePath = Path.Combine(Server.MapPath("~/CV/"), FileName);
            CV.SaveAs(ImagePath);
            var b = db.Bids.Where(x => x.Id == id).SingleOrDefault();
                b.Id = bid.Id;
                b.userId = User.Identity.GetUserId();
                b.userName = User.Identity.GetUserName();
                //b.projecId = pId.Id.ToString();
                b.setBid = bid.setBid;
                b.Date = DateTime.Now.ToString();
                b.Skills = bid.Skills;
                b.Status = "Pending";
                b.CV = FileName;
                //b.projectName = pId.Title;
                db.SaveChanges();
            return RedirectToAction("Index","Projects");
        }

        // GET: Bids/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = db.Bids.Find(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            return View(bid);
        }

        // POST: Bids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bid bid = db.Bids.Find(id);
            db.Bids.Remove(bid);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
