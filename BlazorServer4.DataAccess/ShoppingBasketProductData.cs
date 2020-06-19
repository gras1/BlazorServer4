using BlazorServer4.ClassLibrary;
using BlazorServer4.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer4.DataAccess
{
    public class ShoppingBasketProductData : IShoppingBasketProductData
    {
        private readonly IDbContext _dbContext;

        public ShoppingBasketProductData(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<ShoppingBasketItemProduct>> GetShoppingBasketItems(Guid shoppingBasketId)
        {
            var productsTask = _dbContext.Products.ToArrayAsync();
            var shoppingBasketItemsTask = _dbContext.ShoppingBasketItems.Where(sbi => sbi.ShoppingBasketId == shoppingBasketId).ToArrayAsync();
            await Task.WhenAll(productsTask, shoppingBasketItemsTask);

            var products = productsTask.Result;
            var shoppingBasketItems = shoppingBasketItemsTask.Result;
            var productCategories = new ShoppingBasketItemProduct[shoppingBasketItems.Length];
            var counter = 0;

            foreach (var shoppingBasketItem in shoppingBasketItems)
            {
                var foundProduct = products.FirstOrDefault(p => p.ProductId == shoppingBasketItem.ProductId);
                if (foundProduct != null)
                {
                    productCategories[counter] = new ShoppingBasketItemProduct
                    {
                        Name = foundProduct.Name,
                        PriceEach = foundProduct.Price,
                        Quantity = shoppingBasketItem.Quantity,
                        PriceTotal = foundProduct.Price * shoppingBasketItem.Quantity
                    };
                }
                counter++;
            }

            return productCategories;
        }
    }
}
