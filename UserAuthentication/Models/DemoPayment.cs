using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserAuthentication.Models
{
    public class DemoPayment
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string ProductInfo { get; set; }
        public string Email { get; set; }
    }
}