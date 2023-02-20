using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserAuthentication.Models
{
    public class Products
    {
       [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Created_by { get; set; }
        public string Discription { get; set; }
        public string MRP { get; set; }
        public string Discount { get; set; }
        public string DiscountTo { get; set; }
        public DateTime? DiscountFromDate { get; set; }
        public DateTime? DiscountToDate { get; set; }
        // Foreign key 
        [Display(Name = "SubCategory")]
        public int SubCategoryId { get; set; }

        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { get; set; }
        public string Picture { get; set; }
        public decimal Diccounted_MRP { get; set; }
        public decimal PriceOf_2 { get; set; }



    }
}