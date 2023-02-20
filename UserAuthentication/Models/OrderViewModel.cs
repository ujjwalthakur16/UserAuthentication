using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserAuthentication.Models
{
    public class OrderViewModel
    {
        public IEnumerable<Order> order { get; set; }
        public IEnumerable<OrderDetails> orderDetails { get; set; }
    }
}