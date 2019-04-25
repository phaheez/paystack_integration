using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaystackPaymentIntegration.Models.Interfaces
{
    public interface IEntity
    {
        string order_reference { get; set; }
    }
}