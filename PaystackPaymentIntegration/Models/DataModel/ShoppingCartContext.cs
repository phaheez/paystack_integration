using PaystackPaymentIntegration.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PaystackPaymentIntegration.Models.DataModel
{
    public partial class ShoppingCartContext : BaseContext<ShoppingCartContext>
    {
        //public ShoppingCartContext() : base("name=ShoppingCartEntities") { }

        

        public virtual DbSet<cart> cart { get; set; }
        public virtual DbSet<order> order { get; set; }
        public virtual DbSet<order_detail> order_detail { get; set; }
        public virtual DbSet<product> product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }
    }
}