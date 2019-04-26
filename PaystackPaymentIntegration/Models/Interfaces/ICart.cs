using PaystackPaymentIntegration.Models.Entities;
using PaystackPaymentIntegration.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PaystackPaymentIntegration.Models.Interfaces
{
    public interface ICart
    {
        Task<IEnumerable<cart>> GetCartItems();
        Task<cart> GetCartItem(long itemId);
        Task<bool> AddToCart(cart cart);
        Task<string> GetCartId(HttpContextBase context);
        Task<IEnumerable<CartViewModel>> GetUserCartItems(string cartId);
    }
}
