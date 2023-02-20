using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserAuthentication.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Subscriptions { get; set; }
        public string SubscriptionType { get; set; }
        //public string Email { get; set; }

        public string PlansId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Prize { get; set; }
        public string status { get; set; }

    }
    public class Plans
    {
        [Key]
        public int id { get; set; }
        public string PlanName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string BidsPerMonth { get; set; }
        public string PricePerMonth { get; set; }
        public string status { get; set; }
    }

}