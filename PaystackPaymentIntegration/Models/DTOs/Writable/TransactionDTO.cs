using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaystackPaymentIntegration.Models.DTOs.Writable
{
    public class TransactionDTOW
    {
        [Required]
        [MaxLength(100)]
        public string email { get; set; }

        [Required]
        public int amount { get; set; }
    }
}