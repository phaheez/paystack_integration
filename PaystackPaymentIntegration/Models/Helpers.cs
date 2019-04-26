using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaystackPaymentIntegration.Models
{
    public static class Helpers
    {
        public static string CalcTotalPrice(int quantity, decimal price)
        {
            return ((decimal)quantity * price).ToString("#,##.00");
        }
    }
}