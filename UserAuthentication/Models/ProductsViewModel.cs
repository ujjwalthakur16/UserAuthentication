using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserAuthentication.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<SubCategory> SubCategories { get; set; }
        public IEnumerable<Products> products { get; set; }
        public IEnumerable<Category> categories { get; set; }


    }
}