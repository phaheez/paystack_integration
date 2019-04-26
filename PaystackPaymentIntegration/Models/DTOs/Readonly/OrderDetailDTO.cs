using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaystackPaymentIntegration.Models.DTOs.Readonly
{
    public class OrderDetailDTO
    {
        public long order_detail_id { get; set; }
        public string order_reference { get; set; }
        public ProductDTO ProductInfo { get; set; }
        public int quantity { get; set; }
        public decimal unit_price { get; set; }
    }
}