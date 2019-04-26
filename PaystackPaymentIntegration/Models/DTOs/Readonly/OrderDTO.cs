using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaystackPaymentIntegration.Models.DTOs.Readonly
{
    public class OrderDTO
    {
        public long order_id { get; set; }
        public string order_reference { get; set; }
        public string surname { get; set; }
        public string othername { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address_line1 { get; set; }
        public string address_line2 { get; set; }
        public DateTime? order_date { get; set; }
        public string payment_reference { get; set; }
    }
}