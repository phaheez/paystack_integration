using PaystackPaymentIntegration.Models.DataModel;
using PaystackPaymentIntegration.Models.Entities;
using PaystackPaymentIntegration.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaystackPaymentIntegration.Models.Repository
{
    public class ProductsRepository : BaseRepository<ShoppingCartContext>, IProducts
    {
        public bool AddToCart(cart cart)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<product> GetAllProducts()
        {
            return DataContext.product;
        }
    }
}