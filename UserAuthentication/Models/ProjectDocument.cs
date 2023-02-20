using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserAuthentication.Models
{
    public class ProjectDocument
    {
        [Key]
        public int Id { get; set; }
        public string ProjectId { get; set; }
        public string Document { get; set; }
    }
}