using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserAuthentication.Models;

namespace UserAuthentication.Controllers
{
    public class OrderViewModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrderViewModel
        public ActionResult Index(int? id)
        {
            var u = User.Identity.GetUserId();
            var invoice = new OrderViewModel
            {
                order = db.Order.Where(x=>x.Id==id).ToList(),
                orderDetails = db.OrderDetail.Where(x => x.Order.Id==id).ToList()
            };
            return View(invoice);
        }

        //public ActionResult DownloadPDF()
        //{
        //    var model = new OrderViewModel
        //    {
        //        order = db.Order.Where(x => x.Id == id).ToList(),
        //        orderDetails = db.OrderDetail.Where(x => x.Order.Id == id).ToList()
        //    }; ; // your model data here
        //       return new rotativa
        //}

        // GET: OrderViewModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Invoice(int? id)
        {
            var addrs = db.Address.Where(x => x.Id == id).SingleOrDefault();
            var crt = db.Cart.Where(x => x.userID == addrs.UserId).ToList();
            Order order = new Order();
            order.UserId = addrs.UserId;
            
            order.AddressId = addrs.Id;
            order.Date= DateTime.Now.Date;
            order.DiscountPercent = 0;
            order.ModeifiedDate= DateTime.Now.Date;
            var t = crt.Sum(c => Convert.ToDouble(c.ItemTotal));
            var tt = (t * 5) / 100;
            order.TotalPrice = crt.Sum(c =>Convert.ToDouble( c.ItemTotal)) + tt;
            order.DiscountAmount = (order.TotalPrice * order.DiscountPercent) / 100;
            order.netAmount = order.TotalPrice;
            order.orderStatus = "processing";
            order.paymentStatus =   "Cash";
            db.Order.Add(order);
            db.SaveChanges();
            OrderDetails orderDetails = new OrderDetails();
            foreach(var item in crt)
            {
                orderDetails.OrderID = order.Id;
                orderDetails.Prize = item.Price;
                orderDetails.ProductId = item.ProductId;
                orderDetails.Quantity = item.Items;
                orderDetails.CGSTpercent =2.5;
                orderDetails.SGSTpercent = 2.5;
                orderDetails.CGSTamount = ((item.Price * item.Items) * 2.5) / 100;
                orderDetails.SGSTamount = ((item.Price * item.Items) * 2.5) / 100;

                //var total = ((item.Price * item.Items) * 5) / 100;
                orderDetails.totalPrize =Convert.ToDouble( item.ItemTotal) +Convert.ToDouble( orderDetails.CGSTamount +orderDetails.SGSTamount);
                db.OrderDetail.Add(orderDetails);
                
                db.SaveChanges();
            }
            db.Cart.RemoveRange(crt);
            db.SaveChanges();

            return RedirectToAction("Index", new { id=order.Id});
        }

        public ActionResult OrderDetails(int? id)
        {
            var u = User.Identity.GetUserId();

            var invoice = new OrderViewModel
            {
                order = db.Order.Where(x => x.UserId == u).ToList(),
                orderDetails = db.OrderDetail.Where(x => x.Order.UserId == u).ToList()
            };
            return View(invoice);
        }

        // GET: OrderViewModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderViewModel/Create
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

        // GET: OrderViewModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderViewModel/Edit/5
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

        // GET: OrderViewModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderViewModel/Delete/5
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
