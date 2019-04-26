using PaystackPaymentIntegration.Models.DataModel;
using PaystackPaymentIntegration.Models.DTOs.Readonly;
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
    public class CartRepository : BaseRepository<cart, int>, ICart
    {
        public async Task<bool> AddToCart(cart cart)
        {
            //var item = DataContext.cart.Where(x => x.product_id == cart.product_id);
            //if (item.Any())
            //{
            //    item.First().count += 1;
            //    await DataContext.SaveChangesAsync();
            //    return true;
            //}

            //DataContext.cart.Add(cart);
            //return await DataContext.SaveChangesAsync() > 0;
        }

        public async Task<string> GetCartId(HttpContextBase context)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDTO> GetCartItem(long itemId)
        {
            //return await DataContext.cart.FirstOrDefault(x => x.record_id == itemId);
            var result = await GetWhere(x => x.record_id == itemId)
                .Select(x => new CartDTO
                {
                    record_id = x.record_id,
                    cart_id = x.cart_id,
                    ProductInfo = new ProductDTO
                    {
                        //product_id = x.product_id,
                        //product_name = x.product_name,
                        //description = x.description,
                        //price = x.price,
                        //product_image = x.product_image
                    },
                    count = x.count,
                    amount = x.amount,
                    created_date = x.created_date
                }).()

            return result;
        }

        public async Task<List<cart>> GetCartItems()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CartViewModel>> GetUserCartItems(string cartId)
        {
            throw new NotImplementedException();
        }
    }
}