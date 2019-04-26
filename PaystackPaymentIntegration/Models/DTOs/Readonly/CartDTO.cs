using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaystackPaymentIntegration.Models.DTOs.Readonly
{
    public class CartDTO
    {
        public long record_id { get; set; }
        public string cart_id { get; set; }
        public ProductDTO ProductInfo { get; set; }
        public int count { get; set; }
        public decimal amount { get; set; }
        public DateTime? created_date { get; set; }
    }
}