using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserAuthentication_.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        //[ForeignKey("Id")]
        public string UserName { get; set; }
        public string UserId { get; set; }
        //public virtual Id Id { get; set; }
        public string Price { get; set; }
        //public HttpPostedFileBase[] Document { get; set; }

        public string BidAcceptedof { get; set; }
        public string Picture { get; set; }




    }

    //public class 
}