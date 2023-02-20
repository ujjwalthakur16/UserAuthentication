using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserAuthentication.Models
{
    public class SubCategory
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime? CraetedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set;  }
        public string Discription { get; set; }

        // Foreign key 
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Categories { get; set; }
        public string Picture { get; set; }
    }
}