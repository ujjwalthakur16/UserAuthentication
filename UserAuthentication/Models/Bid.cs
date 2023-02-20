using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserAuthentication.Models
{
    public class Bid
    {
        [Key]
        public int Id { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
        public string projecId { get; set; }
        public string projectName { get; set; }
        public string setBid { get; set; }
        public string Date { get; set; }
        public string Skills { get; set; }
        public string Status { get; set; }
        public string Picture { get; set; }
        
        public string CV { get; set; }
        

    }
}