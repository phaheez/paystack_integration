using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PaystackPaymentIntegration.Models.DataModel
{
    public class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        static BaseContext() { Database.SetInitializer<TContext>(null); }

        protected BaseContext() : base("name=PaymentEntities") { }
    }
}