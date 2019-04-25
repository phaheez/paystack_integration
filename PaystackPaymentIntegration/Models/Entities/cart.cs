using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaystackPaymentIntegration.Models.Entities
{
    public partial class cart
    {
        [Key]
        public long record_id { get; set; }

        [Required]
        [MaxLength(500)]
        public string cart_id { get; set; }

        [Required]
        public int product_id { get; set; }

        [Required]
        public int count { get; set; }

        [Required]
        public decimal amount { get; set; }
        public DateTime? created_date { get; set; }
    }
}