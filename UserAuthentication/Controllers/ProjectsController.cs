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
using UserAuthentication_.Models;

namespace UserAuthentication.Controllers
{
   //[Authorize(Roles = "Employer,Job Seeker,Admin")]
    //[Authorize(Roles = "Job Seeker")]
    //[Authorize(Roles = "Admin")]


    public class ProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Projects
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        [Authorize(Roles = "Employer")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Project project, HttpPostedFileBase[] Document)
        {
            //if(Document!=null)
            //{
            //        int count =0;
            //    Project pro = new Project();
            //    foreach (HttpPostedFileBase file in Document)
            //    {
            //        //Checking file is available to save.  
            //        if (file != null)
            //        {
            //            var InputFileName = Path.GetFileName(file.FileName);
            //            var ServerSavePath = Path.Combine(Server.MapPath("~/Documents/") + InputFileName);
            //            //Save file to server folder  
            //            file.SaveAs(ServerSavePath);
            //            //assigning file uploaded status to ViewBag for showing message to user.  
            //            //ViewBag.UploadStatus = Document.Count().ToString() + " files uploaded successfully.";
            //            if(count==0)
            //            {
            //                    pro.Document1 = InputFileName;
            //            }
            //            else if(count==1)
            //            {
            //                pro.Document2 = InputFileName;
            //            }
            //            else if(count==2)
            //            {
            //                pro.Document3 = InputFileName;
            //            }
            //            else
            //            {
            //                pro.Document4 = InputFileName;
            //            }
            //        }
            //        count++;
            //    }
            //    //var File = Path.GetFileName(Document.);
            //    //var FilePath = Path.Combine(Server.MapPath("~/Documents/"), FileName);
            //    //Document.SaveAs(FilePath);
            //    pro.Id = project.Id;
            //    pro.Title = project.Title;
            //    pro.Description = project.Description;
            //    pro.Date = DateTime.Now.ToString();
            //    pro.Status = "Active";
            //    pro.UserId = User.Identity.GetUserId();
            //    pro.Price = project.Price;
            //    //pro.Document1 = FileName;
            //    pro.UserName = User.Identity.GetUserName();
            //    db.Projects.Add(pro);
            //    db.SaveChanges();
            //}
            //else
            //{
            //}

                Project pro = new Project();
                pro.Id = project.Id;
                pro.Title = project.Title;
                pro.Description = project.Description;
                pro.Date = DateTime.Now.ToString();
                pro.Status = project.Status;
                pro.UserId = User.Identity.GetUserId();
                pro.Price = project.Price;
                pro.UserName = User.Identity.GetUserName();
                db.Projects.Add(pro);
                db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            var pro = db.Projects.Where(x => x.Id == id).SingleOrDefault();
            return View(pro);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Project project, HttpPostedFileBase[] Document)
        {
            if(id!=null)
            {
                //if (Document != null)
                //{
                //    int count = 0;
                //    var pro = db.Projects.Where(x => x.Id == id).SingleOrDefault();
                //    foreach (HttpPostedFileBase file in Document)
                //    {
                //        //Checking file is available to save.  
                //        if (file != null)
                //        {
                //            var InputFileName = Path.GetFileName(file.FileName);
                //            var ServerSavePath = Path.Combine(Server.MapPath("~/Documents/") + InputFileName);
                //            //Save file to server folder  
                //            file.SaveAs(ServerSavePath);
                //            //assigning file uploaded status to ViewBag for showing message to user.  
                //            //ViewBag.UploadStatus = Document.Count().ToString() + " files uploaded successfully.";
                //            if (count == 0)
                //            {
                //                pro.Document1 = InputFileName;
                //            }
                //            else if (count == 1)
                //            {
                //                pro.Document2 = InputFileName;
                //            }
                //            else if (count == 2)
                //            {
                //                pro.Document3 = InputFileName;
                //            }
                //            else
                //            {
                //                pro.Document4 = InputFileName;
                //            }
                //            count++;

                //        }
                //    }
                //}
                    var pro = db.Projects.Where(x => x.Id == id).SingleOrDefault();
                    pro.Id = project.Id;
                    pro.Title = project.Title;
                    pro.Description = project.Description;
                    pro.Date = DateTime.Now.ToString();
                    pro.Status = project.Status;
                    pro.UserId = User.Identity.GetUserId();
                    pro.Price = project.Price;
                    pro.UserName = User.Identity.GetUserName();
                    db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //public ActionResult Documents(int? id)
        //{
        //    var d = db.Projects.Where(x => x.Id == id).ToList();
        //    return View(d);
        //}

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
