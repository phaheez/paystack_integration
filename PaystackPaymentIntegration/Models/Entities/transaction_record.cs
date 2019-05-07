using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaystackPaymentIntegration.Models.Entities
{
    public partial class transaction_record
    {
        [Key]
        public int transaction_id { get; set; }

        [Required]
        [MaxLength(100)]
        public string email { get; set; }

        [Required]
        public int amount { get; set; }

        [Required]
        [MaxLength(100)]
        public string reference { get; set; }

        [Required]
        public DateTime created_date { get; set; }
    }
}