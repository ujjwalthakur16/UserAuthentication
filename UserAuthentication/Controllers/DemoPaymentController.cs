using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;


public class DemoPaymentController : Controller
{
    //public ActionResult Index()
    //{
    //    return View();
    //}

    //[HttpPost]
    //public ActionResult PaymentSuccess()
    //{
    //    var form = Request.Form.ToString();
    //    ViewBag.mihpayid = Request.Form["mihpayid"].ToString();
    //    ViewBag.paymentId = Request.Form["paymentId"].ToString();
    //    ViewBag.mode = Request.Form["Mode"].ToString();
    //    ViewBag.status = Request.Form["status"].ToString();
    //    ViewBag.txnid = Request.Form["txnid"].ToString();
    //    ViewBag.amount = Request.Form["amount"].ToString();
    //    return View("PaymentSuccess");
    //}
    //[HttpPost]
    //public ActionResult PaymentFailed()
    //{
    //    var form = Request.Form.ToString();
    //    return View("Index");
    //}
    //public ActionResult Hash(string txnid, string key, string salt, string amount, string productinfo, string firstname, string email, string phone, string udf5,string udf1)
    //{
    //    string d = key + "|" + txnid + "|" + amount + "|" + productinfo + "|" + firstname + "|" + email + "|" + udf1 + "||||" + udf5 + "||||||" + salt;
    //return Json(GetStringFromHash(d), JsonRequestBehavior.AllowGet);
    //}
    //private static string GetStringFromHash(string text)
    //{
    //    byte[] message = Encoding.UTF8.GetBytes(text);
    //    UnicodeEncoding UE = new UnicodeEncoding();
    //    byte[] hashValue;
    //    SHA512Managed hashString = new SHA512Managed();
    //    string hex = "";
    //    hashValue = hashString.ComputeHash(message);
    //    foreach (byte x in hashValue)
    //    {
    //        hex += String.Format("{0:x2}", x);
    //    }
    //    return hex;
    //}





    //private readonly PaymentGateway _paymentGateway;

    //public PaymentController()
    //{
    //    // Initialize the PayU payment gateway
    //    _paymentGateway = new PaymentGateway(new PayUConfig
    //    {
    //        ApiKey = "YOUR_API_KEY",
    //        ApiLogin = "YOUR_API_LOGIN",
    //        MerchantId = "YOUR_MERCHANT_ID",
    //        AccountId = "YOUR_ACCOUNT_ID"
    //    });
    //}

    //public ActionResult Index()
    //{
    //    // Display the payment form
    //    return View();
    //}

    //[HttpPost]
    //public ActionResult ProcessPayment(PaymentForm form)
    //{
    //    // Process the payment submission
    //    try
    //    {
    //        // Create a payment request
    //        var request = new PaymentRequest
    //        {
    //            // Set the payment details
    //            Amount = form.Amount,
    //            Currency = "CAD",
    //            ReferenceCode = "YOUR_REFERENCE_CODE",
    //            Buyer = new Buyer
    //            {
    //                Name = form.Name,
    //                Email = form.Email,
    //                Phone = form.Phone
    //            },
    //            PaymentMethod = form.PaymentMethod,
    //            CreditCard = new CreditCard
    //            {
    //                Number = form.CardNumber,
    //                ExpirationDate = form.ExpirationDate,
    //                SecurityCode = form.SecurityCode
    //            }
    //        };

    //        // Send the payment request to PayU
    //        var response = _paymentGateway.CreatePayment(request);

    //        // Check the response status
    //        if (response.Status == "SUCCESS")
    //        {
    //            // Payment was successful
    //            return View("PaymentSuccess");
    //        }
    //        else
    //        {
    //            // Payment failed
    //            return View("PaymentError", response.Status);
    //        }
    //    }
    //    catch (PayUException ex)
    //    {
    //        // An error occurred while processing the payment
    //        return View("PaymentError", ex.Message);
    //    }
    //}
}