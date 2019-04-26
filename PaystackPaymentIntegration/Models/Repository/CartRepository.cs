using PaystackPaymentIntegration.Models.DataModel;
using PaystackPaymentIntegration.Models.Entities;
using PaystackPaymentIntegration.Models.Interfaces;
using PaystackPaymentIntegration.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PaystackPaymentIntegration.Models.Repository
{
    public class CartRepository : BaseRepository<ShoppingCartContext>, ICart
    {
        public async Task<bool> AddToCart(cart cart)
        {
            var item = DataContext.cart.Where(x => x.product_id == cart.product_id);
            if (item.Any())
            {
                item.First().count += 1;
                await DataContext.SaveChangesAsync();
                return true;
            }

            DataContext.cart.Add(cart);
            return await DataContext.SaveChangesAsync() > 0;
        }

        public async Task<string> GetCartId(HttpContextBase context)
        {
            throw new NotImplementedException();
        }

        public async Task<cart> GetCartItem(long itemId)
        {
            return await DataContext.cart.FirstOrDefault(x => x.record_id == itemId);
        }

        public async Task<IEnumerable<cart>> GetCartItems()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CartViewModel>> GetUserCartItems(string cartId)
        {
            throw new NotImplementedException();
        }
    }
}