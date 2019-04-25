using PaystackPaymentIntegration.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PaystackPaymentIntegration.Models.Entities
{
    public partial class order_detail : IEntity
    {
        [Key]
        public long order_detail_id { get; set; }

        [Required]
        [MaxLength(50)]
        public string order_reference { get; set; }

        [Required]
        public int product_id { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        public decimal unit_price { get; set; }

        [ForeignKey("product_id")]
        public virtual product product { get; set; }
    }
}