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
    public class ProductsController : Controller
    {
        //private readonly IUnitOfWork _unitOfWork;

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.SubCategory);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        //public ActionResult Search(string searchvalue)
        //{
        //    return View();
            
        //}

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.SubCategoryId = new SelectList(db.SubCategory, "ID", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products products, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                var FileName = Path.GetFileName(Image.FileName);

                var ImagePath = Path.Combine(Server.MapPath("~/Images/"), FileName);
                
                Image.SaveAs(ImagePath);
                
                var u = User.Identity.GetUserId();
                
                var usr = db.Users.Where(x => x.Id == u).SingleOrDefault();
                
                Products category1 = new Products();
                
                category1.Name = products.Name;
                
                category1.Created_by = usr.FirstName +" "+ usr.LastName;
                
                category1.CreatedDate = DateTime.Now;
                
                category1.ModifiedDate = DateTime.Now;
                
                category1.MRP = products.MRP;
                
                category1.Discount = products.Discount + "%";
                
                category1.DiscountTo = "Subscriber Only";
                
                category1.DiscountFromDate = DateTime.Now;
                
                category1.DiscountToDate = DateTime.Now.AddDays(20);
                
                category1.Discription = products.Discription;
                
                category1.SubCategoryId = products.SubCategoryId;
                
                category1.Picture = FileName;
                
                var dis = (Convert.ToInt32(products.MRP) * Convert.ToInt32(products.Discount)) / 100;
                
                category1.Diccounted_MRP = Convert.ToInt32(products.MRP) - dis;
                
                var dis2 = ((Convert.ToInt32(products.MRP) + Convert.ToInt32(products.MRP)) * 25) / 100;
                
                category1.PriceOf_2 = (Convert.ToInt32(products.MRP)*2) - dis2;
                
                if (category1.Created_by == "")
                {
                    category1.Created_by = usr.UserName;
                }
                
                db.Products.Add(category1);
                
                db.SaveChanges();
                
                return RedirectToAction("Menu");
            }

            ViewBag.SubCategoryId = new SelectList(db.SubCategory, "ID", "Name", products.SubCategoryId);
            return View(products);
        }

        //[HttpGet]
        public ActionResult Search(string searchvalue)
        {
            var products = db.Products.Include(p => p.SubCategory).ToList();
            //return View(products.ToList());
            return PartialView("_Menu", products);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Products products = db.Products.Find(id);
            
            if (products == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.SubCategoryId = new SelectList(db.SubCategory, "ID", "Name", products.SubCategoryId);
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Products products, int? id)
        {
            if (ModelState.IsValid)
            {
                var u = User.Identity.GetUserId();
                
                var usr = db.Users.Where(x => x.Id == u).SingleOrDefault();
                
                var category1 = db.Products.Where(x => x.ID == id).SingleOrDefault();
                
                category1.Name = products.Name;
                
                category1.ModifiedDate = DateTime.Now;
                
                category1.MRP = products.MRP;
                
                category1.Discount = products.Discount;
                
                category1.DiscountTo = "Subscriber Only";
                
                category1.DiscountFromDate = DateTime.Now;
                
                category1.DiscountToDate = DateTime.Now.AddDays(20);
                
                category1.Discription = products.Discription;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubCategoryId = new SelectList(db.SubCategory, "ID", "Name", products.SubCategoryId);
            return View(products);
        }
        public ActionResult Menu(int? id)
        {
            var u = User.Identity.GetUserId();
            var p = db.Products.Where(x=>x.SubCategoryId==id).Include(x=>x.SubCategory).ToList();
            var crt = db.Cart.Where(x => x.userID == u).ToList();
            ViewData["CartData"] = crt;
            var d = db.Products.Where(x => x.SubCategory.CategoryId == id).FirstOrDefault();
            if (p.Count == 0)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public ActionResult Cart(int? id)
        {
            var p = db.Products.Where(x => x.ID == id).Include(s => s.SubCategory).ToList();
            return View(p);
        }


        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
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
