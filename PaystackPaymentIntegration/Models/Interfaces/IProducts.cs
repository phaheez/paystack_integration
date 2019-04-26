using PaystackPaymentIntegration.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaystackPaymentIntegration.Models.Interfaces
{
    public interface IProducts
    {
        IEnumerable<product> GetAllProducts();
        bool AddToCart(cart cart);
    }
}
