using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaystackPaymentIntegration.Models.Entities
{
    public partial class product
    {
        public product()
        {
            order_detail = new HashSet<order_detail>();
        }

        [Key]
        public int product_id { get; set; }

        [Required]
        [MaxLength(150)]
        public string product_name { get; set; }

        [Required]
        [MaxLength(2000)]
        public string description { get; set; }

        [Required]
        public decimal price { get; set; }

        [Required]
        [MaxLength(10)]
        public string product_image { get; set; }

        public virtual ICollection<order_detail> order_detail { get; set; }
    }
}