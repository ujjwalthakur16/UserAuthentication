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
    public class SubCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubCategories
        public ActionResult Index()
        {
            var subCategory = db.SubCategory.Include(s => s.Categories);
            return View(subCategory.ToList());
        }

        // GET: SubCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.SubCategory.Find(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // GET: SubCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "ID", "Name");
            return View();
        }

        // POST: SubCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubCategory subCategory, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                var FileName = Path.GetFileName(Image.FileName);
                var ImagePath = Path.Combine(Server.MapPath("~/Subcatogeries/"), FileName);
                Image.SaveAs(ImagePath);
                var u = User.Identity.GetUserId();
                var usr = db.Users.Where(x => x.Id == u).SingleOrDefault();
                SubCategory category1 = new SubCategory
                {
                    Name = subCategory.Name,
                    CreatedBy = usr.FirstName + usr.LastName,
                    CraetedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Discription = subCategory.Discription,
                    CategoryId=subCategory.CategoryId,
                    Picture= FileName
                };
                if (category1.CreatedBy == "")
                {
                    category1.CreatedBy = usr.UserName;
                }
                db.SubCategory.Add(category1);
                db.SaveChanges();
            }
            ViewBag.CategoryId = new SelectList(db.Category, "ID", "Name", subCategory.CategoryId);
            return View("Menu");
        }

        // GET: SubCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.SubCategory.Find(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Category, "ID", "Name", subCategory.CategoryId);
            return View(subCategory);
        }

        // POST: SubCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,CraetedDate,ModifiedDate,CreatedBy,Discription,CategoryId")] SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Category, "ID", "Name", subCategory.CategoryId);
            return View(subCategory);
        }
        public ActionResult Menu(int? id)
        {
            var p = db.SubCategory.Where(x => x.CategoryId == id).Include(s => s.Categories).ToList();
            return View(p);
        }

        // GET: SubCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.SubCategory.Find(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // POST: SubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCategory subCategory = db.SubCategory.Find(id);
            db.SubCategory.Remove(subCategory);
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
