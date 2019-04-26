using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaystackPaymentIntegration.Models.DTOs.Readonly
{
    public class ProductDTO
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string product_image { get; set; }
    }
}