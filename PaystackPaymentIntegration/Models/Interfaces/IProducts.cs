using PaystackPaymentIntegration.Models.DTOs.Readonly;
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
        Task<List<ProductDTO>> GetAllProducts();
        Task<bool> AddToCart(cart cart);
        //IEnumerable<product> GetAllProducts();
        //bool AddToCart(cart cart);
    }
}
