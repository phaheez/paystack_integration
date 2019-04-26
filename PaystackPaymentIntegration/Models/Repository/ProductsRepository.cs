using PaystackPaymentIntegration.Models.DataModel;
using PaystackPaymentIntegration.Models.DTOs.Readonly;
using PaystackPaymentIntegration.Models.Entities;
using PaystackPaymentIntegration.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PaystackPaymentIntegration.Models.Repository
{
    public class ProductsRepository : BaseRepository<product, int>, IProducts
    {
        private DbContext _dbcontxt;
        public ProductsRepository(ShoppingCartContext dbContext) : base(dbContext)
        {
            _dbcontxt = dbContext;
        }

        public Task<bool> AddToCart(cart cart)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDTO>> GetAllProducts()
        {
            var result = await GetAll()
                .Select(x => new ProductDTO
                {
                    product_id = x.product_id,
                    product_name = x.product_name,
                    description = x.description,
                    price = x.price,
                    product_image = x.product_image
                }).ToListAsync();

            return result;
        }
    }
}