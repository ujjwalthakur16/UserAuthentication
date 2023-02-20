using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserAuthentication.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        // Foreign key 
        [Display(Name = "Order")]
        public int OrderID { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order Order{ get; set; }

        // Foreign key 
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Products Products { get; set; }
        public double Prize { get; set; }
        public int Quantity { get; set; }
        public double totalPrize { get; set; }
        public double CGSTpercent { get; set; }
        public double SGSTpercent { get; set; }
        public double CGSTamount { get; set; }
        public double SGSTamount { get; set; }


    }
}