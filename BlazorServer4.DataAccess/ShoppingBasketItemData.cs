using BlazorServer4.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer4.DataAccess
{
    public class ShoppingBasketItemData : IShoppingBasketItemData
    {
        private readonly IDbContext _dbContext;

        public ShoppingBasketItemData(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddShoppingBasketItem(ClassLibrary.ShoppingBasketItem shoppingBasketItem)
        {
            var existingShoppingBasketItem = _dbContext.ShoppingBasketItems.FirstOrDefault(sbi => sbi.ShoppingBasketId == shoppingBasketItem.ShoppingBasketId && sbi.ProductId == shoppingBasketItem.ProductId);
            if (existingShoppingBasketItem != null)
            {
                existingShoppingBasketItem.Quantity += shoppingBasketItem.Quantity;
            }
            else
            {
                _dbContext.ShoppingBasketItems.Add(new ShoppingBasketItem
                {
                    ShoppingBasketItemId = Guid.NewGuid(),
                    ShoppingBasketId = shoppingBasketItem.ShoppingBasketId,
                    ProductId = shoppingBasketItem.ProductId,
                    Quantity = shoppingBasketItem.Quantity
                });
            }
            await _dbContext.SaveChangesAsync();
        }

        public async IAsyncEnumerable<ClassLibrary.ShoppingBasketItem> GetShoppingBasketItems(Guid shoppingBasketId)
        {
            var shoppingBasketItems = _dbContext.ShoppingBasketItems.Where(sbi => sbi.ShoppingBasketId == shoppingBasketId).AsAsyncEnumerable();
            await foreach (var shoppingBasketItem in shoppingBasketItems)
            {
                yield return new ClassLibrary.ShoppingBasketItem
                {
                    ShoppingBasketItemId = shoppingBasketItem.ShoppingBasketItemId,
                    ShoppingBasketId = shoppingBasketItem.ShoppingBasketId,
                    ProductId = shoppingBasketItem.ProductId,
                    Quantity = shoppingBasketItem.Quantity
                };
            }
        }

        public async Task<int> GetShoppingBasketItemQuantity(Guid shoppingBasketId)
        {
            return await _dbContext.ShoppingBasketItems.Where(sbi => sbi.ShoppingBasketId == shoppingBasketId).SumAsync(sbi => sbi.Quantity);
        }

        public async Task DeleteShoppingBasketItem(Guid shoppingBasketId, int productId)
        {
            var existingShoppingBasketItem = _dbContext.ShoppingBasketItems.FirstOrDefault(sbi => sbi.ShoppingBasketId == shoppingBasketId && sbi.ProductId == productId);
            if (existingShoppingBasketItem != null)
            {
                _dbContext.ShoppingBasketItems.Remove(existingShoppingBasketItem);
                await _dbContext.SaveChangesAsync();
            }
        }

        ~ShoppingBasketItemData()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
