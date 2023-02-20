using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserAuthentication.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public DateTime ModeifiedDate { get; set; }
        public double TotalPrice { get; set; }
        public int Tax { get; set; }
        public double DiscountPercent { get; set; }
        public double DiscountAmount { get; set; }

        public double netAmount { get; set; }
        public string orderStatus { get; set; }
        public string paymentStatus { get; set; }
        //public string AddressId { get; set; }
        [Display(Name = "Address")]
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }
    }
}