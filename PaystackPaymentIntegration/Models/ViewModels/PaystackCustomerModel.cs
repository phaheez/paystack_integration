using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaystackPaymentIntegration.Models.ViewModels
{
    public class PaystackCustomerModel
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int amount { get; set; }
    }
}