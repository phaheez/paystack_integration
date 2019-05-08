using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaystackPaymentIntegration.Models.DTOs.Readonly
{
    public class TransactionDTO
    {
        public int transaction_id { get; set; }

        public string email { get; set; }

        public int amount { get; set; }

        public string reference { get; set; }
    }
}