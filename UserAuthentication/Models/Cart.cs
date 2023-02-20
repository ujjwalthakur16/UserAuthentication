using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserAuthentication.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string CreatedBy { get; set; }
        public int Price { get; set; }
        public string Picture { get; set; }
        public int Items { get; set; }
        public string userID { get; set; }
        [Display(Name = "Products")]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Products Products { get; set; }
        public string ItemTotal { get; set; }
        public string grandTotal { get; set; }
    }
    public class myViewModel
    {
        public Cart cart { get; set; }
    }
}