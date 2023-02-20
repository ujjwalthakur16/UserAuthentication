using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserAuthentication.Controllers
{
    [Route("create-checkout-session")]
    //[ApiController]
    public class CheckoutApiController : Controller
    {
        //[HttpPost]
        public ActionResult Create()
        {
            var domain = "http://localhost:4242";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                  new SessionLineItemOptions
                  {
                    // Provide the exact Price ID (for example, pr_1234) of the product you want to sell
                    Price = "pr_9",
                    Quantity = 1,
                  },
                },
                Mode = "payment",
                SuccessUrl = domain + "/success.html",
                CancelUrl = domain + "/cancel.html",
            };
            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.SuccessUrl);
            return new HttpStatusCodeResult(303);
        }

        // GET: CheckoutApi
        public ActionResult Index()
        {
            return View();
        }
    }
}