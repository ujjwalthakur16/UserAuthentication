using Microsoft.AspNet.Identity;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserAuthentication.Models;

namespace UserAuthentication.Controllers
{
    public class CartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Carts
        public ActionResult Index()
        {
            var u = User.Identity.GetUserId();
            var crt = db.Cart.Where(x => x.userID == u).ToList();
            if(crt!=null && crt.Count>0)
            {
                return View(crt);
            }
            return RedirectToAction("empty");
        }

        public ActionResult AddToCart(int? id)
        {
            var u = User.Identity.GetUserId();
            var products = db.Products.Where(x => x.ID == id).SingleOrDefault();
            var cart = db.Cart.Where(x => x.ProductId == id && x.userID == u).SingleOrDefault();
            if (cart == null)
            {
                cart = new Cart();
                cart.Name = products.Name;
                cart.Picture = products.Picture;
                cart.Items = 1;
                cart.Price = Convert.ToInt32(products.MRP);
                cart.Discription = products.Discription;
                cart.CreatedBy = products.Created_by;
                cart.ProductId = products.ID;
                cart.userID = User.Identity.GetUserId();
                cart.ItemTotal = (cart.Price * cart.Items).ToString();
                db.Cart.Add(cart);
                db.SaveChanges();
                db.SaveChanges();
            }
            else
            {
                cart.Items++;
                cart.ItemTotal = (cart.Price * cart.Items).ToString();
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var u = User.Identity.GetUserId();
            var crt = db.Cart.Where(x => x.userID == u).ToList();
            ViewData["CartCount"] = crt.Sum(x=>x.Items); // count Qty in your cart
            if(crt.Count==0)
            {
                ViewData["CartCount"] = null;// count Qty in your cart
            }
                return PartialView("CartSummary");
        }

        // GET: Carts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Cart.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }
        public ActionResult Decrement(int? id)
        {
            var u = User.Identity.GetUserId();
            var itm = db.Cart.Where(x => x.Id == id && x.userID == u).SingleOrDefault();
            itm.Items--;
            itm.ItemTotal = (itm.Price * itm.Items).ToString();
            if(itm.Items==0)
            {
                return RedirectToAction("Remove",new { id = itm.Id});
            }
            db.SaveChanges();
            //itm.ItemTotal=
            return RedirectToAction("Index");
        }
        public ActionResult empty()
        {
            return View();
        }
        public ActionResult Increment(int? id)
        {
            var u = User.Identity.GetUserId();
            var itm = db.Cart.Where(x => x.Id == id && x.userID == u).SingleOrDefault();
            itm.Items++;
            itm.ItemTotal = (itm.Price * itm.Items).ToString();
            db.SaveChanges();
            //itm.ItemTotal=
            return RedirectToAction("Index");
        }

        //[Route("create-checkout-session")]
        ////[ApiController]
        //public class CheckoutApiController : Controller
        //{
        //    [HttpPost]
        //    public ActionResult Create()
        //    {
        //        var domain = "http://localhost:4242";
        //        var options = new SessionCreateOptions
        //        {
        //            LineItems = new List<SessionLineItemOptions>
        //        {
        //          new SessionLineItemOptions
        //          {
        //            // Provide the exact Price ID (for example, pr_1234) of the product you want to sell
        //            Price = "{{PRICE_ID}}",
        //            Quantity = 1,
        //          },
        //        },
        //            Mode = "payment",
        //            SuccessUrl = domain + "/success.html",
        //            CancelUrl = domain + "/cancel.html",
        //        };
        //        var service = new SessionService();
        //        Session session = service.Create(options);

        //        Response.Headers.Add("Location", session.SuccessUrl);
        //        return new HttpStatusCodeResult (303);
        //    }
        //}

        // GET: Carts/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ID", "Name");
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Discription,CreatedBy,Price,Picture,Items,userID,ProductId")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Cart.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ID", "Name", cart.ProductId);
            return View(cart);
        }

        // GET: Carts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Cart.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ID", "Name", cart.ProductId);
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Discription,CreatedBy,Price,Picture,Items,userID,ProductId")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ID", "Name", cart.ProductId);
            return View(cart);
        }

        // GET: Carts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Cart.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.Cart.Find(id);
            db.Cart.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Remove(int? id)
        {
            Cart cart = db.Cart.Find(id);
            db.Cart.Remove(cart);
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
