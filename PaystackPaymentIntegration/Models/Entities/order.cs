using PaystackPaymentIntegration.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaystackPaymentIntegration.Models.Entities
{
    public partial class order : IEntity
    {
        [Key]
        public long order_id { get; set; }

        [Required]
        [MaxLength(50)]
        public string order_reference { get; set; }

        [Required]
        [MaxLength(50)]
        public string surname { get; set; }

        [Required]
        [MaxLength(50)]
        public string othername { get; set; }

        [Required]
        [MaxLength(20)]
        public string phone { get; set; }

        [Required]
        [MaxLength(50)]
        public string email { get; set; }

        [Required]
        [MaxLength(50)]
        public string address_line1 { get; set; }

        [Required]
        [MaxLength(50)]
        public string address_line2 { get; set; }
        public DateTime? order_date { get; set; }

        [MaxLength(50)]
        public string payment_reference { get; set; }
    }
}