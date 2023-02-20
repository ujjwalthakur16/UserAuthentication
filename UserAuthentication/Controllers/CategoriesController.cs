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
    public class CategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        //[Authorize(Roles = "Admin")]
        // GET: Categories
        [Authorize]
        public ActionResult Index()
        {
            var cat = db.Category.ToList();
            return View(cat);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Category category,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                var FileName = Path.GetFileName(Image.FileName);
                var ImagePath = Path.Combine(Server.MapPath("~/Categories/"), FileName);
                Image.SaveAs(ImagePath);
                var u = User.Identity.GetUserId();
                var usr = db.Users.Where(x => x.Id == u).SingleOrDefault();
                Category category1 = new Category
                {
                    Name = category.Name,
                    Created_by = usr.FirstName + usr.LastName,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Discription = category.Discription,
                    Picture = FileName
                };
                if(category1.Created_by=="")
                {
                    category1.Created_by = usr.UserName;
                }
                db.Category.Add(category1);
                db.SaveChanges();
                return View(category);
                //return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            var pro = db.Category.Where(x => x.ID == id).SingleOrDefault();
            return View(pro);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase Image, Category category, int? id)
        {
           if(id!=null)
            {
                var cat = db.Category.Where(x => x.ID == id).SingleOrDefault();
                var FileName = Path.GetFileName(Image.FileName);
                var ImagePath = Path.Combine(Server.MapPath("~/Categories/"), FileName);
                Image.SaveAs(ImagePath);
                cat.Name = category.Name;
                cat.Discription = category.Discription;
                cat.Picture = FileName;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
            //return View();
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Category.Find(id);
            db.Category.Remove(category);
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
