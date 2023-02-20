using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserAuthentication.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Country { get; set; }
        [Required]

        public string fullName { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string mobileNumber { get; set; }
        [Required]
        public string pinCode { get; set; }
        [Required]
        public string Houseno { get; set; }
        [Required]
        public string Area { get; set; }
        
        public string Landmark { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public string UserId { get; set; }


    }
}