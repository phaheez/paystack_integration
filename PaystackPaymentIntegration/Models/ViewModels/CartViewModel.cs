using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaystackPaymentIntegration.Models.ViewModels
{
    public class CartViewModel
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string product_image { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public decimal total_amount { get { return quantity * price; } }
    }
}