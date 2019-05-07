using PaystackPaymentIntegration.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PaystackPaymentIntegration.Models.DataModel
{
    public partial class PaymentContext : BaseContext<PaymentContext>
    {
        //public ShoppingCartContext() : base("name=ShoppingCartEntities") { }



        public virtual DbSet<transaction_record> transaction_record { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }
    }
}